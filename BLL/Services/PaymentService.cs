using PaypalPayment.Services.Interfaces;

namespace PaypalPayment.Services;

public class PaymentService : IPaymentService
{
    public Task CreatePayoutAsync()
    {
        throw new NotImplementedException();
    }

    public Task GetPayoutByIdAsync()
    {
        throw new NotImplementedException();
    }

    public Task GetPayoutItemByIdAsync()
    {
        throw new NotImplementedException();
    }

    public Task CancelUnclaimedPayoutItemByIdAsync()
    {
        throw new NotImplementedException();
    }
}