using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    [Table("Roles")]
    public class RolesEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }
    }
}
