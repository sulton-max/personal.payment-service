namespace PaypalPayment.Services.Interfaces;

public interface IPaymentService
{
    #region Payout

    Task CreatePayoutAsync();

    Task GetPayoutByIdAsync();

    Task GetPayoutItemByIdAsync();

    Task CancelUnclaimedPayoutItemByIdAsync();

    #endregion
}