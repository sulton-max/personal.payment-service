using PaypalPayment.PaymentProviders.PayPal.Models.Common;
using PaypalPayment.PaymentProviders.PayPal.Models.Payout;

namespace PaypalPayment.PaymentProviders.PayPal;

public class PayPalClient
{
    private PayPalOptions Options { get; }
    private HttpClient HttpClient { get; }

    public PayPalClient(PayPalOptions options)
    {
        Options = options;
        HttpClient = PayPalConfiguration.CreateBaseClient(options);
    }

    // #region Orders
    //
    // public async Task<OrderResponse?> CreateOrderAsync(OrderRequestModel requestModel)
    // {
    //     if (requestModel == null)
    //         throw new InvalidOperationException();
    //
    //     return await Task.Run(async () =>
    //     {
    //         var httpRequest = requestModel.CreateBaseRequest(HttpMethod.Post, Options, PayPalConfiguration.OrderUrl);
    //         var httpResponse = await httpRequest.SendRequestAsync(HttpClient, Options);
    //         var response = await httpResponse.ConvertResponse<OrderResponse>();
    //
    //         return response;
    //     });
    // }
    //
    // #endregion
    
    #region Payouts

    public async Task<(PayPalPayoutDetails? response, PayPalPaymentError? error)> CreateBatchPayoutAsync(PayPalPayout model)
    {
        if (model == null)
            throw new InvalidOperationException();

        return await Task.Run(async () =>
        {
            var requestUrl = PayPalConfiguration.BatchPayoutUrl;
            var httpRequest = model.CreateBaseRequest(HttpMethod.Post, Options, requestUrl);
            var httpResponse = await httpRequest.SendRequestAsync(HttpClient, Options);
            var response = await httpResponse.ConvertResponse<PayPalPayoutDetails>();

            return response;
        });
    }

    public async Task<(PayPalPayoutDetails? response, PayPalPaymentError? error)> GetBatchPayoutByIdAsync(string id)
    {
        if(string.IsNullOrWhiteSpace(id))
            throw new InvalidOperationException();

        return await Task.Run(async () =>
        {
            var requestUrl = string.Format(PayPalConfiguration.BatchPayoutDetailsUrl, id);
            var httpRequest = PayPalConfiguration.GetBaseRequest(HttpMethod.Post, Options, requestUrl);
            var httpResponse = await httpRequest.SendRequestAsync(HttpClient, Options);
            var response = await httpResponse.ConvertResponse<PayPalPayoutDetails>();

            return response;
        });
    }

    public async Task<(PayPalPayoutItemDetails? response, PayPalPaymentError? error)> GetPayoutItemByIdAsync(string id)
    {
        if(string.IsNullOrWhiteSpace(id))
            throw new InvalidOperationException();

        return await Task.Run(async () =>
        {
            var requestUrl = string.Format(PayPalConfiguration.PayoutItemDetailsUrl, id);
            var httpRequest = PayPalConfiguration.GetBaseRequest(HttpMethod.Post, Options, PayPalConfiguration.OrderUrl);
            var httpResponse = await httpRequest.SendRequestAsync(HttpClient, Options);
            var response = await httpResponse.ConvertResponse<PayPalPayoutItemDetails>();

            return response;
        });
    }

    public async Task<(PayPalPayoutItemDetails? response,  PayPalPaymentError? error)> CancelUnclaimedPayoutItemById(string id)
    {
        if(string.IsNullOrWhiteSpace(id))
            throw new InvalidOperationException();

        return await Task.Run(async () =>
        {
            var requestUrl = string.Format(PayPalConfiguration.CancelUnclaimedPayoutItemUrl, id);
            var httpRequest = PayPalConfiguration.GetBaseRequest(HttpMethod.Post, Options, PayPalConfiguration.OrderUrl);
            var httpResponse = await httpRequest.SendRequestAsync(HttpClient, Options);
            var response = await httpResponse.ConvertResponse<PayPalPayoutItemDetails>();

            return response;
        });
    }
    
    #endregion 
}