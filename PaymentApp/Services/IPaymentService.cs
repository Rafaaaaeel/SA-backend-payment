using PaymentApp.Dto.Read;
using PaymentApp.Dto.Create;

namespace PaymentApp.Services
{
    public interface IPaymentService 
    {
        IEnumerable<ReadPaymentDto> GetAllPayments(string email);
        // Task<ReadPaymentDto> GetPayment(string email, int id);
        ReadPaymentDto GetPayment(string email, int id);
        Task CreatePayment(CreateCardDto request);
        Task CreateInstallment(CreateInstallmentDto request, int id);
    }
}