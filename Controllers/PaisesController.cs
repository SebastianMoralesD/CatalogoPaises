using Azure;
using CatalogoPaises.DB;
using CatalogoPaises.DTOS;
using CatalogoPaises.Filters;
using CatalogoPaises.Service.Contrato;
using CatalogoPaises.Service.Implementacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CatalogoPaises.Controllers
{

    [Route("api/[controller]")]
    [EnableCors("CorsConfig")]
    [ApiController]

    public class PaisesController: ControllerBase   
    {
        private IPaisesService paisesService;

        public PaisesController(IPaisesService paisesService) {
            
            this.paisesService = paisesService; 
        
        }


        [HttpGet("ObtenerListaPaises")]
        public async Task<ApiResponse<IEnumerable<PaisesDTO>>> GetList([FromQuery] CountryFilters Filters)

        {
            IQueryable<PaisesDTO> entities = await this.paisesService.GetPaisesAsync(Filters);

            PagedList<PaisesDTO> ListaPaises = PagedList<PaisesDTO >.Create(entities,
            Filters.pageindex ?? 1,
            Filters.pagesize ?? entities.Count());


            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(ListaPaises.Metadata()));
            return new ApiResponse<IEnumerable<PaisesDTO>>(ListaPaises.Data);

         
         }
    }
}
