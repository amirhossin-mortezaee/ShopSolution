using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Commons.ValueObjects
{
    public class Pagination
    {
        public int PageNumber { get;  private set; }
        public int PageSize { get;  private set; }
        public int? TotalCount { get;  private set; }
        public int? TotalPages => TotalCount.HasValue 
            ? (int)Math.Ceiling(TotalCount.Value / (double) PageSize)
            : null;

        public Pagination(int pageNumber = 1, int pageSize = 10 , int? totalCount = null)
        {
            if (pageNumber < 1)
                throw new ArgumentException("شماره صفحه باید بزرگتر از 0 باشد.");

            if (pageSize < 1)
                throw new ArgumentException("تعداد ایتم در صفحه باید بزرگتر از 0 باشد.");

            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
        }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => TotalPages.HasValue && PageNumber < TotalPages.Value;

        public int Skip => (PageNumber - 1) * PageSize;

        public int Take => PageSize;
    }
}
