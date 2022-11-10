using AutoMapper;
using PaypalPayment.Models.Payout;
using PaypalPayment.PaymentProviders.PayPal.Models.Payout;

namespace PaypalPayment.MappingProfiles;

public class BatchHeaderProfile : Profile
{
    public BatchHeaderProfile()
    {
        // PayPal mapping
        CreateMap<PayPalBatchHeader, BatchHeader>();
        CreateMap<BatchHeader, PayPalBatchHeader>();
    }
}