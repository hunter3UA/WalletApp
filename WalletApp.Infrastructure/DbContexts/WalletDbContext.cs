using Microsoft.EntityFrameworkCore;
using WalletApp.Domain.DbEntities;
using WalletApp.Infrastructure.Configurations;

namespace WalletApp.Infrastructure.DbContexts;

public class WalletDbContext : DbContext
{
    public DbSet<TransactionDb> Transactions { get; set; }

    public WalletDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TransactionTypeConfiguration());
    }
}