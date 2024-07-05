using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Interfaces.IService;
using WebApplication1.Query;
using WebApplication1.Response;
using WebApplication1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteController : ControllerBase
    {
        IDocenteService _docenteService;
        
        public DocenteController(IDocenteService docenteService)
        {
            _docenteService = docenteService;
        }

        // GET: api/<ValuesController>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ApiResponse<List<DocenteDtoResponse>>> Get()
        {

            return await _docenteService.GetAll();
        }

        // GET api/<ValuesController>/5
        [Authorize(Roles = "Docente")]
        [HttpGet("{id}")]
        public async Task<ApiResponse<DocenteDtoResponse>> Get([FromHeader(Name = "id")] Guid id)
        {
            return await _docenteService.GetById(id);
        }

        // POST api/<ValuesController>
        [Authorize(Roles = "Docente")]
        [HttpPost]
        public async Task<ApiResponse< DocenteDtoResponse>> Post([FromBody] DocenteQuery docente)
        {
            return await _docenteService.PostDocente(docente);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
