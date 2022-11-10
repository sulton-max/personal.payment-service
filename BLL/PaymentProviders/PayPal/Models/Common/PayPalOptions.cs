namespace PaypalPayment.PaymentProviders.PayPal.Models.Common;

public class PayPalOptions
{
    public PayPalOptions(
        string baseUri,
        string accessToken,
        TimeSpan? timeOut,
        bool throwExceptionIfFails
    )
    {
        BaseUri = new Uri(baseUri);
        TimeOut = timeOut ?? TimeSpan.FromSeconds(10);
        AccessToken = accessToken;
        ThrowExceptionIfFails = throwExceptionIfFails;
    }

    public Uri BaseUri { get; }
    public TimeSpan TimeOut { get; }
    public string AccessToken { get; }
    public bool ThrowExceptionIfFails { get; }
}