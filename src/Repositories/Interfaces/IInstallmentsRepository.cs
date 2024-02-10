using PaymentApp.Models;

namespace PaymentApp.Interfaces
{
    public interface IInstallmentsRepository
    {
        Task CreateInstallmentForCard(Installment request, int id);
        Task DeleteInstallment(int installmentId, int cardId);
        Task DeleteOccurenceInstallment(int id);
        Task<Installment> GetInstallment(int id);
    }
}
