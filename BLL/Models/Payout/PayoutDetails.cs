namespace PaypalPayment.Models.Payout;

public class PayoutDetails
{
    public BatchHeader BatchHeader { get; set; }
    public IEnumerable<PayoutItemDetails> Items { get; set; }
}