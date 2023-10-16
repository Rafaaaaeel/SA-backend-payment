using Microsoft.EntityFrameworkCore;
using PaymentApp.Data;
using PaymentApp.Dto.Create;
using PaymentApp.Dto.Read;

namespace PaymentApp.Services
{
    public class PaymentService : IPaymentService
    {

        private readonly PaymentContext _context;

        public PaymentService(PaymentContext context)
        {
            _context = context;
        }

        public Task CreatePayment(string email, CreatePaymentDto request)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReadPaymentDto>> GetAllPayments(string email)
        {
            throw new NotImplementedException();
        }
        
    }
}