using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Interfaces.IRepository;

namespace WebApplication1.Repositories
{
    public class DocenteRepository : IDocenteRepository
    {
        private readonly ContextDb _contextDb;

        public DocenteRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        public async Task<Boolean> DeleteDocente(Guid id)
        {
            var docente = await _contextDb.Docente.FindAsync(id);
            if (docente == null)
            {
                return false; 
            }

            _contextDb.Docente.Remove(docente);
            await _contextDb.SaveChangesAsync();
            return true;
        }

        public async Task<bool> findDocenteByLegajo(string email)
        {
            var docente = await _contextDb.Docente.FirstOrDefaultAsync(d => d.Legajo == email);
            if(docente == null) {
                return false;
               
            }
            return true;

        }

        public async Task<List<DocenteEntity>> GetAll()
        {
            return await _contextDb.Docente.Where(docente => docente.Apellido != "Docente").ToListAsync();
        }

        public async Task<DocenteEntity> GetById(Guid id) { 
            return await _contextDb.Docente.FindAsync(id);
        }

        public async Task<DocenteEntity> PostDocente(DocenteEntity entity)
        {
            var roles = await _contextDb.Roles.FirstOrDefaultAsync(roles=>roles.Nombre == entity.Roles.Nombre);
            if (roles == null)
            {
                throw new Exception("no exciste el rol");
            }
            entity.Roles = roles;
            _contextDb.Docente.Add(entity);
            await _contextDb.SaveChangesAsync();
            return entity;
        }

        public async Task<DocenteEntity> UpdateDocente(DocenteEntity entity)
        {
            _contextDb.Docente.Update(entity);
            await _contextDb.SaveChangesAsync();
            var doc = await _contextDb.Docente.FirstOrDefaultAsync(doc => doc.Id == entity.Id);

            return doc;
        }

        public async Task<DocenteEntity> getByID(Guid id)
        {
   
            var doc = await _contextDb.Docente.FirstOrDefaultAsync(doc => doc.Id == id);
            return doc;
        }


    }
}
