using CatalogoPaises.DTOS;
using CatalogoPaises.Filters;

namespace CatalogoPaises.Service.Contrato
{
    public interface IRestauranteService
    {
        Task<IQueryable<RestauranteDTO>> GetRestaurantesAsync(RestauranteFilters filters);
    }
}
