using PaypalPayment.Models.Common;

namespace PaypalPayment.Models.Payout;

public class PayoutItem
{
    public string RecipientType { get; set; }
    
    public string SenderItemId { get; set; }

    public string Receiver { get; set; }
    
    public string Note { get; set; }

    public Amount Amount { get; set; }
}