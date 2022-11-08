using PaypalPayment.Models;

namespace PaypalPayment.Services.Interfaces;

public interface IPayPalClient
{
    Task<OrderResponse> CreateOrderAsync(OrderRequest request);
}