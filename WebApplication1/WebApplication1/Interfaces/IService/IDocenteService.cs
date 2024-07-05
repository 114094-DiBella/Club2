using WebApplication1.Dtos;
using WebApplication1.Entities;
using WebApplication1.Query;
using WebApplication1.Response;

namespace WebApplication1.Interfaces.IService
{
    public interface IDocenteService
    {
        Task<ApiResponse< DocenteDtoResponse>> GetById(Guid id);

        Task<ApiResponse< List  <DocenteDtoResponse>>> GetAll();
        Task<ApiResponse<DocenteDtoResponse>> PostDocente(DocenteQuery entity);

        Task<ApiResponse<DocenteDtoResponse>> UpdateDocente(DocenteDtoResponse entity);

        Task<Boolean> DeleteDocente(Guid id);

    }
}
