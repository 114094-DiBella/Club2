using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Interfaces.IRepository;

namespace WebApplication1.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly  ContextDb _contextDb;

        public CursoRepository(ContextDb contextDb) {
            _contextDb = contextDb;
        }
        
        public async Task<List<DocenteCursoEntity>> GetAllCursos()
        {

          List<DocenteCursoEntity> docentesCursosEntity = await _contextDb.DocenteCursos.Include(c => c.Docente)
                .ThenInclude(d=>d.Roles)
                .Include(c => c.Curso).Where(c=>c.FechaAlta<DateTime.Now).ToListAsync();
            return docentesCursosEntity;
        }
    }
}
