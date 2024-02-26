namespace Sa.Payment.Api.Helpers;

public class InstallmentHelper()
{
    public static IEnumerable<InstallmentResponse> GetInstallmentsFromTheCurrentMonthExpiringInCard(CardResponse card) => card
            .Months.First(m => m.Name == DateTime.UtcNow.GetMonthAbbreviatedName())
            .Years.First(y => y.Name == DateTime.UtcNow.Year.ToString())
            .Installments.Where(i => TransactionHelper.IsAlmostFinish(i));

    public static IEnumerable<InstallmentResponse> GetLastInstallmentsFromTheCurrentMonthInCard(CardResponse card) => card
            .Months.First(m => m.Name == DateTime.UtcNow.GetMonthAbbreviatedName())
            .Years.First(y => y.Name == DateTime.UtcNow.Year.ToString())
            .Installments;
}