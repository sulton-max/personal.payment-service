using System.Net.Http.Headers;
using Newtonsoft.Json;
using PaypalPayment.PaymentProviders.PayPal.Models.Common;

namespace PaypalPayment.PaymentProviders.PayPal;

public static class PayPalConfiguration
{
    #region Urls

    public const string OrderUrl = "v2/checkout/orders";

    // Payout
    public const string BatchPayoutUrl = "v1/payments/payouts";
    public const string BatchPayoutDetailsUrl = "v1/payments/payouts/{0}";
    public const string PayoutItemDetailsUrl = "v1/payments/payouts-item/{0}";
    public const string CancelUnclaimedPayoutItemUrl = "v1/payments/payouts-item/{0}/cancel";

    #endregion

    public static PayPalOptions GetOptions(string baseUrl, string accessToken)
    {
        var options = new PayPalOptions(baseUrl, accessToken, TimeSpan.FromSeconds(10), false);
        return options;
    }

    public static PayPalClient GetClient(PayPalOptions options)
    {
        var client = new PayPalClient(options);
        return client;
    }

    internal static HttpClient CreateBaseClient(this PayPalOptions options)
    {
        // Create client and set basic configurations
        var client = new HttpClient();
        client.BaseAddress = options.BaseUri;
        client.Timeout = options.TimeOut;

        // Add headers
        var headers = client.DefaultRequestHeaders;

        headers.Authorization = new AuthenticationHeaderValue("Bearer", options.AccessToken);
        headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
        headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
        headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("br"));
        headers.Connection.Add("keep-alive");
        headers.Add("Prefer", "return=representation");

        return client;
    }

    internal static HttpRequestMessage GetBaseRequest(HttpMethod method, PayPalOptions options, string url)
    {
        // Create http request message
        var request = new HttpRequestMessage(method, new Uri(options.BaseUri, url));
        return request;
    }

    internal static HttpRequestMessage CreateBaseRequest(
        this IPayPalRequestModel requestModel,
        HttpMethod method,
        PayPalOptions options,
        string url
    )
    {
        var httpRequest = GetBaseRequest(method, options, url);
        httpRequest.Content = requestModel.CreateBaseContent();
        return httpRequest;
    }

    internal static HttpContent CreateBaseContent(this IPayPalRequestModel requestModel)
    {
        var requestContent = new StringContent(JsonConvert.SerializeObject(requestModel)) as HttpContent;
        requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        return requestContent;
    }
}