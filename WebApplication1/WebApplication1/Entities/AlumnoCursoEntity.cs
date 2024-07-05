using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    [Table("AlumnosCurso")]
    public class AlumnoCursoEntity
    {
        [Key]
        public Guid Id { get; set; }

        public Guid IdCurso { get; set; }

        [ForeignKey("IdCurso")] public CursoEntity Curso { get; set; }
        public Guid IdProfesor { get; set; }

        [ForeignKey("IdProfesor")] public DocenteEntity Docente { get; set; }
        public DateTime FechaAlta { get; set; }
   

    }
}