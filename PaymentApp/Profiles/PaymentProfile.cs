using AutoMapper;
using PaymentApp.Dto.Create;
using PaymentApp.Dto.Read;
using PaymentApp.Models;

namespace PaymentApp.Profiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<ReadDataDto, Card>();
            CreateMap<CreateCardDto, Card>();
            CreateMap<CreateInstallmentDto, Installment>();
            CreateMap<Card, ReadPaymentDto>();
        }
    }
}