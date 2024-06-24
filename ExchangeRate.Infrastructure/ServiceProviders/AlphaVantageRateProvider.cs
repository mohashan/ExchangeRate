using ExchangeRate.Application.Abstractions.ServiceProviders;
using ExchangeRate.Application.ExchangeRates.UpdateRate;
using ExchangeRate.Domain.Abstractions;
using ExchangeRate.Domain.ExchangeRates;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Infrastructure.ServiceProviders;
public sealed class AlphaVantageRateProvider : IRateProvider
{
    private const string source = "AlphaVantage";
    private const string responseRouteName = "Global Quote";
    private const string responseSymbolName = "01. symbol";
    private const string responsePriceName = "05. price";

    private readonly HttpClient _httpClient;
    private readonly ILogger<AlphaVantageRateProvider> logger;
    private readonly ISender sender;
    private readonly AlphaVantageSettings alphaVantageSettings;
    public AlphaVantageRateProvider(IHttpClientFactory httpClientFactory, 
        ILogger<AlphaVantageRateProvider> logger, 
        ISender sender,
        IOptions<AlphaVantageSettings> alphaVantageOptions)
    {
        _httpClient = httpClientFactory.CreateClient("AlphaVantage");
        this.logger = logger;
        this.sender = sender;
        this.alphaVantageSettings = alphaVantageOptions.Value;
    }

    public async Task UpdateRatesAsync(CurrencyPair pair)
    {
        HttpResponseMessage response;
        Tuple<string, decimal> result;
        
        try
        {
            response = await _httpClient.GetAsync($"query?function=GLOBAL_QUOTE&symbol={pair.Code}&apikey={alphaVantageSettings.ApiKey}");
        }
        catch (Exception)
        {
            logger.LogError("Alphavantage doesn't care how can I test my app with 25 request per day");
            return;
        }
        if (response == null ||
            response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            logger.LogError("Alphavantage provide invalid response");
            return;
        }

        var stringResponse = await response.Content.ReadAsStringAsync();
        
        try
        {
            //result = AlphaVantageParserTest(pair.Code);
            result = AlphaVantageParser(stringResponse);
            logger.LogInformation($"New rate received from {source}. {result.Item1}:{result.Item2}");

        }
        catch (Exception ex)
        {
            logger.LogError($"Alphavantage response parsing error. [error : {ex.Message}]");
            return;
        }

        var command = new NewRateCommand(result.Item1, result.Item2, source);
        await sender.Send(command);

        return;
    }

    private Tuple<string, decimal> AlphaVantageParser(string response)
    {
        Dictionary<string, Dictionary<string, string>>? result = null;
        try
        {
            result = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(response);
        }
        catch (Exception)
        {
            logger.LogError("Alphavantage response was not in meaningful format");
            // Do something
        }

        if (result is null)
        {
            throw new ArgumentNullException("AlphavantageResponse");
        }

        string pair = result[responseRouteName][responseSymbolName];

        decimal.TryParse(result[responseRouteName][responsePriceName], out decimal rate);


        return new Tuple<string, decimal>(pair, rate);
    }

    private Tuple<string, decimal> AlphaVantageParserTest(string symbol)
    {
        var random = new Random();
        return new Tuple<string, decimal>(symbol, (decimal)random.NextDouble());
    }
}

