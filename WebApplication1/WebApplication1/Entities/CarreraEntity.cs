using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    [Table("Carreras")]
    public class CarreraEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Nombre { get; set; }
    }
}
