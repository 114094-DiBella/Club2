using WebApplication1.Entities;

namespace WebApplication1.Interfaces.IRepository
{
    public interface ICursoRepository
    {
        Task<List<DocenteCursoEntity>> GetAllCursos();
        

    }
}
