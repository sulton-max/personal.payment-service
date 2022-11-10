// using Newtonsoft.Json;
//
// namespace PaypalPayment.Models;
//
// public class OrderResponse
// {
//     [JsonProperty("id")]
//     public string Id { get; set; }
//     [JsonProperty("intent")]
//     public string Intent { get; set; }
//     [JsonProperty("status")]
//     public string Status { get; set; }
//     [JsonProperty("purchase_units")]
//     public IEnumerable<PurchaseUnit> PurchaseUnits { get; set; }
//     [JsonProperty("create_time")]
//     public DateTime CreatedTime { get; set; }
//     [JsonProperty("links")]
//     public IEnumerable<ResourceLink> Links { get; set; }
// }