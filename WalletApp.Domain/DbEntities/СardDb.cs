using WalletApp.Domain.Constants;

namespace WalletApp.Domain.DbEntities;

public class СardDb : BaseEntityDb
{
    public decimal Balance { get; set; }

    public decimal Limit { get; set; } = GlobalConstants.CardLimit;

    public decimal Available => Limit - Balance;
}