using PaypalPayment.Models.Enums;

namespace PaypalPayment.Models.Common;

public class PaymentError
{
    public string Name { get; set; }
    public string Message { get; set; }
    public PaymentProvider Provider { get; set; }
    public string ErrorModel { get; set; }
}