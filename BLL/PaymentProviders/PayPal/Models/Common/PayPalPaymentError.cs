using Newtonsoft.Json;

namespace PaypalPayment.PaymentProviders.PayPal.Models.Common;

public class PayPalPaymentError
{
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("message")]
    public string Message { get; set; }
    
    [JsonProperty("debug_id")]
    public string DebugId { get; set; }
    
    [JsonProperty("details")]
    public IEnumerable<PayPalErrorDetails> Details { get; set; }

    [JsonProperty("information_link")]
    public string InformationLink { get; set; }
}