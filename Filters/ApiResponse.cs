namespace CatalogoPaises.Filters
{
    public class ApiResponse<T>
where T : class
    {
        public T? Data { get; set; }

        public object? XPagination { get; set; }

        public ApiResponse(T? data = null)
        {
            Data = data;
        }
    }
}
