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

        Card? card = await FetchCardById(id);

        if (card == null) return;
        
        await AppendTotalToCard(card, installment);

        await CreateAllInstallmentAtMonths(request.Quantity, request.Date ?? DateTime.Now, card, installment);
    }

    public async Task<Installment> GetInstallment(int id) 
    {
        Installment? installment = await _context.Installment.FirstOrDefaultAsync(i => i.Id == id);

        if (installment == null) throw new NullReferenceException();

        return installment;
    }

    private bool IsTheSameInstallment(Installment right, Installment left) => right.Name == left.Name && right.Value == left.Value && right.Quantity == left.Quantity;
    
    private async Task<Card?> FetchCardById(int id) => await _context.Card.Include(c => c.Months)
                                                                            .ThenInclude(m => m.Year)
                                                                            .FirstOrDefaultAsync(c => c.Id == id);

    private async Task CreateAllInstallmentAtMonths(int quantity, DateTime time, Card card, Installment installment)
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
        if (month != null) await CreateInstallmentWhenMonthAlreadyExist(installment, month, yearName);

        await CreateInstallmentWhenMonthDontExisteYet(installment, monthName, card, yearName);
    }

    private async Task CreateInstallmentWhenMonthAlreadyExist(Installment installment, Month month, string yearName)
    {
        Year newYear = await CreateYear(month, yearName);    

        await CreateInstallment(installment, newYear);

        await Save();
    }

    private async Task CreateInstallmentWhenMonthDontExisteYet(Installment installment, string monthName, Card card, string yearName)
    {
        Month newMonth = new Month() { Name = monthName, Card = card };

        await _context.AddAsync(newMonth);
            
        Year year = await CreateYear(newMonth, yearName);

        await CreateInstallment(installment, year);

        await Save();
    }

    private async Task<Year> CreateYear(Month month, string yearName) 
    {
        Year? year = month.Year.FirstOrDefault(m => m.Name == yearName);

        if (year != null) return year;
        
        Year newYear = new Year() { Name = yearName, Month = month };

        await _context.AddAsync(newYear);

        await Save();

        return newYear;
    }

    private async Task CreateInstallment(Installment installment, Year year) {
        
        await AppendTotalToYear(year, installment);

        Installment newInstallment = new Installment() 
        { 
            Name = installment.Name, 
            Year = year, 
            Date = installment.Date, 
            Value = installment.Value, 
            Quantity = installment.Quantity , 
            Description = installment.Description, 
            Total = installment.Total
        };

        await _context.AddAsync(newInstallment);

        await Save();
    }

    private async Task AppendTotalToCard(Card card, Installment installment)
    {
        card.Total += installment.Total;

        _context.Update(card);

        await Save();
    }

    private async Task AppendTotalToYear(Year year, Installment installment)
    {
        year.Total += installment.Value;

        _context.Update(year);

        await Save();
    }
    private async Task Save() => await _context.SaveChangesAsync();
}