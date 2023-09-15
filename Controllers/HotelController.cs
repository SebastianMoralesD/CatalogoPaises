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

        public class HotelController : ControllerBase
        {
            private IHotelService hotelService ;

        public HotelController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        [HttpGet("ObtenerListaHoteles")]
            public async Task<ApiResponse<IEnumerable<HotelesDTO>>> GetList([FromQuery] HotelesFilters Filters)

            {
                IQueryable<HotelesDTO> entities = await this.hotelService.GetHotelesAsync(Filters);

                PagedList<HotelesDTO> ListaHoteles = PagedList<HotelesDTO>.Create(entities,
                Filters.pageindex ?? 1,
                Filters.pagesize ?? entities.Count());


                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(ListaHoteles.Metadata()));
                return new ApiResponse<IEnumerable<HotelesDTO>>(ListaHoteles.Data);


            }
        }
    
}
