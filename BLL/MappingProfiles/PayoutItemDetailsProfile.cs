using AutoMapper;
using PaypalPayment.Models.Payout;
using PaypalPayment.PaymentProviders.PayPal.Models.Payout;

namespace PaypalPayment.MappingProfiles;

public class PayoutItemDetailsProfile : Profile
{
    public PayoutItemDetailsProfile()
    {
        // PayPal mapping 
        CreateMap<PayPalPayoutItemDetails, PayoutItemDetails>();
        CreateMap<PayoutItemDetails, PayPalPayoutItemDetails>();
    }
}