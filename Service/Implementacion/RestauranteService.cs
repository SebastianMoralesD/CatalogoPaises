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
    public class RestauranteService : IRestauranteService
    {
        private CatalogoPaisesContext dbcontextpaises;
        public RestauranteService(CatalogoPaisesContext context)
        {

            this.dbcontextpaises = context;

        }


        private ExpressionStarter<Restaurante> GetPredicate(RestauranteFilters search)
        {
            var predicate = PredicateBuilder.New<Restaurante>(true);

            if (search.PaisId != null)
            {
                predicate = predicate.And(x => x.Id == search.PaisId);
            }

            if (search.NombrePais != null)
            {
                predicate = predicate.And(x => x.Pais.NombrePais == search.NombrePais);
            }

            if (search.CodigoIso != null)
            {
                predicate = predicate.And(x => x.Pais.CodigoIso == search.CodigoIso);
            }

            if (search.restaurantename != null)
            {
                predicate = predicate.And(x => x.NombreRestaurante == search.restaurantename);
            }


            return predicate;
        }

        public async Task<IQueryable<RestauranteDTO>> GetRestaurantesAsync(RestauranteFilters filters)
        {
           

            var predicate = PredicateBuilder.New<Restaurante>(true);

            if (filters != null)
            {
                predicate = this.GetPredicate(filters);
            }


            var ListaRestaurantes = dbcontextpaises.Restaurantes.Where(predicate);

            IQueryable<RestauranteDTO> ListaHotelesDTO = ListaRestaurantes.Select(a => new RestauranteDTO
            {


                Idrestaurante = a.Id,
                NombreRestaurante = a.NombreRestaurante,
                Pais = new PaisesDTO { NombrePais = a.Pais.NombrePais, Id = a.Pais.Id, CodigoIso = a.Pais.CodigoIso }


            });


            return ListaHotelesDTO;

        }
    }
}
