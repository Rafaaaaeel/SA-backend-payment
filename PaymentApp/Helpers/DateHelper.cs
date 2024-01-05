using PaymentApp.Interfaces;
using System.Globalization;

namespace PaymentApp.Helpers
{
    public class DateHelper : IDateHelper
    {

        public string GetMonthName(DateTime time) => CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(time.Month);

    }
}