using PaymentApp.Dto.Read;

namespace PaymentApp.Services
{
    public class MockPaymentService : IPaymentService
    {
        public Task<IEnumerable<ReadPaymentDto>> GetAllPayments()
        {
            throw new NotImplementedException();
        }
    }
}