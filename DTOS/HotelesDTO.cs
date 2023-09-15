namespace CatalogoPaises.DTOS
{
    public class HotelesDTO
    {
        public int IdHotel { get; set; }

        public string? NombreHotel { get; set; }
        public PaisesDTO? Pais { get; set; }
    }
}
