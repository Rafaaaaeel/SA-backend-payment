using PaymentApp.Dto.Read;
using PaymentApp.Dto.Create;

namespace PaymentApp.Services
{
    public interface IPaymentService 
    {
        IEnumerable<ReadPaymentDto> GetAllPayments(string email);
        Task CreatePayment(CreatePaymentDto request);
    }
}