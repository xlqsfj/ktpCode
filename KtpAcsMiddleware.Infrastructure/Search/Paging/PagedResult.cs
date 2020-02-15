using System.Collections.Generic;

namespace KtpAcsMiddleware.Infrastructure.Search.Paging
{
    public class PagedResult<TEntity>
    {
       /// <summary>
       /// 返回总数和实体列表
       /// </summary>
       /// <param name="count">总数</param>
       /// <param name="entities">返回实体列</param>
        public PagedResult(int count, IEnumerable<TEntity> entities)
        {
            Count = count;
            Entities = entities;
        }
        /// <summary>
        /// 总数
        /// </summary>
        public int Count { get; set; }
        public IEnumerable<TEntity> Entities { get; set; }
    }
}