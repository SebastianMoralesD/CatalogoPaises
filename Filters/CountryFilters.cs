namespace CatalogoPaises.Filters
{
    public class CountryFilters
    {

        public int? PaisId { get; set; }

        public string? NombrePais { get; set; }

        public string? CodigoIso  { get; set; }

        public int? pageindex { get; set; }
        public int? pagesize { get; set; }

    }
}
