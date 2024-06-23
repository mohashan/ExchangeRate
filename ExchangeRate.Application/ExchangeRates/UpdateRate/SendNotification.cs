using ExchangeRate.Application.Abstractions.Notification;
using ExchangeRate.Domain.ExchangeRates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Application.ExchangeRates.UpdateRate;

public class SendNotification : NotificationMessage
{
    public SendNotification(KeyValuePair<string, decimal> rate)
    {
        Rate = rate;
    }
    public KeyValuePair<string, decimal> Rate { get; private set; }
}
