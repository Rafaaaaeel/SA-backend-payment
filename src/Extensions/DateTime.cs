namespace Sa.Payment.Api.Extensions;

public static class DateTimeExtension
{
    public static string GetMonthAbbreviatedName(this DateTime time) => CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(time.Month);
    public static string GetMonthCompletedName(this DateTime time) => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(time.Month);
}