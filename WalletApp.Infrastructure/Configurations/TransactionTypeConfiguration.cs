using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletApp.Domain.Constants;
using WalletApp.Domain.DbEntities;
using WalletApp.Domain.Enums;

namespace WalletApp.Infrastructure.Configurations;

public class TransactionTypeConfiguration : BaseEntityTypeConfiguration<TransactionDb>
{
    public override void Configure(EntityTypeBuilder<TransactionDb> builder)
    {
        base.Configure(builder);
        builder.Property(trn => trn.Name)
            .HasMaxLength(GlobalConstants.Transaction.TransactionNameMaxLength)
            .IsRequired();

        builder.Property(trn => trn.Description)
            .HasMaxLength(GlobalConstants.Transaction.TransactionDescriptionMaxLength);

        builder.Property(trn => trn.AuthorizedUser)
            .HasMaxLength(GlobalConstants.Transaction.AuthorizedUserNameMaxLength);

        builder.ToTable("Transactions", t =>
        {
            t.HasCheckConstraint("CK_Type_Range", @$"""Type"">={(int)TransactionType.Payment} or ""Type""<={(int)TransactionType.Credit}");
        });

        builder.Property(trn => trn.ExecutedDay).HasDefaultValue(DateTimeOffset.UtcNow);

        builder.Property(trn => trn.IconUrl).HasMaxLength(GlobalConstants.Transaction.IconUrlMaxLength);

        DateTimeOffset now = DateTimeOffset.UtcNow;

        builder.HasData(
            CreateTransaction("Apple", 300, TransactionType.Payment, true, new DateTimeOffset(now.Year, now.Month, 9, 0, 0, 0, now.Offset), "Oleksandr", null, 1),
            CreateTransaction("Steam", 400, TransactionType.Credit, false, new DateTimeOffset(now.Year, now.Month - 1, 8, 0, 0, 0, now.Offset), null, null, 1),
            CreateTransaction("IKEA", 318.14m, TransactionType.Credit, false, new DateTimeOffset(now.Year, now.Month, 7, 0, 0, 0, now.Offset), null, "For goods", 1),
            CreateTransaction("Spotify", 200.4m, TransactionType.Credit, false, new DateTimeOffset(now.Year, now.Month, 6, 0, 0, 0, now.Offset), "Oleg", null, 1),
            CreateTransaction("Discord", 318m, TransactionType.Credit, false, new DateTimeOffset(now.Year, now.Month, 5, 12, 0, 0, now.Offset), null, "Morning transaction", 1),
            CreateTransaction("YouTube", 200.34m, TransactionType.Payment, false, new DateTimeOffset(now.Year, now.Month, 5, 13, 0, 0, now.Offset), null, null, 1),
            CreateTransaction("Netflix", 115.52m, TransactionType.Payment, false, new DateTimeOffset(now.Year, now.Month, 4, 10, 0, 0, now.Offset), "User1", null, 1),
            CreateTransaction("IKEA", 599.12m, TransactionType.Credit, false, new DateTimeOffset(now.Year, now.Month, 2, 12, 0, 0, now.Offset), null, "For goods", 1),
            CreateTransaction("IKEA", 500m, TransactionType.Credit, true, new DateTimeOffset(now.Year, now.Month, 2, 9, 0, 0, now.Offset), null, "For goods", 1),
            CreateTransaction("IKEA", 250m, TransactionType.Payment, true, new DateTimeOffset(now.Year, now.Month, 2, 5, 0, 0, now.Offset), null, "For goods", 1),
            CreateTransaction("IKEA", 400.51m, TransactionType.Credit, true, new DateTimeOffset(now.Year, now.Month, 3, 4, 0, 0, now.Offset), null, "For goods", 1),
            CreateTransaction("IKEA", 415.82m, TransactionType.Credit, false, new DateTimeOffset(now.Year, now.Month, 3, 3, 0, 0, now.Offset), null, "For goods", 1),
            CreateTransaction("IKEA", 100m, TransactionType.Credit, false, new DateTimeOffset(now.Year, now.Month, 3, 2, 0, 0, now.Offset), null, "For goods", 1),
            CreateTransaction("IKEA", 300m, TransactionType.Credit, false, new DateTimeOffset(now.Year, now.Month, 3, 0, 0, 0, now.Offset), null, "For goods", 1)
            );
    }


    private TransactionDb CreateTransaction(
        string name,
        decimal sum,
        TransactionType type,
        bool pending,
        DateTimeOffset executedDay,
        string? authorizedUser,
        string? description,
        int userId)
    {
        return new TransactionDb
        {
            Id = Guid.NewGuid(),
            Name = name,
            Sum = sum,
            Type = type,
            Pending = pending,
            ExecutedDay = executedDay,
            AuthorizedUser = authorizedUser,
            Description = description,
            IconUrl = "https://defaultImage.jpg",
            UserId = userId
        };
    }
}