using AutoMapper;
using PaymentApp.Dto.Installment;
using PaymentApp.Models;

using Sa.Payment.Api.Request;
using Sa.Payment.Api.Response;

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
            CreateMap<CardRequest, Card>();
            CreateMap<Card, CardResponse>().ForMember(c => c.Id, opt => opt.MapFrom(src => src.Id));
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