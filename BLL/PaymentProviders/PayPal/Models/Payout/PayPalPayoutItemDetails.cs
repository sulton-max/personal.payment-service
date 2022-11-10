using Newtonsoft.Json;
using PaypalPayment.Models.Payout;
using PaypalPayment.PaymentProviders.PayPal.Models.Common;

namespace PaypalPayment.PaymentProviders.PayPal.Models.Payout;

public class PayPalPayoutItemDetails
{
    [JsonProperty("payout_item_id")]
    public string PayoutItemId { get; set; }

    [JsonProperty("transaction_id")]
    public string TransactionId { get; set; }
    
    [JsonProperty("activity_id")]
    public string ActivityId { get; set; }
    
    [JsonProperty("transaction_status")]
    public string TransactionStatus { get; set; }
    
    [JsonProperty("payout_item_fee")]
    public PayPalFee PayoutItemPayPalFee { get; set; }
    
    [JsonProperty("payout_batch_id")]
    public string PayoutBatchId { get; set; }
    
    [JsonProperty("sender_batch_id")]
    public string SenderBatchId { get; set; }
    
    [JsonProperty("payout_item")]
    public PayPalPayoutItem PayoutItem { get; set; }
    
    [JsonProperty("time_processed")]
    public DateTime ProcessedTime { get; set; }
    
    [JsonProperty("errors")]
    public PayPalPaymentError PaymentErrors { get; set; }
    
    [JsonProperty("links")]
    public IEnumerable<ResourceLink> Links { get; set; }
}