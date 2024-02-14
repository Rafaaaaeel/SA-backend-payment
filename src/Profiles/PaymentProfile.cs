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
            CreateMap<InstallmentRequest, Installment>();
        }

        private void CardMapper() 
        {
            CreateMap<CardRequest, Card>();
            CreateMap<Card, CardResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Months, opt => opt.MapFrom(src => MappingMonths(src.Months)));
        }
        
        private void MonthMapper() 
        {
            CreateMap<Month, MonthResponse>();
        }

        private void YearMapper() 
        {
            CreateMap<Year, ReadYearDto>();
        }

        private IEnumerable<MonthResponse> MappingMonths(IEnumerable<Month> months) 
        {
            return months.Select(m => new MonthResponse { Name = m.Name, Years = MappingYears(m.Year)});
        }

        private IEnumerable<YearResponse> MappingYears(IEnumerable<Year> years)
        {
            return years.Select(y => new YearResponse 
            {
                Name = y.Name,
                Quantity = y.Quantity,
                Total = y.Total,
                Installments = MappingInstallments(y.Installments)
            });
        }

        private IEnumerable<InstallmentResponse> MappingInstallments(IEnumerable<Installment> installments)
        {
            return installments.Select(i => new InstallmentResponse 
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description,
                Value = i.Value,
                Total = i.Total,
                Quantity = i.Quantity
            });
        }
    }
}