using System;
using System.Linq;
using System.Linq.Expressions;

namespace KtpAcsMiddleware.Infrastructure.Search.Sort
{
    public class ExpressionSortCriteria<T, TKey> : ISortCriteria<T>
    {
        public ExpressionSortCriteria()
        {
            Direction = SortDirection.Ascending;
        }

        public ExpressionSortCriteria(Expression<Func<T, TKey>> expression, SortDirection direction)
        {
            SortExpression = expression;
            Direction = direction;
        }

        public Expression<Func<T, TKey>> SortExpression { get; set; }

        public SortDirection Direction { get; set; }

        public IOrderedQueryable<T> Apply(IQueryable<T> query, bool useThenBy)
        {
            if (SortExpression == null)
                return query.OrderBy(x => 0);
            if (Direction == SortDirection.Ascending)
                return !useThenBy
                    ? query.OrderBy(SortExpression)
                    : ((IOrderedQueryable<T>) query).ThenBy(SortExpression);
            return !useThenBy
                ? query.OrderByDescending(SortExpression)
                : ((IOrderedQueryable<T>) query).ThenByDescending(SortExpression);
        }
    }
}