using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    [Table("Docentes")]
    public class DocenteEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Legajo { get; set; }

        public Guid IdRole { get; set; }

        [ForeignKey("IdRole")]
        public RolesEntity Roles { get; set; }
    }
}
