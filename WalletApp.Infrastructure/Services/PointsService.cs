using WalletApp.Application.Helpers;
using WalletApp.Application.Services;

namespace WalletApp.Infrastructure.Services;

public sealed class PointsService : IPointsService
{
    public string CountDailyPoints()
    {
        int dayOfCurrentSeason = CalculateDayOfCurrentSeason();
        double previous = 0;
        double prePrevious = 0;
        double points = 0;

        for (int i = 0; i < dayOfCurrentSeason; i++)
        {
            if (i == 0)
            {
                points = 2;
                prePrevious = 2;
            }
            else if (i == 1)
            {
                points += 3;
                previous = 3;
            }
            else
            {
                points = prePrevious + Math.Round(previous * 0.6);
                prePrevious = previous;
                previous = points;
            }
        }

        return points.FormatToShortString();
    }

    private static int CalculateDayOfCurrentSeason()
    {
        DateTimeOffset now = DateTimeOffset.UtcNow;
        int firstMonth = (now.Month / 3) * 3;
        DateTimeOffset firstDayOfSeason = new DateTimeOffset(now.Year, firstMonth, 1, 0, 0, 0, now.Offset);
        int daysDiff = now.DayOfYear - firstDayOfSeason.DayOfYear;

        return daysDiff;
    }
}