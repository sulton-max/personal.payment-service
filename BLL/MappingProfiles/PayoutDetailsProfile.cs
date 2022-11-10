using AutoMapper;
using PaypalPayment.Models.Payout;
using PaypalPayment.PaymentProviders.PayPal.Models.Payout;

namespace PaypalPayment.MappingProfiles;

public class PayoutDetailsProfile : Profile
{
    public PayoutDetailsProfile()
    {
        // PayPal mapping
        CreateMap<PayPalPayoutDetails, PayoutDetails>();
        CreateMap<PayoutDetails, PayPalPayoutDetails>();
    }
}