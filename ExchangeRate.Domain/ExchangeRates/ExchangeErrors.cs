using ExchangeRate.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Domain.ExchangeRates;
public static class ExchangeErrors
{
    public static Error NotFound = new(
        "Currency.Found",
        "The currency with the specified identifier was not found");

    public static Error InvalidRate = new(
        "Rate.InvalidRate",
        "The provided rate was invalid");

    public static Error UnchangedRate = new(
        "Rate.UnchangedRate",
        "The provided rate was unchanged");
}
