using Newtonsoft.Json;
using PaypalPayment.PaymentProviders.PayPal.Models.Common;

namespace PaypalPayment.PaymentProviders.PayPal.Models.Payout;

public class PayPalPayout : IPayPalRequestModel
{
    [JsonProperty("sender_batch_header")]
    public PayPalBatchHeader SenderBatchHeader { get; set; }
    
    [JsonProperty("items")]
    public IEnumerable<PayPalPayoutItem> Items { get; set; }
}