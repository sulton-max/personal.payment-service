using AutoMapper;
using PaypalPayment.Models.Payout;
using PaypalPayment.PaymentProviders.PayPal.Models.Payout;

namespace PaypalPayment.MappingProfiles;

public class PayoutItemProfile : Profile
{
    public PayoutItemProfile()
    {
        CreateMap<PayPalPayoutItem, PayoutItem>();
        CreateMap<PayoutItem, PayPalPayoutItem>();
    }
}