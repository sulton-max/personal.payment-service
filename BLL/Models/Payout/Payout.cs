namespace PaypalPayment.Models.Payout;

public class Payout
{
    public BatchHeader SenderBatchHeader { get; set; }
    
    public IEnumerable<PayoutItem> Items { get; set; }
}