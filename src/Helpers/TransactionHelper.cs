namespace Sa.Payment.Api.Helpers;

public class TransactionHelper()
{
    public static bool IsAlmostFinish(InstallmentResponse installment) => installment.Quantity - installment.CurrentParcel <= 2;
    public static string FormatDescription(InstallmentResponse installment) => $"{installment.Name} just {installment.Quantity - installment.CurrentParcel} parcels left";   
}