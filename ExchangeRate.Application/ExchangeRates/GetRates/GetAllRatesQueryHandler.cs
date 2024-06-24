using ExchangeRate.Application.Abstractions.Messaging;
using ExchangeRate.Domain.Abstractions;
using ExchangeRate.Domain.ExchangeRates;
using Microsoft.Extensions.Logging;

namespace ExchangeRate.Application.ExchangeRates.GetRates;

internal sealed class GetAllRatesQueryHandler(ILogger<GetAllRatesQueryHandler> logger) : IQueryHandler<GetAllRatesQuery, IReadOnlyList<string>>
{
    public async Task<Result<IReadOnlyList<string>>> Handle(GetAllRatesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetAllRatesQuery received");
        var result = CurrencyPair.All.Select(c=>c.Code).ToList();
        return result;
    }
}