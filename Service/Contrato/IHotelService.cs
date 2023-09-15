using CatalogoPaises.DTOS;
using CatalogoPaises.Filters;

namespace CatalogoPaises.Service.Contrato
{
    public interface IHotelService
    {

        Task<IQueryable<HotelesDTO>> GetHotelesAsync(HotelesFilters filters);
    }
}
