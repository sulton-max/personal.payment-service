using AutoMapper;
using PaypalPayment.Models.Payout;
using PaypalPayment.PaymentProviders.PayPal.Models.Payout;

namespace PaypalPayment.MappingProfiles;

public class PayoutProfile : Profile
{
    public PayoutProfile()
    {
        CreateMap<PayPalPayout, Payout>();
        CreateMap<Payout, PayPalPayout>();
    }
}