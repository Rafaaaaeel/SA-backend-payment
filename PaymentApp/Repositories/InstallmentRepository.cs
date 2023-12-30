using PaymentApp.Interfaces;
using PaymentApp.Dto.Create;
using PaymentApp.Data;
using PaymentApp.Models;

namespace PaymentApp.Repositories
{
    public class InstallmentsRepository : IInstallmentsRepository
    {
        private readonly CardContext _context;

        public InstallmentsRepository(CardContext context)
        {
            _context = context;
        }

        public Task CreateInstallment(CreateInstallmentDto request, int id)
        {
            throw new NotImplementedException();
        }

        public async Task CreateInstallment1(CreateInstallmentDto request, int id)
        {
            // helper.Processor(request);
            // Card? card = GetCard(id);

            // if (card == null) throw new NullReferenceException();

            // CreateMonthDto monthDto = new CreateMonthDto() { Name = "Jan" };
            
            // Month month =  _mapper.Map<Month>(monthDto);
            
            // month.Card = _mapper.Map<Card>(card);
            
            // _context.Month.Add(month);
            
            // await Save();

            return;
        }
    }
}