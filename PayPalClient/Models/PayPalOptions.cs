namespace PaypalPayment.Models;

public class PayPalOptions
{
    public PayPalOptions(
        string baseUrl,
        string accessToken,
        TimeSpan? timeOut = null,
        bool throwExceptionIfFails = false
    )
    {
        BaseUrl = baseUrl;
        TimeOut = timeOut ?? TimeSpan.FromSeconds(10);
        AccessToken = accessToken;
        ThrowExceptionIfFails = throwExceptionIfFails;
    }

    public string BaseUrl { get; }
    public TimeSpan TimeOut { get; }
    public string AccessToken { get; }
    public bool ThrowExceptionIfFails { get; }
}