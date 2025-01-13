using Microsoft.EntityFrameworkCore;

namespace Demo3.Dto
{
    public static class PagerExtension
    {
        public static async Task<PagedResponse<T>> PaginateAsync<T>(
        this IQueryable<T> query,
        int pageNumber,
        int pageSize)
        where T : class
        {
            var paged = new PagedResponse<T>();
            pageNumber = (pageNumber < 0) ? 1 : pageNumber;
            paged.CurrentPageNumber = pageNumber;
            paged.PageSize = pageSize;
            paged.TotalRecordCount = await query.CountAsync();
            var pageCount = (double)paged.TotalRecordCount / pageSize;
            paged.PageCount = (int)Math.Ceiling(pageCount);
            var startRow = (pageNumber - 1) * pageSize;
            paged.Result = await query.Skip(startRow).Take(pageSize).ToListAsync();
            return paged;
        }
    }
}
