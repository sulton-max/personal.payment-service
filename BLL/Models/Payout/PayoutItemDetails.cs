using PaypalPayment.Models.Common;

namespace PaypalPayment.Models.Payout;

public class PayoutItemDetails
{
    public string PayoutItemId { get; set; }

    public string TransactionStatus { get; set; }
    
    public string PayoutBatchId { get; set; }
    
    public string SenderBatchId { get; set; }
    
    public PayoutItem PayoutItem { get; set; }
    
    public PaymentError PaymentErrors { get; set; }
}