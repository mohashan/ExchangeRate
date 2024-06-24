using ExchangeRate.Application.Abstractions.Notification;
using ExchangeRate.Application.Abstractions.ServiceProviders;
using ExchangeRate.Domain.Abstractions;
using ExchangeRate.Domain.ExchangeRates;
using ExchangeRate.Infrastructure.Hubs;
using ExchangeRate.Infrastructure.Repositories;
using ExchangeRate.Infrastructure.ServiceProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<INotificationService,NotificationService>();

        services.AddScoped<IRateProvider, AlphaVantageRateProvider>();

        services.Configure<AlphaVantageSettings>(configuration.GetSection("AppConfig").GetRequiredSection(nameof(AlphaVantageSettings)));

        AddPersistence(services, configuration);

        services.AddHttpClient("AlphaVantage", option =>
        {
            option.BaseAddress = new Uri("https://www.alphavantage.co/");
        });


        return services;
    }

    private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database") ??
                    throw new ArgumentNullException(nameof(configuration));


        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString).UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IExchangeRateRepository, ExchangeRateRepository>();



        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());


    }
}