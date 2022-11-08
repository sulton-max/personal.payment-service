using System.Net.Http.Headers;
using Newtonsoft.Json;
using PaypalPayment.Models;

namespace PaypalPayment.Services;

public static class PayPalConfiguration
{
    public static PayPalClient GetClient(PayPalOptions options)
    {
        var client = new PayPalClient(options);
        return client;
    }

    internal static HttpClient CreateBaseClient(this PayPalOptions options)
    {
        // Create client and set basic configurations
        var client = new HttpClient();
        client.BaseAddress = new Uri(options.BaseUrl);
        client.Timeout = options.TimeOut;

        // Add headers
        var headers = client.DefaultRequestHeaders;

        headers.Authorization = new AuthenticationHeaderValue(
            $"Bearer {options.AccessToken}");
        headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip, deflate, br"));
        headers.Connection.Add("gzip, deflate, br");
        headers.Add("Prefer", "return=representation");

        // TODO : Remove these headers
        headers.UserAgent.Add(new ProductInfoHeaderValue(new ProductHeaderValue("PostmanRuntime/7.29.2")));
        headers.Add("PayPal-Request-Id", Guid.NewGuid().ToString());

        return client;
    }

    internal static HttpRequestMessage GetBaseRequest()
    {
        // Create http request message
        var request = new HttpRequestMessage();
        return request;
    }

    internal static HttpRequestMessage CreateBaseRequest(this IPayPalRequest request)
    {
        var httpRequest = GetBaseRequest();
        httpRequest.Content = request.CreateBaseContent();
        return httpRequest;
    }
    
    internal static HttpContent CreateBaseContent(this IPayPalRequest request)
    {
        var requestContent = new StringContent(JsonConvert.SerializeObject(request)) as HttpContent;
        requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        return requestContent;
    }
}