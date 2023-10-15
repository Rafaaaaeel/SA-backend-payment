using PaymentApp.Dto.Read;

namespace PaymentApp.Services
{
    public interface IPaymentService 
    {
        Task<IEnumerable<ReadPaymentDto>> GetAllPayments();
    }
}