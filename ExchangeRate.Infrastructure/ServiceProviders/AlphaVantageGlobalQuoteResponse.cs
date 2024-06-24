namespace ExchangeRate.Infrastructure.ServiceProviders;

public class AlphaVantageGlobalQuoteResponse
{
    public GlobalQuote GlobalQuote { get; set; } = new();
}

public sealed class GlobalQuote
{
    public string _01symbol { get; set; } = string.Empty;
    public string _02open { get; set; } = string.Empty;
    public string _03high { get; set; } = string.Empty;
    public string _04low { get; set; } = string.Empty;
    public string _05price { get; set; } = string.Empty;
    public string _06volume { get; set; } = string.Empty;
    public string _07latesttradingday { get; set; } = string.Empty;
    public string _08previousclose { get; set; } = string.Empty;
    public string _09change { get; set; } = string.Empty;
    public string _10changepercent { get; set; } = string.Empty;
}
