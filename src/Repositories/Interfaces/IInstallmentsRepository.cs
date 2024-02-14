using PaymentApp.Models;

namespace PaymentApp.Interfaces
{
    public interface IInstallmentsRepository
    {
        Task CreateInstallmentForCard(CreateInstallmentDto request, int id);
        Task<Installment> GetInstallment(int id);
    }
}
