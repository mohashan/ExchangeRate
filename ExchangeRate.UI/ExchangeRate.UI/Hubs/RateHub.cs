using ExchangeRate.UI.Model;
using Microsoft.AspNetCore.SignalR;

namespace ExchangeRate.UI.Hubs;

public class RateHub:Hub
{
    public async Task SendRate(UpdateRateRequest[] request)
    {

        await Clients.All.SendAsync("ReceiveRate", request);
    }
}

