using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Interfaces.IRepository;

namespace WebApplication1.Repositories
{
    public class UsuarioRepository : IUserRepository
    {
        private readonly ContextDb _contextDb;

        public UsuarioRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        public async Task<UsuarioEntity> GetUsuario(UsuarioEntity user)
        {
            var usuario = await _contextDb.Usuarios.Include(u =>u.Roles).FirstOrDefaultAsync(u => u.Email == user.Email);
            if (usuario == null) {
                throw new Exception("No Existe el usuario");
            }
            return usuario;

        }
    }
}
