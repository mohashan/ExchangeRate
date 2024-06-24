using ExchangeRate.Application.Abstractions.Notification;
using ExchangeRate.Application.ExchangeRates.ProvideRate;
using ExchangeRate.Application.ExchangeRates.UpdateRate;
using ExchangeRate.Domain.ExchangeRates;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace ExchangeRate.Infrastructure.Hubs;
public sealed class NotificationService : Hub, INotificationService
{
    public NotificationService(ISender sender, 
        IHubContext<NotificationService> context,
        ILogger<NotificationService> logger)
    {
        this.sender = sender;
        _context = context;
        this.logger = logger;
    }
    private const string source = "Updated_By_Signal";
    private const string methodName = "NewRate";
    private readonly ISender sender;
    private readonly IHubContext<NotificationService> _context;
    private readonly ILogger<NotificationService> logger;

    public async Task ReceiveAsync(ReceivedNotification notification)
    {
        logger.LogInformation($"New Update received : {notification.Rate.Key} : {notification.Rate.Value}");
        var pair = CurrencyPair.FromCode(notification.Rate.Key);
        var value = notification.Rate.Value;
        var updater = new Source(source);
        //var exRate = Domain.ExchangeRates.ExchangeRate.NewRate(pair, value, updater);

        await sender.Send(new NewRateCommand(pair.Code, value,updater.value));
    }

    public async Task GetRateFromOriginAsync()
    {
        var command = new ProvideRateCommand();

        var result = await sender.Send(command);
        if (result.IsFailure)
        {
            logger.LogError($"Get rate from origin failed: {result.Error.Code}");
        }

        logger.LogInformation("Get rate from origin done");
    }

    public async Task SendToAllAsync(SendNotification notification)
    {
        logger.LogInformation($"Sending to all {notification.Rate.Item1} : {notification.Rate.Item2}");
        await _context.Clients.All.SendAsync(methodName, notification);

    }
}
