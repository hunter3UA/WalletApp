using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WalletApp.Domain.DbEntities;
using WalletApp.Domain.Enums;

namespace WalletApp.Infrastructure.Extensions;

public static class IQueryableExtensions
{
    public static IQueryable<TEntity> ApplyPagingAndSorting<TEntity>(
        this IQueryable<TEntity> query,
        Expression<Func<TEntity, object>>? sortingExpression,
        SortingOrder sortingOrder,
        int skip,
        int take)
        where TEntity : BaseEntityDb
    {
        query = query.ApplySorting(sortingExpression, sortingOrder);

        if (skip != default)
            query = query.Skip(skip);

        if (take != default)
            query = query.Take(take);

        return query;
    }

    public static IQueryable<TEntity> NoTracking<TEntity>(
        this IQueryable<TEntity> query,
        bool asNoTracking) where TEntity : BaseEntityDb
    {
        return asNoTracking ? query.AsNoTracking() : query;
    }

    public static IQueryable<TEntity> ApplySorting<TEntity>(
       this IQueryable<TEntity> query,
       Expression<Func<TEntity, object>>? sortingExpression,
       SortingOrder sortingOrder)
       where TEntity : BaseEntityDb
    {
        if (sortingExpression is null)
            return query;

        query = sortingOrder is SortingOrder.Asc ?
            query.OrderBy(sortingExpression) :
            query.OrderByDescending(sortingExpression);

        return query;
    }
}