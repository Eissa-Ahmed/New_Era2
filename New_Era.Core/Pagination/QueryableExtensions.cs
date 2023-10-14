namespace New_Era.Core.Pagination
{
    public static class QueryableExtensions
    {
        public static async Task<PaginationModel<T>> ToPaginationList<T>(this IQueryable<T> source, int page, int pageSize) where T : class
        {
            if (source == null) throw new ArgumentNullException();
            page = page <= 0 ? 1 : page;
            int TotalCountItem = await source.CountAsync();
            pageSize = pageSize <= 0 ? 5 : pageSize > TotalCountItem ? TotalCountItem : pageSize;
            if (TotalCountItem.Equals(0)) return new PaginationModel<T>();
            int TotalPages = (int)Math.Ceiling((decimal)(TotalCountItem / pageSize));
            if (TotalCountItem < 5) pageSize = TotalCountItem;
            var item = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginationModel<T>(page, pageSize, TotalPages, TotalCountItem, true, item);

        }
    }
}
