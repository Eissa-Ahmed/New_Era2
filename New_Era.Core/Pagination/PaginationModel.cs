namespace New_Era.Core.Pagination
{
    public class PaginationModel<T>
    {
        public PaginationModel(int page, int pageSize, int totalPages, int totalCountItem, bool succeeded, List<T> data)
        {
            Page = page;
            PageSize = pageSize;
            TotalPages = totalPages;
            TotalCountItem = totalCountItem;
            Succeeded = succeeded;
            Data = data;
        }
        public PaginationModel()
        {
            Page = 1;
            PageSize = 0;
            TotalPages = 1;
            TotalCountItem = 0;
            Succeeded = true;
            Data = new List<T>();
        }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalCountItem { get; set; }

        public bool HasPreviousPage => Page > 1;

        public bool HasNextPage => Page < TotalPages;
        public bool Succeeded { get; set; }
        public List<T> Data { get; set; }

    }
}
