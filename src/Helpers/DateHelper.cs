namespace Sa.Payment.Api.Helpers;

public static class DateHelper
{
    public static string GetMonthName(DateTime time) => CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(time.Month);
}