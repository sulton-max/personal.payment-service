using Newtonsoft.Json;

namespace PaypalPayment.Models;

public class PurchaseItem
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("quantity")]
    public string Quantity { get; set; }
    [JsonProperty("unit_amount")]
    public Amount UnitAmount { get; set; }
}