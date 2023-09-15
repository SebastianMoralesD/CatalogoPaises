using CatalogoPaises.DB;
using CatalogoPaises.DTOS;
using CatalogoPaises.Filters;
using CatalogoPaises.Service.Contrato;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;

namespace CatalogoPaises.Service.Implementacion
{
    public class PaisesService : IPaisesService
    {
        private CatalogoPaisesContext dbcontextpaises;
        public PaisesService(CatalogoPaisesContext context){
            
            this.dbcontextpaises = context;
        
        }

        private ExpressionStarter<Paise> GetPredicate(CountryFilters search)
        {
            var predicate = PredicateBuilder.New<Paise>(true);

            if (search.PaisId != null)
            {
                predicate = predicate.And(x => x.Id == search.PaisId);
            }

            if (search.NombrePais != null)
            {
                predicate = predicate.And(x => x.NombrePais == search.NombrePais);
            }

            if (search.CodigoIso != null)
            {
                predicate = predicate.And(x => x.CodigoIso == search.CodigoIso);
            }

            return predicate;
        }


        public async Task<IQueryable<PaisesDTO>> GetPaisesAsync(CountryFilters filters)
        {
            

            var predicate = PredicateBuilder.New<Paise>(true);

            if (filters != null)
            {
                predicate = this.GetPredicate(filters);
            }


            var ListaPaises = dbcontextpaises.Paises.Where(predicate);

            IQueryable<PaisesDTO> ListaPaisesDTO = ListaPaises.Select(a => new PaisesDTO
            {


                Id = a.Id,
                CodigoIso = a.CodigoIso,
                NombrePais = a.NombrePais


            });
         

            return ListaPaisesDTO;

        }
    }
}
