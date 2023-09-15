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
    public class HotelesService : IHotelService
    {
        private CatalogoPaisesContext dbcontextpaises;
        public HotelesService(CatalogoPaisesContext context){
            
            this.dbcontextpaises = context;
        
        }

        private ExpressionStarter<Hotele> GetPredicate(HotelesFilters search)
        {
            var predicate = PredicateBuilder.New<Hotele>(true);

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

            if (search.hotelesname != null)
            {
                predicate = predicate.And(x => x.NombreHotel == search.hotelesname);
            }


            return predicate;
        }


        public async Task<IQueryable<HotelesDTO>> GetHotelesAsync(HotelesFilters filters)
        {
           

            var predicate = PredicateBuilder.New<Hotele>(true);

            if (filters != null)
            {
                predicate = this.GetPredicate(filters);
            }


            var ListaHoteles = dbcontextpaises.Hoteles.Where(predicate);

            IQueryable<HotelesDTO> ListaHotelesDTO = ListaHoteles.Select(a => new HotelesDTO
            {


                IdHotel = a.Id,
                NombreHotel = a.NombreHotel,
                Pais = new PaisesDTO { NombrePais = a.Pais.NombrePais, Id = a.Pais.Id, CodigoIso = a.Pais.CodigoIso}


            });
         

            return ListaHotelesDTO;

        }
    }
}
