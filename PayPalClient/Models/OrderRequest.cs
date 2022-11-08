using Newtonsoft.Json;

namespace PaypalPayment.Models;

public class OrderRequest : IPayPalRequest
{
    [JsonProperty("intent")]
    public string Intent { get; set; }
    [JsonProperty("purchase_units")]
    public IEnumerable<PurchaseUnit> PurchaseUnits { get; set; }
    [JsonProperty("application_context")]
    public ApplicationContext ApplicationContext { get; set; }
}