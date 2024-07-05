using AutoMapper;
using System.Net;
using WebApplication1.Dtos;
using WebApplication1.Entities;
using WebApplication1.Interfaces.IRepository;
using WebApplication1.Interfaces.IService;
using WebApplication1.Response;

namespace WebApplication1.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IMapper _mapper;

        public CursoService(ICursoRepository cursoRepository, IMapper mapper)
        {
            _cursoRepository = cursoRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<CursoDto>>> getAll()
        {
            List<DocenteCursoEntity> cursosDocenteEntities = await _cursoRepository.GetAllCursos();
            List<CursoDto> cursos = new List<CursoDto>();
            foreach (var item in cursosDocenteEntities)
            {
                CursoDto curso = new CursoDto();
                DocenteDtoResponse docente = new DocenteDtoResponse();
                docente.Apellido = item.Docente.Apellido;
                docente.Nombre = item.Docente.Nombre;
                docente.Legajo = item.Docente.Legajo;
                curso.Docente = docente;
                curso.Curso = item.Curso.Nombre;
                curso.Horarios = item.Curso.Horarios;
                curso.id = item.Curso.Id;
                cursos.Add(curso);

            }
            ApiResponse<List<CursoDto>> apiResponse = new ApiResponse<List<CursoDto>>();
            apiResponse.Data = cursos;
            if (cursos.Count() == 0)
            {
                apiResponse.SetError("No hay cursos en la base de datos", HttpStatusCode.BadRequest);
                return apiResponse;
            }
            return apiResponse;
        }
    }
}
