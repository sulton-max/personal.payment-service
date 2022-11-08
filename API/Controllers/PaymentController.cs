using System.Text;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.IO;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using PaypalPayment.Models;
using PaypalPayment.Services;

namespace API.Controllers;

public class PaymentController : CustomControllerBase
{
    private readonly IWebHostEnvironment _environment;

    public PaymentController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // var client = new HttpClient();
        // var request = new HttpRequestMessage(HttpMethod.Post, "https://api-m.sandbox.paypal.com/v2/checkout/orders");

        var baseUrl = "https://api-m.sandbox.paypal.com";
        var accessToken =
            "A21AALaasjEiak3gRTdv-LkCRFc1G269RMTLFt43nek3mzAriRasPytWv3ih0zsDi10A_LSVI7qG6PXqsJCmmThTdMtZm3XBQ";
        
        var options = new PayPalOptions(baseUrl, accessToken);
        var client = PayPalConfiguration.GetClient(options);
        
        var file = new FileInfo(Path.Combine(_environment.ContentRootPath, "DumpData", "order.json"));
        var buffer = new byte[file.Length];
        var stream = file.OpenRead();
        stream.Read(buffer);

        var content = Encoding.UTF8.GetString(buffer.ToArray());
        var body = JsonConvert.DeserializeObject<OrderRequest>(content) ?? throw new 
        InvalidOperationException();
       
        var requestContent = new StringContent(JsonConvert.SerializeObject(body)) as HttpContent;

        var response = await client.CreateOrderAsync(body);
            
        // request.Content = requestContent;
        //
        // var response = await client.SendAsync(request);
        //
        // var renseContent = await response.Content.ReadAsStringAsync();
        // return Ok(responseContent);

        return Ok();
    }

    // public void GetToken()
    // {
    //     var clientId = "AUv8rrc_P-EbP2E0mpb49BV7rFt3Usr-vdUZO8VGOnjRehGHBXkSzchr37SYF2GNdQFYSp72jh5QUhzG";
    //     var clientId64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(clientId));
    //     var clientSecret = "EMnAWe06ioGtouJs7gLYT9chK9-2jJ--7MKRXpI8FesmY_2Kp-d_7aCqff7M9moEJBvuXoBO4clKtY0v";
    //
    //     var authToken = $"Basic {clientId64}:{clientSecret}";
    // }
}