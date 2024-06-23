using ExchangeRate.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Application.ExchangeRates.UpdateRate;
public record NewRateCommand(string Code, decimal Rate,string Source) : ICommand<Guid>;
