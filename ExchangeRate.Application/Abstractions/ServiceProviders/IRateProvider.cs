using ExchangeRate.Domain.ExchangeRates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Application.Abstractions.ServiceProviders;
public interface IRateProvider
{
    Task UpdateRatesAsync(CurrencyPair pair);
}
