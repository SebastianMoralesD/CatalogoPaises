namespace CatalogoPaises.Filters
{
    public class PagedList<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public IQueryable<T> Data { get; set; }
        public int CurrentPageSize { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
        public int? NextPageNumber => HasNextPage ? CurrentPage + 1 : null;
        public int? PreviousPageNumber => HasPreviousPage ? CurrentPage - 1 : null;

        public PagedList(IQueryable<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Data = items;
            CurrentPageSize = items.Count();
        }


        public static PagedList<T> Create(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }

        public object Metadata()
        {
            return new
            {
                TotalCount,
                PageSize,
                CurrentPage,
                CurrentPageSize,
                HasNextPage,
                HasPreviousPage,
                NextPageNumber,
                PreviousPageNumber
            };
        }

    }
}
