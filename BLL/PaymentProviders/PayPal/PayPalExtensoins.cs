using Newtonsoft.Json;
using PaypalPayment.PaymentProviders.PayPal.Models.Common;

namespace PaypalPayment.PaymentProviders.PayPal;

public static class PayPalExtensions
{
    internal static async Task<HttpResponseMessage> SendRequestAsync(
        this HttpRequestMessage request,
        HttpClient client,
        PayPalOptions options
    )
    {
        var response = null as HttpResponseMessage;
        try
        {
            response = await client.SendAsync(request);
        }
        catch (Exception exception)
        {
            HandleException(exception, options);
        }

        return response ?? throw new InvalidOperationException();
    }

    internal static async Task<(TResponse?, PayPalPaymentError?)> ConvertResponse<TResponse>(this HttpResponseMessage response) where 
    TResponse 
    : class
    {
        if (response == null)
            return (null, null);
 
        return await Task.Run(async () =>
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            return !string.IsNullOrWhiteSpace(responseContent)
                ? response.IsSuccessStatusCode 
                    ? (JsonConvert.DeserializeObject<TResponse>(responseContent), null)
                    : (null as TResponse, JsonConvert.DeserializeObject<PayPalPaymentError>(responseContent))
                : (null as TResponse, null);
        });
    }

    internal static void HandleException(Exception exception, PayPalOptions options)
    {
        if (options.ThrowExceptionIfFails)
            throw exception;
    }
}