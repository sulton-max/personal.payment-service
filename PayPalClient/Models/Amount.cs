using Newtonsoft.Json;

namespace PaypalPayment.Models;

public class Amount
{
    [JsonProperty("currency_code")]
    public string CurrencyCode { get; set; }
    [JsonProperty("value")]
    public string Value { get; set; }
    [JsonProperty("breakdown")]
    public AmountBreakdown? Breakdown { get; set; }
}