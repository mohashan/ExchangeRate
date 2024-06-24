using ExchangeRate.Application.Abstractions.Messaging;
using ExchangeRate.Application.Abstractions.ServiceProviders;
using ExchangeRate.Domain.Abstractions;
using ExchangeRate.Domain.ExchangeRates;
using Microsoft.Extensions.Logging;

namespace ExchangeRate.Application.ExchangeRates.ProvideRate;

internal sealed class ProvideRateCommandHandler : ICommandHandler<ProvideRateCommand>
{
    private readonly ILogger<ProvideRateCommandHandler> logger;
    private readonly IExchangeRateRepository rateRepository;
    private readonly IRateProvider rateProvider;

    public ProvideRateCommandHandler(ILogger<ProvideRateCommandHandler> logger, IExchangeRateRepository rateRepository, IRateProvider rateProvider)
    {
        this.logger = logger;
        this.rateRepository = rateRepository;
        this.rateProvider = rateProvider;
    }
    public async Task<Result> Handle(ProvideRateCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("New request to update rates from origin is received");
        var pairs = CurrencyPair.All;

        foreach (var pair in pairs)
        {
            await rateProvider.UpdateRatesAsync(pair);
        }

        return Result.Success();
    }
}