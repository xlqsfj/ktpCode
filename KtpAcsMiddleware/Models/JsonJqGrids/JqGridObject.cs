using System.Collections.Generic;

namespace KtpAcsMiddleware.Models.JsonJqGrids
{
    public class JqGridObject
    {
        private readonly int _pageSize;

        public JqGridObject(IList<JqGridRowObject> rows, long totalRecords, int pageIndex, int pageSize)
        {
            Rows = rows;
            Records = totalRecords;
            Page = pageIndex;
            _pageSize = pageSize;
        }

        public IList<JqGridRowObject> Rows { get; }

        public long Records { get; }

        public int Page { get; }

        public long Total => (Records + _pageSize - 1) / _pageSize;
    }
}