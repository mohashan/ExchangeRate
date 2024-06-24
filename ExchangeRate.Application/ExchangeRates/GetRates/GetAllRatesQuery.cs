using ExchangeRate.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Application.ExchangeRates.GetRates;
public sealed record GetAllRatesQuery : IQuery<IReadOnlyList<string>>;
