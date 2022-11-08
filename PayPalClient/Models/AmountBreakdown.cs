using Newtonsoft.Json;

namespace PaypalPayment.Models;

public class AmountBreakdown
{
    [JsonProperty("item_total")]
    public Amount ItemTotal { get; set; } 
}