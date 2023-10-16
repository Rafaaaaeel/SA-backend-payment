using PaymentApp.Dto.Read;
using PaymentApp.Dto.Create;

namespace PaymentApp.Services
{
    public interface IPaymentService 
    {
        Task<IEnumerable<ReadPaymentDto>> GetAllPayments(string email);
        Task CreatePayment(string email, CreatePaymentDto request);
    }
}