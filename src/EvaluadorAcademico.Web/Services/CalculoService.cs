using EvaluadorAcademico.Web.Models;

namespace EvaluadorAcademico.Web.Services
{
    public class CalculoService
    {
        public Evaluacion Calcular(
            Evaluacion evaluacion,
            ParametrosEvaluacion parametros)
        {
            decimal asistencia =
                (evaluacion.Asistencia /
                parametros.AsistenciaMaxima)
                * parametros.PorcentajeAsistencia;

            decimal actividades =
                (evaluacion.Actividades /
                parametros.ActividadesMaximas)
                * parametros.PorcentajeActividades;

            decimal practicas =
                (evaluacion.Practicas /
                parametros.PracticasMaximas)
                * parametros.PorcentajePracticas;

            decimal examen =
                (evaluacion.Examen /
                parametros.ExamenMaximo)
                * parametros.PorcentajeExamen;

            evaluacion.Calificacion100 =
                asistencia +
                actividades +
                practicas +
                examen;

            evaluacion.Calificacion10 =
                evaluacion.Calificacion100 / 10;

            return evaluacion;
        }
    }
}