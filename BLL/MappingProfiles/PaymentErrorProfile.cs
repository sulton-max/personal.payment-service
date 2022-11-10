using AutoMapper;
using PaypalPayment.Models.Common;
using PaypalPayment.Models.Enums;
using PaypalPayment.PaymentProviders.PayPal.Models.Common;

namespace PaypalPayment.MappingProfiles;

public class PaymentErrorProfile : Profile
{
    public PaymentErrorProfile()
    {
        // PayPal mapping
        CreateMap<PayPalPaymentError, PaymentError>()
            .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => PaymentProvider.PayPal));
        CreateMap<PaymentError, PayPalPaymentError>();
    }
}