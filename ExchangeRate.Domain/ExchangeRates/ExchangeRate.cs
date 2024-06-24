using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRate.Domain.Abstractions;

namespace ExchangeRate.Domain.ExchangeRates;
public sealed class ExchangeRate : Entity
{
    private ExchangeRate()
    {

    }

    public ExchangeRate(Guid id, CurrencyPair pair, decimal rate, Source lastUpdateSource) : base(id)
    {
        Pair = pair;
        Rate = rate;
        LastUpdateSource = lastUpdateSource;
    }

    public static ExchangeRate NewRate(CurrencyPair pair, decimal rate, Source source)
    {
        var ExRate = new ExchangeRate(Guid.NewGuid(), pair,rate,source);

        ExRate.LastUpdateOnUtc = DateTime.UtcNow;

        return ExRate;
    }

    public void Update(decimal rate, Source lastUpdateSource)
    {
        Rate = rate;
        LastUpdateSource = lastUpdateSource;
    }

    public Source LastUpdateSource { get; internal set; }
    public CurrencyPair Pair { get; private set; }
    public decimal Rate { get; private set; } 
    
    public DateTime? LastUpdateOnUtc { get; internal set; }
}
