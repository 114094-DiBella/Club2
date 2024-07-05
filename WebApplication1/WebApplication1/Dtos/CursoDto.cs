namespace WebApplication1.Dtos
{
    public class CursoDto
    {
        public Guid id { get; set; }
        public string Curso { get; set; }

        public string Horarios { get; set; }

        public DocenteDtoResponse Docente { get; set; }

    }
}
