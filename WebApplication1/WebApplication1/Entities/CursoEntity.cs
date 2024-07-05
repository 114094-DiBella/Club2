using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    [Table("Cursos")]
    public class CursoEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string Horarios { get; set; }

        public Guid IdCarrera { get; set; }
        
        [ForeignKey ("IdCarrera")] public CarreraEntity Carrera { get; set; }

    }
}