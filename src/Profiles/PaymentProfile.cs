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
            InstallmentMapper();
            CardMapper();
            MonthMapper();
            YearMapper();
        }

        private void InstallmentMapper() 
        {
            CreateMap<CreateInstallmentDto, Installment>();
            CreateMap<Installment, ReadInstallementDto>();
        }

        private void CardMapper() 
        {
            CreateMap<CreateCardDto, Card>();
            CreateMap<Card, ReadCardDto>().ForMember(c => c.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<UpdateCardDto, Card>();
        }
        
        private void MonthMapper() 
        {
            CreateMap<Month, ReadMonthDto>();
        }

        private void YearMapper() 
        {
            CreateMap<Year, ReadYearDto>();
        }
    }
}