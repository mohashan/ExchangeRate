using ExchangeRate.Application.Abstractions.Messaging;
using ExchangeRate.Application.Abstractions.Notification;
using ExchangeRate.Domain.Abstractions;
using ExchangeRate.Domain.ExchangeRates;

namespace ExchangeRate.Application.ExchangeRates.UpdateRate;

internal sealed class NewRateCommandHandler : ICommandHandler<NewRateCommand,Guid>
{
    private readonly IExchangeRateRepository exchangeRateRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly INotificationService notificationService;

    public NewRateCommandHandler(IExchangeRateRepository exchangeRateRepository, IUnitOfWork unitOfWork, INotificationService notificationService)
    {
        this.exchangeRateRepository = exchangeRateRepository;
        this.unitOfWork = unitOfWork;
        this.notificationService = notificationService;
    }

    public async Task<Result<Guid>> Handle(NewRateCommand request, CancellationToken cancellationToken)
    {
        CurrencyPair pair;
        try
        {
            pair = CurrencyPair.FromCode(request.Code);
        }
        catch (Exception)
        {
            return Result.Failure<Guid>(ExchangeErrors.NotFound);
        }
        var ExRate = await exchangeRateRepository.GetByCodeAsync(pair, cancellationToken);

        if (ExRate is null)
        {
            return Result.Failure<Guid>(ExchangeErrors.NotFound);
        }

        try
        {
            var NewRate = Domain.ExchangeRates.ExchangeRate.NewRate(pair,request.Rate,new Source(request.Source));
            exchangeRateRepository.Add(NewRate);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            await notificationService.SendToAllAsync(
                new SendNotification(
                    new KeyValuePair<string, decimal>(NewRate.Pair.Code, NewRate.Rate)
                    ));

            return NewRate.Id;
        }
        catch (Exception)
        {
            return Result.Failure<Guid>(ExchangeErrors.InvalidRate);
        }
    }
}