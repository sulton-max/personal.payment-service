using PaypalPayment.Models.Common;

namespace PaypalPayment.Models.Payout;

public class BatchHeader
{
    public string SenderBatchId { get; set; }
    public string BatchStatus { get; set; }
    public string EmailSubject { get; set; }
    public string EmailMessage { get; set; }
    public BatchHeader SenderBatchHeader { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime CompletedTime { get; set; }
    public Amount Amount { get; set; }
}