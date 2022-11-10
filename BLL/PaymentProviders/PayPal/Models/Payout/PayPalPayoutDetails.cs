using Newtonsoft.Json;
using PaypalPayment.PaymentProviders.PayPal.Models.Common;

namespace PaypalPayment.PaymentProviders.PayPal.Models.Payout;

public class PayPalPayoutDetails
{
    [JsonProperty("batch_header")]
    public PayPalBatchHeader PayPalBatchHeader { get; set; }
    
    [JsonProperty("items")]
    public IEnumerable<PayPalPayoutItemDetails> Items { get; set; }
    
    [JsonProperty("links")]
    public IEnumerable<ResourceLink> Links { get; set; }
}