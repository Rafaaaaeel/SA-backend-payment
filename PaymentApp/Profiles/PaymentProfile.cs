using AutoMapper;
using PaymentApp.Dto.Card;
using PaymentApp.Dto.Installment;
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
            CreateMap<Card, ReadCardDto>();
            CreateMap<UpdateCardDto, Card>();
        }
    }
}