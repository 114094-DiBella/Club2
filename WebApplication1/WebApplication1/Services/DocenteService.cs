using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Net;
using WebApplication1.Dtos;
using WebApplication1.Entities;
using WebApplication1.Interfaces.IRepository;
using WebApplication1.Interfaces.IService;
using WebApplication1.Query;
using WebApplication1.Repositories;
using WebApplication1.Response;

namespace WebApplication1.Services
{
    public class DocenteService : IDocenteService
    {
        private readonly IDocenteRepository _docenteRepository;
        private readonly IMapper _mapper;

        public DocenteService (IDocenteRepository docenteRepository, IMapper mapper)
        {
            _docenteRepository = docenteRepository;
            _mapper = mapper;
        }

        public async Task<bool> DeleteDocente(Guid id)
        {
            return await _docenteRepository.DeleteDocente(id);

        }

        public async Task<ApiResponse<List<DocenteDtoResponse>>> GetAll()
        {

            List<DocenteEntity> docenteEntities = await _docenteRepository.GetAll();
           
            List<DocenteDtoResponse> docenteDtoResponses = _mapper.Map<List<DocenteDtoResponse>>(docenteEntities);
           
            ApiResponse<List<DocenteDtoResponse>> apiResponse = new ApiResponse<List< DocenteDtoResponse>>();
           
            apiResponse.Data = docenteDtoResponses;

            return apiResponse;

        }   


        public async Task<ApiResponse<DocenteDtoResponse>> GetById(Guid id)
        {
               var docenteEntity = await _docenteRepository.GetById(id);
                ApiResponse<DocenteDtoResponse> apiResponse = new ApiResponse<DocenteDtoResponse>();
                if(docenteEntity == null)
                {
                apiResponse.SetError("No se encontro el docente", HttpStatusCode.BadRequest);
                return apiResponse;
                }
                
            apiResponse.Data = _mapper.Map<DocenteDtoResponse>(docenteEntity);
            return apiResponse;

        }

        public async Task<ApiResponse<DocenteDtoResponse>> PostDocente(DocenteQuery docente)
        {
            DocenteEntity docenteEntity = new DocenteEntity();
            RolesEntity rolesEntity = new RolesEntity();
            docenteEntity.Apellido = docente.Apellido.Trim();
            docenteEntity.Legajo = docente.Legajo.Trim();
            docenteEntity.Nombre = docente.Legajo.Trim();
            rolesEntity.Nombre = docente.Role.Trim();
            ApiResponse<DocenteDtoResponse> apiResponse = new ApiResponse<DocenteDtoResponse>();

            if (await _docenteRepository.findDocenteByLegajo(docente.Legajo.Trim())==true)
            {
                apiResponse.SetError("Ya existe un docente con ese legajo", HttpStatusCode.BadRequest);
                return apiResponse;
            }
            docenteEntity.Roles = rolesEntity;
            docenteEntity = await _docenteRepository.PostDocente(docenteEntity);
            DocenteDtoResponse docenteDtoResponse = _mapper.Map<DocenteDtoResponse>(docenteEntity);
            docenteDtoResponse.Role = rolesEntity.Nombre;
            apiResponse.Data = docenteDtoResponse;
            return apiResponse;
        }

        public Task<ApiResponse<DocenteDtoResponse>> UpdateDocente(DocenteDtoResponse entity)
        {
            throw new NotImplementedException();
        }
    }
}
