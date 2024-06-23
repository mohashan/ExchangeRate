using ExchangeRate.Application.Abstractions.Notification;

namespace ExchangeRate.Application.ExchangeRates.UpdateRate;

public class ReceivedNotification : NotificationMessage
{
    public ReceivedNotification(KeyValuePair<string, decimal> rate)
    {
        Rate = rate;
    }
    public KeyValuePair<string, decimal> Rate { get; private set; }
}
