using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Domain.ExchangeRates;
public interface IExchangeRateRepository
{
    Task<ExchangeRate?> GetByCodeAsync(CurrencyPair code, CancellationToken cancellationToken = default);

    void Add(ExchangeRate exchangeRate);
}
