using Newtonsoft.Json;

namespace PaypalPayment.PaymentProviders.PayPal.Models.Common;

public class PayPalFee
{
    [JsonProperty("currency")]
    public string Currency { get; set; }
    [JsonProperty("value")]
    public string Value { get; set; }
}