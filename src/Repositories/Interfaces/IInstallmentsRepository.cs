namespace Sa.Payment.Api.Interface;

public interface IInstallmentsRepository
{
    Task CreateInstallmentForCard(InstallmentRequest request, int id);
    Task<Installment> GetInstallment(int id);
}