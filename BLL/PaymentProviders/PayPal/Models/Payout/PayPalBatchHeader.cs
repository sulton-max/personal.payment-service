using Newtonsoft.Json;
using PaypalPayment.PaymentProviders.PayPal.Models.Common;

namespace PaypalPayment.PaymentProviders.PayPal.Models.Payout;

public class PayPalBatchHeader
{
    [JsonProperty("payout_batch_id")]
    public string PayoutBatchId { get; set; }
    
    [JsonProperty("sender_batch_id")]
    public string SenderBatchId { get; set; }

    [JsonProperty("batch_status")]
    public string BatchStatus { get; set; }
    
    [JsonProperty("time_created")]
    public DateTime CreatedTime { get; set; }
    
    [JsonProperty("time_completed")]
    public DateTime CompletedTime { get; set; }
    
    [JsonProperty("sender_batch_header")]
    public PayPalBatchHeader SenderBatchHeader { get; set; }
    
    [JsonProperty("funding_source")]
    public string FundingResource { get; set; }
    
    [JsonProperty("amount")]
    public PayPalAmount Amount { get; set; }
    
    [JsonProperty("fees")]
    public PayPalFee Fees { get; set; }
    
    [JsonProperty("email_subject")]
    public string EmailSubject { get; set; }
    
    [JsonProperty("email_message")]
    public string EmailMessage { get; set; }
}