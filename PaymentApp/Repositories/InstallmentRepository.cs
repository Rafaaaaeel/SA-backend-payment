using PaymentApp.Interfaces;
using PaymentApp.Dto.Create;
using PaymentApp.Data;
using PaymentApp.Models;
using Microsoft.EntityFrameworkCore;

namespace PaymentApp.Repositories
{
    public class InstallmentsRepository : IInstallmentsRepository
    {
        private readonly CardContext _context;
        private readonly IDateHelper _helper;

        public InstallmentsRepository(CardContext context, IDateHelper helper)
        {
            _context = context;
            _helper = helper;
        }

        public async Task CreateInstallmentForCard(Installment request, int id)
        {
            Card? card = await FetchCardById(id);

            if (card == null) return;
            
            await CreateMonths(request.Quantity, request.Date ?? DateTime.Now, card, request);
        }
        
        private async Task<Card?> FetchCardById(int id) => await _context.Card.Include(c => c.Months)
                                                                                .ThenInclude(m => m.Year)
                                                                                .FirstOrDefaultAsync(c => c.Id == id);

        private async Task CreateMonths(int quantity, DateTime time, Card card, Installment installment)
        {
           
            for (int index = 0; index < quantity; index++)
            {
                DateTime currentMonth = time.AddMonths(index);
                string monthName =  _helper.GetMonthName(currentMonth);
                string yearName = currentMonth.Year.ToString();
                Month? month = card.Months.FirstOrDefault(m => m.Name == monthName);
     
                if (month != null) 
                {
                    Year newYear = CreateYear(month, yearName);    

                    await _context.AddAsync(newYear);

                    Installment installment2 = new Installment() { Name = installment.Name,
                                                                    Year = newYear, Date = installment.Date,
                                                                    Quantity = installment.Quantity, 
                                                                    Description = installment.Description};

                    await _context.AddAsync(installment2);

                    await Save();

                    continue;
                }

                Month newMonth = new Month() { Name = monthName, Card = card };

                await _context.AddAsync(newMonth);
                
                Year year = CreateYear(newMonth, yearName);
                
                await _context.AddAsync(year);

                Installment installment1 = new Installment() { Name = installment.Name, 
                                                                Year = year, Date = installment.Date, 
                                                                Quantity = installment.Quantity, 
                                                                Description = installment.Description};

                await _context.AddAsync(installment1);

                await Save();
            }
        }

        private Year CreateYear(Month month, string yearName) 
        {
            Year? year = month.Year.FirstOrDefault(m => m.Name == yearName);

            if (year != null) return year;
            
            Year newYear = new Year() { Name = yearName, Month = month };

            return newYear;
        }   

        private async Task Save() => await _context.SaveChangesAsync();
    }
}