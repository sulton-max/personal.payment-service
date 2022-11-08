using Newtonsoft.Json;

namespace PaypalPayment.Models;

public class ApplicationContext
{
    [JsonProperty("return_url")]
    public string ReturnURL { get; set; }
    [JsonProperty("cancel_url")]
    public string CancelURL { get; set; }
}