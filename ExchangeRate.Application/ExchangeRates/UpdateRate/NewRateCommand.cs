using ExchangeRate.Application.Abstractions.Messaging;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Application.ExchangeRates.UpdateRate;
public record NewRateCommand(string Code, decimal Rate, string Source) : ICommand<Guid>;


public class ReserveBookingCommandValidator : AbstractValidator<NewRateCommand>
{
    public ReserveBookingCommandValidator()
    {
        RuleFor(c => c.Code)
            .NotEmpty()
            .Length(6);

        RuleFor(c => c.Rate)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(c => c.Source)
            .NotEmpty()
            .MaximumLength(100);
    }
}