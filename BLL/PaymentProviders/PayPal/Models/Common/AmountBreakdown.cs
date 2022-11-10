using Newtonsoft.Json;

namespace PaypalPayment.PaymentProviders.PayPal.Models.Common;

public class AmountBreakdown
{
    [JsonProperty("item_total")]
    public PayPalAmount ItemTotal { get; set; } 
}