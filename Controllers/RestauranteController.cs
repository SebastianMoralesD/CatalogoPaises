using Azure;
using CatalogoPaises.DTOS;
using CatalogoPaises.Filters;
using CatalogoPaises.Service.Contrato;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CatalogoPaises.Controllers
{
    

        [Route("api/[controller]")]
        [EnableCors("CorsConfig")]
        [ApiController]

        public class RestauranteController : ControllerBase
        {
            private IRestauranteService restauranteService ;

            public RestauranteController(IRestauranteService restauranteService)
            {
                this.restauranteService = restauranteService;
            }

            [HttpGet("ObtenerListaRestaurantes")]
            public async Task<ApiResponse<IEnumerable<RestauranteDTO>>> GetList([FromQuery] RestauranteFilters Filters)

            {
                IQueryable<RestauranteDTO> entities = await this.restauranteService.GetRestaurantesAsync(Filters);

                PagedList<RestauranteDTO> ListaRestaurantes = PagedList<RestauranteDTO>.Create(entities,
                Filters.pageindex ?? 1,
                Filters.pagesize ?? entities.Count());


                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(ListaRestaurantes.Metadata()));
                return new ApiResponse<IEnumerable<RestauranteDTO>>(ListaRestaurantes.Data);


            }
        }
    
}
