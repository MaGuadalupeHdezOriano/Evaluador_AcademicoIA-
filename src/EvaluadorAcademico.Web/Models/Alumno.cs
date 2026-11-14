namespace EvaluadorAcademico.Web.Models
{
    public class Alumno
    {
        public string Matricula { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public string Grupo { get; set; } = string.Empty;

        public string Asignatura { get; set; } = string.Empty;

        public string Estatus { get; set; } = "Activo";
    }
}
