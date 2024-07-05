using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Interfaces.IService;
using WebApplication1.Response;
using WebApplication1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly  ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        // GET: api/<ValuesController>
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public async Task< ApiResponse<List<CursoDto>>> Get()
        {
            return await _cursoService.getAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
