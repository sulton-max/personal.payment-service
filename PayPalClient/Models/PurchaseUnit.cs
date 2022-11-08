using Newtonsoft.Json;

namespace PaypalPayment.Models;

public class PurchaseUnit
{
    [JsonProperty("items")]
    public IEnumerable<PurchaseItem> Items { get; set; }
    [JsonProperty("amount")]
    public Amount Amount { get; set; }
}
