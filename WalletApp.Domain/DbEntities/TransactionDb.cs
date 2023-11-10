using WalletApp.Domain.Enums;

namespace WalletApp.Domain.DbEntities;

public class TransactionDb : BaseEntityDb
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public required decimal Sum { get; set; }

    public TransactionType Type { get; set; }

    public bool Pending { get; set; }

    public string? AuthorizedUser { get; set; }

    public DateTimeOffset ExecutedDay { get; set; }

    public string? IconUrl { get; set; }

    public int UserId { get; set; }
}