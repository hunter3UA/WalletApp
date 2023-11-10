using System.Linq.Expressions;
using WalletApp.Domain.DbEntities;
using WalletApp.Domain.Enums;

namespace WalletApp.Application.Repositories;

public interface ITransactionRepository
{
    Task<IReadOnlyList<TransactionDb>> GetRangeAsync(Expression<Func<TransactionDb, bool>> filter, Expression<Func<TransactionDb, object>> sortingExpression, SortingOrder sortingOrder, CancellationToken cancellationToken, int skip = default, int take = default, bool asNoTracking = true);
}