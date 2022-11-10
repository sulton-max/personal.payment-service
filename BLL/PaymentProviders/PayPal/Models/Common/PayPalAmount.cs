using Newtonsoft.Json;

namespace PaypalPayment.PaymentProviders.PayPal.Models.Common;

public class PayPalAmount
{
    [JsonProperty("currency_code")]
    public string CurrencyCode { get; set; }
    [JsonProperty("value")]
    public string Value { get; set; }
    [JsonProperty("breakdown")]
    public AmountBreakdown? Breakdown { get; set; }
}