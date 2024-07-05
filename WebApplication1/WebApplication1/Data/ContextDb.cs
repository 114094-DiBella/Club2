using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Data
{
    public class ContextDb :DbContext
    {
      
            public ContextDb(DbContextOptions<ContextDb> options) : base(options)
            {

            }

            public DbSet<AlumnoEntity> Alumnos { get; set; }
            public DbSet<AlumnoCursoEntity> AlumnoCurso { get; set; }
            public DbSet<CarreraEntity> Carrera { get; set; }
            public DbSet<CursoEntity> Curso { get; set; }
            public DbSet<DocenteCursoEntity> DocenteCursos { get; set; }
            public DbSet<DocenteEntity> Docente { get; set; }

            public DbSet<RolesEntity> Roles { get; set; }
            public DbSet<UsuarioEntity> Usuarios { get; set; }
        }
}
