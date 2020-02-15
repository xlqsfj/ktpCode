using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.Infrastructure.Search.Sort;

namespace KtpAcsMiddleware.Infrastructure.Search
{
    /// <summary>
    ///     搜索参数标准
    /// </summary>
    /// <typeparam name="TEntity">TEntity</typeparam>
    public class SearchCriteria<TEntity>
    {
        public SearchCriteria()
        {
            FilterCriterias = new List<Expression<Func<TEntity, bool>>>();
            SortCriterias = new List<ISortCriteria<TEntity>>();
        }

        public IList<Expression<Func<TEntity, bool>>> FilterCriterias { get; }

        public IList<ISortCriteria<TEntity>> SortCriterias { get; }
        /// <summary>
        /// 分页
        /// </summary>
        public PagingCriteria PagingCriteria { get; set; }
        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <param name="filter"></param>
        public void AddFilterCriteria(Expression<Func<TEntity, bool>> filter)
        {
            FilterCriterias.Add(filter);
        }
        /// <summary>
        /// 添加排序
        /// </summary>
        /// <param name="sortCriteria"></param>
        public void AddSortCriteria(ISortCriteria<TEntity> sortCriteria)
        {
            SortCriterias.Add(sortCriteria);
        }
    }
}