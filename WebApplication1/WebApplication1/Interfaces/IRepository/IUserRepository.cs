using WebApplication1.Entities;

namespace WebApplication1.Interfaces.IRepository
{
    public interface IUserRepository
    {
        public Task<UsuarioEntity> GetUsuario(UsuarioEntity user);
    }
}
