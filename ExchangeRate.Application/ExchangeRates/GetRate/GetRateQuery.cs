using ExchangeRate.Application.Abstractions.Messaging;
using ExchangeRate.Application.ExchangeRates.GetRates;
using ExchangeRate.Domain.Abstractions;
using ExchangeRate.Domain.ExchangeRates;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Application.ExchangeRates.GetRate;
public sealed record GetRateQuery(string code): IQuery<Tuple<string,decimal>>;


internal sealed class GetRateQueryHandler(ILogger<GetRateQueryHandler> logger,
    IExchangeRateRepository repository) : IQueryHandler<GetRateQuery, Tuple<string, decimal>>
{
    public async Task<Result<Tuple<string, decimal>>> Handle(GetRateQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"GetRateQuery for code {request.code} received");
        CurrencyPair pair;
        try
        {
            pair = CurrencyPair.FromCode(request.code);
        }
        catch (Exception)
        {
            return Result.Failure<Tuple<string, decimal>>(ExchangeErrors.NotFound);
        }
        var result = await repository.GetByCodeAsync(pair,cancellationToken);
        if(result is null)
        {
            return Result.Failure<Tuple<string, decimal>>(ExchangeErrors.NotFound);
        }
        return new Tuple<string, decimal>(result.Pair.Code, result.Rate);
    }
}
