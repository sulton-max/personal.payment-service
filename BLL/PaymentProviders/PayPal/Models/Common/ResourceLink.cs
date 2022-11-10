using Newtonsoft.Json;

namespace PaypalPayment.PaymentProviders.PayPal.Models.Common;

public class ResourceLink
{
    [JsonProperty("href")]
    public string Link { get; set; }
    
    [JsonProperty("rel")]
    public string Relation { get; set; }
    
    [JsonProperty("method")]
    public string HttpMethod { get; set; }
    
    [JsonProperty("application/json")]
    public string EncryptionType { get; set; }
}