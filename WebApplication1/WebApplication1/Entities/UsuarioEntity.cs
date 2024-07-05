using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{

    [Table("Usuarios")]
    public class UsuarioEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Email { get; set; }

        public string contrasenia { get; set; }

        public Guid IdRol { get; set; }

        [ForeignKey ("IdRol")] public RolesEntity Roles { get; set; }

    }
}
