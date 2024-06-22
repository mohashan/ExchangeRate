using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRate.Domain.Abstract;

namespace ExchangeRate.Domain.ExchangeRates;
public sealed class ExchangeRate : Entity
{
    private ExchangeRate()
    {

    }

    public ExchangeRate(Guid id, CurrencyPair pair, decimal rate) : base(id)
    {
        Pair = pair;
        Rate = rate;
    }
    public Source Source { get; private set; }
    public CurrencyPair Pair { get; private set; }
    public decimal Rate { get; private set; }
    public DateTime? LastUpdateOnUtc { get; internal set; }
}
