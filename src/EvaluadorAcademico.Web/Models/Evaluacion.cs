namespace EvaluadorAcademico.Web.Models
{
    public class Evaluacion
    {
        public string Matricula { get; set; } = string.Empty;

        public decimal Asistencia { get; set; }

        public decimal Actividades { get; set; }

        public decimal Practicas { get; set; }

        public decimal Examen { get; set; }

        public decimal Calificacion100 { get; set; }

        public decimal Calificacion10 { get; set; }

        public DateTime FechaRegistro { get; set; }
    }
}