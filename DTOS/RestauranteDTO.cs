namespace CatalogoPaises.DTOS
{
    public class RestauranteDTO 
    {
        public int Idrestaurante { get; set; }

        public string? NombreRestaurante { get; set; }

        public PaisesDTO? Pais { get; set; }
    }
}
