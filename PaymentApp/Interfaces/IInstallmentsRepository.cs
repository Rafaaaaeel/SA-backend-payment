using PaymentApp.Models;

namespace PaymentApp.Interfaces
{
    public interface IInstallmentsRepository
    {
        Task CreateInstallmentForCard(Installment request, int id);
    }
}
