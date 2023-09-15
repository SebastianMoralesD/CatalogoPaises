using CatalogoPaises.DTOS;
using CatalogoPaises.Filters;

namespace CatalogoPaises.Service.Contrato
{
    public interface IPaisesService
    {
        Task<IQueryable <PaisesDTO>> GetPaisesAsync(CountryFilters filters);


    }
}
