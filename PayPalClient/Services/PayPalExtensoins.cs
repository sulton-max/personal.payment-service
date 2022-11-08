using System.Net;
using Newtonsoft.Json;
using PaypalPayment.Models;

namespace PaypalPayment.Services;

public static class PayPalExtensions
{
    internal static async Task<HttpResponseMessage> SendRequestAsync(
        this HttpRequestMessage request,
        HttpMethod method,
        HttpClient client,
        PayPalOptions options
    )
    {
        var response = null as HttpResponseMessage;
        request.Method = method;
        try
        {
            response = await client.SendAsync(request);
        }
        catch (Exception exception)
        {
            HandleException(exception, options);
        }

        return response;
    }

    internal static async Task<TResponse?> ConvertResponse<TResponse>(this HttpResponseMessage response) where 
    TResponse 
    : class
    {
        if (!response.IsSuccessStatusCode)
            return null;

        return await Task.Run(async () =>
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            return !string.IsNullOrWhiteSpace(responseContent)
                ? JsonConvert.DeserializeObject<TResponse>(responseContent)
                : null;
        });
    }

    internal static void HandleException(Exception exception, PayPalOptions options)
    {
        if (options.ThrowExceptionIfFails)
            throw exception;
    }
}