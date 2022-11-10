using AutoMapper;
using PaypalPayment.Models.Common;
using PaypalPayment.PaymentProviders.PayPal.Models.Common;

namespace PaypalPayment.MappingProfiles;

public class AmountProfile : Profile
{
    public AmountProfile()
    {
        // PayPal mapping
        CreateMap<PayPalAmount, Amount>();
        CreateMap<Amount, PayPalAmount>();
    }
    
}