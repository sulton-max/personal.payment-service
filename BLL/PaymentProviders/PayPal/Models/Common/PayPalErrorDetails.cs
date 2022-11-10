using Newtonsoft.Json;

namespace PaypalPayment.PaymentProviders.PayPal.Models.Common;

public class PayPalErrorDetails
{
    [JsonProperty("field")]
    public string Field { get; set; }
    
    [JsonProperty("location")]
    public string Location { get; set; }
    
    [JsonProperty("issue")]
    public string Issue { get; set; }
}