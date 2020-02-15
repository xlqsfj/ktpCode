using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.Infrastructure.Search.Sort;

namespace KtpAcsMiddleware.Infrastructure.Search.Extensions
{/// <summary>
/// Linq的扩展类
/// </summary>
    public static class QueryableExtension
    {/// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="source"></param>
    /// <param name="searchCriteria"></param>
    /// <returns></returns>
        public static IQueryable<TEntity> SearchBy<TEntity>(this IQueryable<TEntity> source,
            SearchCriteria<TEntity> searchCriteria)
            where TEntity : class
        {
            var queryable = source;
            queryable = queryable.FilterBy(searchCriteria.FilterCriterias);
            queryable = queryable.OrderBy(searchCriteria.SortCriterias);
            queryable = queryable.PageBy(searchCriteria.PagingCriteria);
            return queryable;
        }
        /// <summary>
        /// 条件方法
        /// </summary>
        /// <typeparam name="TEntity">list类名</typeparam>
        /// <param name="source"></param>
        /// <param name="criterias"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> FilterBy<TEntity>(this IQueryable<TEntity> source,
            IList<Expression<Func<TEntity, bool>>> criterias)
            where TEntity : class
        {
            var queryable = source;
            if (criterias.Count > 0)
                queryable = criterias.Aggregate(source, (current, filter) => current.Where(filter));
            return queryable;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="source"></param>
        /// <param name="criterias"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source,
            IList<ISortCriteria<TEntity>> criterias)
            where TEntity : class
        {
            IQueryable<TEntity> queryable;
            if (criterias.Count > 0)
            {
                var firstSortCriteria = criterias[0];
                var orderedQueryable = firstSortCriteria.Apply(source, false);
                if (criterias.Count > 1)
                    for (var i = 1; i < criterias.Count; i++)
                    {
                        var sortCriteria = criterias[i];
                        orderedQueryable = sortCriteria.Apply(orderedQueryable, true);
                    }
                queryable = orderedQueryable;
            }
            else
            {
                queryable = source.OrderBy(x => 0);
            }
            return queryable;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="source"></param>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> PageBy<TEntity>(this IQueryable<TEntity> source, PagingCriteria criteria)
            where TEntity : class
        {
            var queryable = source;
            if (criteria != null)
            {
                var skipCount = criteria.PageIndex * criteria.PageSize;
                var takeCount = criteria.PageSize;
                queryable = source.Skip(skipCount).Take(takeCount);
            }
            return queryable;
        }
    }
}