namespace ExchangeRate.Domain.ExchangeRates;

public record CurrencyPair
{
    public static readonly CurrencyPair EurUsd = new("EURUSD");
    public static readonly CurrencyPair UsdJpy = new("USDJPY");
    public static readonly CurrencyPair BtcUsd = new("BTCUSD");
    private CurrencyPair(string code) => Code = code;
    public string Code { get; init; }

    public static CurrencyPair FromCode(string code)
    {
        return All.FirstOrDefault(c => c.Code.Equals(code)) ??
            throw new ApplicationException("The currency code is invalid");
    }

    public static readonly IReadOnlyCollection<CurrencyPair> All = new[]
    {
        EurUsd,
        UsdJpy,
        BtcUsd
    };
}
