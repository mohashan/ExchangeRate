using ExchangeRate.Application.ExchangeRates.UpdateRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Application.Abstractions.Notification;
public interface INotificationService
{
    Task ReceiveAsync(ReceivedNotification notification);
    Task SendToAllAsync(SendNotification notification);
}
