using WebApplication1.Entities;

namespace WebApplication1.Interfaces.IRepository
{
    public interface IDocenteRepository
    {
        Task<DocenteEntity> GetById(Guid id);

        Task<List<DocenteEntity>> GetAll();
        Task<DocenteEntity> PostDocente(DocenteEntity entity);

        Task<DocenteEntity> UpdateDocente(DocenteEntity entity);

        Task<Boolean> DeleteDocente(Guid id);

        Task<Boolean> findDocenteByLegajo(string email);

    }
}
