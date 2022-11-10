using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaypalPayment.Models;
using PaypalPayment.PaymentProviders.PayPal;
using PaypalPayment.PaymentProviders.PayPal.Models.Common;
using PaypalPayment.PaymentProviders.PayPal.Models.Payout;
using PaypalPayment.Services;
using PayoutItemDetails = PaypalPayment.Models.Payout.PayoutItemDetails;

namespace API.Controllers;

public class PayoutController : CustomControllerBase
{
    private readonly IWebHostEnvironment _environment;
    private string _accessToken =
        "A21AAKcyLoboloBiskjro2zZ585JSfqwujnrgLjVCmVqEeS96-OkU97WRxoMSd0a8iMZobchpaq5TL95chaSAljzWcD6ZXisA";
    private string _baseUrl = "https://api-m.sandbox.paypal.com";
    private readonly PayPalOptions _options;
    private readonly PayPalClient _client;

    public PayoutController(IWebHostEnvironment environment)
    {
        _environment = environment;
        
        _options = PayPalConfiguration.GetOptions(_baseUrl, _accessToken);
        _client = PayPalConfiguration.GetClient(_options);
    }

    private TObject GetData<TObject>(string filepath)
    {
        var file = new FileInfo(Path.Combine(_environment.ContentRootPath, "DumpData", filepath));
        var buffer = new byte[file.Length];
        var stream = file.OpenRead();
        stream.Read(buffer);
        var content = Encoding.UTF8.GetString(buffer.ToArray());
        var body = JsonConvert.DeserializeObject<TObject>(content) ?? throw new 
            InvalidOperationException();

        return body;
    }

    [HttpPost("batch")]
    public async Task<ActionResult<PayPalPayout>> CreateBatchPayout()
    {
        var body = GetData<PayPalPayout>("batchPayout.json");
        var result = await _client.CreateBatchPayoutAsync(body);

        if (result.response == null)
            return Ok(result.error);
        else return Ok(result.response);
    }

    [HttpGet("batch/{id}")]
    public async Task<ActionResult<PayPalPayoutDetails>> GetBatchPayoutById([FromRoute] string id)
    {
        var result = await _client.GetBatchPayoutByIdAsync(id);
        if (result.response == null)
            return Ok(result.error);
        else return Ok(result.response);
    }

    [HttpGet("item/{id}")]
    public async Task<ActionResult<PayoutItemDetails>> GetPayoutItemById([FromRoute]string id)
    {
        var result = await _client.GetPayoutItemByIdAsync(id);
        if (result.response == null)
            return Ok(result.error);
        else return Ok(result.response);
    }

    [HttpPost("item/cancel/{id}")]
    public async Task<ActionResult<PayoutItemDetails>> CancelUnclaimedPayoutItemById(string id)
    {
        var result = await _client.CancelUnclaimedPayoutItemById(id);
        if (result.response == null)
            return Ok(result.error);
        else return Ok(result.response);
    }
}