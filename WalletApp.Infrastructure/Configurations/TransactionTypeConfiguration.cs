using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletApp.Domain.Constants;
using WalletApp.Domain.DbEntities;
using WalletApp.Domain.Enums;

namespace WalletApp.Infrastructure.Configurations
{
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

            builder.Property(trn => trn.Pending).HasDefaultValue(true);
            builder.Property(trn => trn.ExecutedDay).HasDefaultValue(DateTimeOffset.UtcNow);
        }
    }
}
