using ExchangeRate.Application.Abstractions.Notification;
using ExchangeRate.Application.ExchangeRates.UpdateRate;
using ExchangeRate.Domain.ExchangeRates;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

    public async Task SendToAllAsync(SendNotification notification)
    {
        logger.LogInformation($"Sending to all {notification.Rate.Key} : {notification.Rate.Value}");
        await _context.Clients.All.SendAsync(methodName, notification);

    }
}
