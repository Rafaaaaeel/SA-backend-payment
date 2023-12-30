using AutoMapper;
using PaymentApp.Data;
using PaymentApp.Dto.Create;
using PaymentApp.Dto.Read;
using PaymentApp.Models;
using PaymentApp.Helper;
using Microsoft.EntityFrameworkCore;

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

        public IEnumerable<Card> GetAllPayments(string email)
        {
            try
            {
                IEnumerable<Card> cards = _context.Card.Include(c => c.Months).ToList().FindAll(p => p.EmailOwner == email);

                return cards;
            } catch 
            {
                return new HashSet<Card>();
            }
        }
        
        public ReadPaymentDto GetPayment(string email, int id) 
        {
            IEnumerable<ReadPaymentDto> payments = _mapper.Map<IEnumerable<ReadPaymentDto>>(GetAllPayments(email));

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
        
        public async Task CreateInstallment(CreateInstallmentDto request, int id, string email)
        {
            // helper.Processor(request);
            Card? card = GetCard(id);

            if (card == null) throw new NullReferenceException();

            CreateMonthDto monthDto = new CreateMonthDto() { Name = "Jan" };
            
            Month month =  _mapper.Map<Month>(monthDto);
            
            month.Card = _mapper.Map<Card>(card);
            
            _context.Month.Add(month);
            
            await Save();

            return;
        }

        private Card? GetCard(int id)
        {
            return _context.Card.FirstOrDefault(c => c.Id == id);
        }

        private async Task<bool> Save()
        {
            int state = await _context.SaveChangesAsync();
            
            return state >= 0;
        }
    }
}