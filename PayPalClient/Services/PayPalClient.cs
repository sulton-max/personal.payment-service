using System.Net;
using System.Net.Security;
using PaypalPayment.Models;
using PaypalPayment.Services.Interfaces;

namespace PaypalPayment.Services;

public class PayPalClient : IPayPalClient
{
    private PayPalOptions Options { get; }
    private HttpClient HttpClient { get; }

    public PayPalClient(PayPalOptions options)
    {
        Options = options;
        HttpClient = PayPalConfiguration.CreateBaseClient(options);
    }

    #region Orders

    public async Task<OrderResponse?> CreateOrderAsync(OrderRequest request)
    {
        if (request == null)
            throw new InvalidOperationException();

        return await Task.Run(async () =>
        {
            var httpRequest = request.CreateBaseRequest();
            return await (await httpRequest.SendRequestAsync(HttpMethod.Post, HttpClient, Options))
                .ConvertResponse<OrderResponse>();
        });
    }

    #endregion

    #region Errors

    #endregion
}