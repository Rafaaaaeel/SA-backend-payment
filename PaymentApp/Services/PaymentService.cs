using AutoMapper;
using PaymentApp.Data;
using PaymentApp.Dto.Create;
using PaymentApp.Dto.Read;
using PaymentApp.Models;
using PaymentApp.Helper;

namespace PaymentApp.Services
{
    public class PaymentService : IPaymentService
    {

        private readonly PaymentContext _context;
        private readonly IMapper _mapper;
        // private readonly YearHelper helper = new YearHelper();

        public PaymentService(PaymentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ReadPaymentDto> GetAllPayments(string email)
        {

            try
            {
                IEnumerable<ReadPaymentDto> payments = _mapper.Map<IEnumerable<ReadPaymentDto>>(_context.Card.ToList().FindAll(p => p.EmailOwner == email));
                return payments;
            } catch 
            {
                Console.WriteLine("Something Went Wrong");
                return new HashSet<ReadPaymentDto>();
            }
        
        }
        

        public ReadPaymentDto GetPayment(string email, int id) 
        {
            IEnumerable<ReadPaymentDto> payments = GetAllPayments(email);

            ReadPaymentDto? payment = payments.FirstOrDefault(p => p.Id == id);

            if (payment == null) throw new NullReferenceException();

            return payment;
        } 

        public async Task CreatePayment(CreateCardDto request)
        {
            Card payment = _mapper.Map<Card>(request);
            
            await _context.Card.AddAsync(payment);

            bool status = await Save();

            if (status) 
            {
                Console.WriteLine("Something went wrong");
            }
            
            return;
        }
        
        public async Task CreateInstallment(CreateInstallmentDto request, int id)
        {
            // helper.Processor(request);
        }

        private async Task<bool> Save()
        {
            int state = await _context.SaveChangesAsync();
            
            return state >= 0;
        }
    }
}