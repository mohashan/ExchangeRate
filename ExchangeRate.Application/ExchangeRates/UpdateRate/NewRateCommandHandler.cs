using ExchangeRate.Application.Abstractions.Messaging;
using ExchangeRate.Application.Abstractions.Notification;
using ExchangeRate.Domain.Abstractions;
using ExchangeRate.Domain.ExchangeRates;
using Microsoft.Extensions.Logging;

namespace ExchangeRate.Application.ExchangeRates.UpdateRate;

internal sealed class NewRateCommandHandler : ICommandHandler<NewRateCommand, Guid>
{
    private readonly IExchangeRateRepository exchangeRateRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly INotificationService notificationService;
    private readonly ILogger<NewRateCommandHandler> logger;

    public NewRateCommandHandler(IExchangeRateRepository exchangeRateRepository,
        IUnitOfWork unitOfWork,
        INotificationService notificationService,
        ILogger<NewRateCommandHandler> logger)
    {
        this.exchangeRateRepository = exchangeRateRepository;
        this.unitOfWork = unitOfWork;
        this.notificationService = notificationService;
        this.logger = logger;
    }

    public async Task<Result<Guid>> Handle(NewRateCommand request, CancellationToken cancellationToken)
    {
        CurrencyPair pair;
        decimal rate;
        Source source;
        try
        {
            pair = CurrencyPair.FromCode(request.Code);
            rate = decimal.Round(request.Rate, 5);
            source = new Source(request.Source);
        }
        catch (Exception)
        {
            return Result.Failure<Guid>(ExchangeErrors.NotFound);
        }
        var ExRate = await exchangeRateRepository.GetByCodeAsync(pair, cancellationToken);
        var NewRate = Domain.ExchangeRates.ExchangeRate.NewRate(pair, rate,source);

        if (ExRate == null)
        {
            exchangeRateRepository.Add(NewRate);
        }
        else
        {
            if (ExRate.Rate == rate)
            {
                return Result.Failure<Guid>(ExchangeErrors.UnchangedRate);
            }

            ExRate.Update(rate,source);
        }

        try
        {
            await unitOfWork.SaveChangesAsync(cancellationToken);

            await notificationService.SendToAllAsync(
                new SendNotification(
                    new Tuple<string, decimal>(pair.Code, rate)
                    ));

            return NewRate.Id;
        }
        catch (Exception)
        {
            return Result.Failure<Guid>(ExchangeErrors.InvalidRate);
        }
    }
}