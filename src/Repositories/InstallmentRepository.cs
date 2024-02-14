namespace Sa.Payment.Api.Repositories;

public class InstallmentsRepository : IInstallmentsRepository
{
    private readonly CardContext _context;
    private readonly IMapper _mapper;

    public InstallmentsRepository(CardContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task CreateInstallmentForCard(InstallmentRequest request, int id)
    {
        Installment installment = _mapper.Map<Installment>(request);

        Card? card = await _context.QueryCardById(id);

        if (card is null) throw new NotFoundException();
        
        AppendTotalToCard(card, installment);

        await CreateInstallmentForEachMonth(request.Quantity, request.Date ?? DateTime.Now, card, installment);

        await Save();
    }

    public async Task<Installment> GetInstallment(int id) 
    {
        Installment? installment = await _context.Installment.FirstOrDefaultAsync(i => i.Id == id);

        if (installment is null) throw new NotFoundException();

        return installment;
    }
    
    private async Task CreateInstallmentForEachMonth(int quantity, DateTime time, Card card, Installment installment)
    {
        for (int index = 0; index < quantity; index++)
        {
            DateTime currentMonth = time.AddMonths(index);
            string monthName = currentMonth.GetMonthAbbreviatedName();
            string yearName = currentMonth.Year.ToString();
            Month? month = card.Months.FirstOrDefault(m => m.Name == monthName);
            
            await CreateMonth(month, installment, yearName, monthName, card);
        }
    }

    private async Task CreateMonth(Month? month, Installment installment, string yearName, string monthName, Card card)
    {
        if (month is not null) await CreateInstallmentWhenMonthAlreadyExist(installment, month, yearName);

        await CreateInstallmentWhenMonthDoesNotExist(installment, monthName, card, yearName);
    }

    private async Task CreateInstallmentWhenMonthAlreadyExist(Installment installment, Month month, string yearName)
    {
        Year newYear = await GetYear(month, yearName);    

        await CreateInstallment(installment, newYear);
    }

    private async Task CreateInstallmentWhenMonthDoesNotExist(Installment installment, string monthName, Card card, string yearName)
    {
        Month newMonth = new() { Name = monthName, Card = card };

        await _context.AddAsync(newMonth);
            
        Year year = await GetYear(newMonth, yearName);

        await CreateInstallment(installment, year);
    }

    private async Task<Year> GetYear(Month month, string yearName) 
    {
        Year? year = month.Year.FirstOrDefault(m => m.Name == yearName);

        if (year is not null) return year;
        
        Year newYear = new() { Name = yearName, Month = month };

        await _context.AddAsync(newYear);

        return newYear;
    }

    private async Task CreateInstallment(Installment installment, Year year) {
        
        AppendTotalToYear(year, installment);

        Installment installmentToSave = new() 
        { 
            Name = installment.Name, 
            Year = year,
            Date = installment.Date, 
            Value = installment.Value, 
            Quantity = installment.Quantity, 
            Description = installment.Description, 
            Total = installment.Total
        };

        await _context.AddAsync(installmentToSave);
    }

    private void AppendTotalToCard(Card card, Installment installment)
    {
        card.Total += installment.Total;

        _context.Update(card);
    }

    private void AppendTotalToYear(Year year, Installment installment)
    {
        year.Total += installment.Value;
    }
    
    private async Task Save() => await _context.SaveChangesAsync();
}