using PaymentApp.Models;

namespace PaymentApp.Interfaces
{
    public interface IInstallmentsRepository
    {
        Task CreateInstallmentForCard(InstallmentRequest request, int id);
        Task<Installment> GetInstallment(int id);
    }
}
