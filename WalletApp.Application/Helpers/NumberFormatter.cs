using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WalletApp.Application.Helpers;

public static class NumberFormatter
{
    public static string FormatToShortString(this double d)
    {
        if (d >= 1000 && d < 1_000_000)
        {
            d = (int)Math.Round((double)d / 1000);

            return d.ToString() + "K";
        }
        else if (d >= 1_000_000 && d < 1_000_000_000)
        {
            d = (int)Math.Round((double)d / 1_000_000);

            return d.ToString() + 'M';
        }
        else if (d >= 1_000_000_000)
        {
            d = (int)Math.Round((double)d / 1_000_000_000);

            return d.ToString() + "B";
        }

        return d.ToString();
    }
}