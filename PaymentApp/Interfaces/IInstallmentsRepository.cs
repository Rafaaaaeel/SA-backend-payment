using PaymentApp.Dto.Create;

namespace PaymentApp.Interfaces
{
    public interface IInstallmentsRepository
    {
        Task CreateInstallment(CreateInstallmentDto request, int id);
    }
}
