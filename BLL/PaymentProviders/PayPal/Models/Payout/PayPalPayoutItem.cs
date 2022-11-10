using Newtonsoft.Json;
using PaypalPayment.PaymentProviders.PayPal.Models.Common;

namespace PaypalPayment.PaymentProviders.PayPal.Models.Payout;

public class PayPalPayoutItem
{
    [JsonProperty("recipient_type")]
    public string RecipientType { get; set; }
    
    [JsonProperty("amount")]
    public PayPalAmount Amount { get; set; }
    
    [JsonProperty("note")]
    public string Note { get; set; }
    
    [JsonProperty("receiver")]
    public string Reciever { get; set; }
    
    [JsonProperty("sender_item_id")]
    public string SenderItemId { get; set; }
    
    [JsonProperty("recipient_wallet")]
    public string RecipientWallet { get; set; }
    
    [JsonProperty("notification_language")]
    public string NotificationLanguage { get; set; }
}