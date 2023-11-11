using System.Globalization;

namespace WalletApp.Application.Helpers;

public static class DateFormatter
{
    public static string FormatDate(DateTimeOffset date, DateTimeOffset now)
    {
        int diff = now.DayOfWeek - CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
        if (diff < 0)
            diff += 7;
        DateTimeOffset firstDayOfWeek = now.AddDays(-diff).Date;

        if (date >= firstDayOfWeek)
        {
            return date.DayOfWeek.ToString();
        }
        else
        {
            return date.ToString("d/M/yy", CultureInfo.InvariantCulture);
        }
    }
}