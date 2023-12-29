using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using PaymentApp.Dto.Create;
using PaymentApp.Models;

public enum Months 
{
    Jan = 1,
    Feb = 2,
    Mar = 3,
    Apr = 4,
    May = 5,
    Jun = 6,
    Jul = 7,
    Aug = 8,
    Sep = 9,
    Otc = 10,
    Nov = 11,
    Dec = 12
}

namespace PaymentApp.Helper
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