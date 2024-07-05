using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    [Table("DocenteCurso")]
    public class DocenteCursoEntity
    {
        [Key]
        public Guid Id { get; set; }

        public Guid IdCurso { get; set; }
        [ForeignKey("IdCurso")] public CursoEntity Curso { get; set; }

        public Guid IdDocente { get; set; }
        [ForeignKey("IdDocente")] public DocenteEntity Docente { get; set; }

        public DateTime FechaAlta { get; set; }
    }
}

