using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WalletApp.Application.Repositories;
using WalletApp.Domain.DbEntities;
using WalletApp.Domain.Enums;
using WalletApp.Infrastructure.DbContexts;
using WalletApp.Infrastructure.Extensions;

namespace WalletApp.Infrastructure.DataAccess;

public class TransactionRepository : ITransactionRepository
{
    private readonly WalletDbContext _dbContext;
    private readonly DbSet<TransactionDb> _dbSet;

    public TransactionRepository(WalletDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TransactionDb>();
    }

    public async Task<IReadOnlyList<TransactionDb>> GetRangeAsync(Expression<Func<TransactionDb, bool>> filter, Expression<Func<TransactionDb, object>> sortingExpression, SortingOrder sortingOrder, CancellationToken cancellationToken, int skip, int take, bool asNoTracking)
    {
        var transactions = await _dbSet
            .Where(filter)
            .NoTracking(asNoTracking)
            .ApplyPagingAndSorting(sortingExpression, sortingOrder, skip, take)
            .ToListAsync(cancellationToken);

        return transactions;
    }
}