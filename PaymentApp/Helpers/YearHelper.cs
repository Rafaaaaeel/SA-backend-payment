using PaymentApp.Dto.Create;
using PaymentApp.Models;

namespace PaymentApp.Helpers
{
    public class YearHelper
    {
        private readonly DateTime date;

        public void Processor(CreateInstallmentDto installment, Card card)
        {

            DateTime finalDate = GetFinalDate(installment.Date ?? DateTime.Now, installment.Quantity);

            if (finalDate.Year != installment.Date?.Year)
            {
                // Get
            }

        }

        private DateTime GetFinalDate(DateTime initialDate, int incremmmentor)
        {
            return initialDate.AddMonths(incremmmentor); 
        }
    }
}