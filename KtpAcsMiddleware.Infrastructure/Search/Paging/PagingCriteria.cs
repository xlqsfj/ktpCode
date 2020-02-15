namespace KtpAcsMiddleware.Infrastructure.Search.Paging
{
    public class PagingCriteria
    {
        public PagingCriteria(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex - 1;
            if (PageIndex < 0)
                PageIndex = 0;
            PageSize = pageSize;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}