using AutoMapper;
using Microsoft.VisualBasic;
using PaymentApp.Dto.Card;
using PaymentApp.Dto.Installment;
using PaymentApp.Models;

namespace PaymentApp.Profiles
{
    public class PaymentProfile : Profile
    {

        public PaymentProfile()
        {
            
            CreateMap<CreateCardDto, Card>();
            CreateMap<CreateInstallmentDto, Installment>();
            CreateMap<Card, ReadCardDto>().ForMember(c => c.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<UpdateCardDto, Card>();
            CreateMap<Month, ReadMonthDto>();
            CreateMap<Installment, ReadInstallementDto>();
            CreateMap<Year, ReadYearDto>();
        }

        private void InstallmentMapper() 
        {

        }

        private void CardMapper() 
        {
            
        }

    }
}