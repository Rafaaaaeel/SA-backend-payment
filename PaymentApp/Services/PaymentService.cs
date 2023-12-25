using AutoMapper;
using PaymentApp.Data;
using PaymentApp.Dto.Create;
using PaymentApp.Dto.Read;
using PaymentApp.Models;

namespace PaymentApp.Services
{
    public class PaymentService : IPaymentService
    {

        private readonly PaymentContext _context;
        private readonly IMapper _mapper;

        public PaymentService(PaymentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreatePayment(CreatePaymentDto request)
        {
            Payment payment = _mapper.Map<Payment>(request);
            
            await _context.Payment.AddAsync(payment);

            bool status = await Save();

            if (status) 
            {
                Console.WriteLine("Something went wrong");
            }
            
            return;
        }

        public IEnumerable<ReadPaymentDto> GetAllPayments(string email)
        {

            IEnumerable<ReadPaymentDto> payments = _mapper.Map<IEnumerable<ReadPaymentDto>>(_context.Payment.ToList().FindAll(p => p.EmailOwner == email));
            
            return payments;
        }
        
        private async Task<bool> Save()
        {
            int state = await _context.SaveChangesAsync();
            
            return state >= 0;
        }
    }
}