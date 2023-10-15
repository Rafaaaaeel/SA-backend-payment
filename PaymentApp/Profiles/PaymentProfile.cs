using AutoMapper;
using PaymentApp.Dto.Create;
using PaymentApp.Models;

namespace PaymentApp.Profiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<CreatePaymentDto, Payment>();
            CreateMap<CreateInstallmentDto, Installment>();
        }
    }
}