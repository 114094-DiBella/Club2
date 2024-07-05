using WebApplication1.Dtos;
using WebApplication1.Response;

namespace WebApplication1.Interfaces.IService
{
    public interface ICursoService
    {
        Task<ApiResponse<List<CursoDto>>> getAll();
    }
}
