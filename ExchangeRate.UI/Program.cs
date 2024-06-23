using ExchangeRate.Application;
using ExchangeRate.Application.Abstractions.Notification;
using ExchangeRate.Application.ExchangeRates.UpdateRate;
using ExchangeRate.Infrastructure;
using ExchangeRate.Infrastructure.Hubs;
using ExchangeRate.UI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSignalR();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCustomExceptionHandler();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.MapHub<NotificationService>("/rateHub");

app.Run();
