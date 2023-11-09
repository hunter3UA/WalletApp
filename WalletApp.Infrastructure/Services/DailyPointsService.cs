using WalletApp.Application.Services;

namespace WalletApp.Infrastructure.Services
{
    public sealed class DailyPointsService : IDailyPointsService
    {
        public int CountDailyPoints()
        {
            int dayOfCurrentSeason = CalculateDayOfCurrentSeason();

            int points = 0;
            int previous = 0;
            int prePrevious = 0;

            for (int i = 0; i < dayOfCurrentSeason; i++)
            {

                if (i == 0)
                {
                    points += 2;
                    prePrevious = points;
                }
                else if (i == 1)
                {
                    points += 3;
                    previous = points;
                }
                else
                {
                    points = prePrevious + (int)(previous * 0.6);
                    prePrevious = previous;
                    previous = points;
                }
            }

            return points;
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
}