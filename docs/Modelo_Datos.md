# Modelo de datos

## Estudiante

- `Id`: identificador interno.
- `Matricula`: matrícula única.
- `Nombre`: nombre completo.
- `Grupo`: grupo académico.
- `Activo`: indica si el alumno está activo; la baja es lógica.
- `FechaRegistro`: fecha de alta.

## Evaluación

- `Id`: identificador interno.
- `StudentId`: relación con el alumno.
- `Asignatura`: nombre de la asignatura.
- `Corte`: periodo o corte evaluado.
- `Asistencia`, `Actividades`, `Practicas`, `Examen`: puntajes obtenidos.
- `CalificacionFinal`: resultado calculado en escala de 0 a 10.
- `FechaRegistro` y `FechaActualizacion`: fechas de creación y última modificación.

Cada alumno tiene como máximo una evaluación por asignatura y corte.

## Configuración de evaluación

Un registro contiene los porcentajes de asistencia, actividades, prácticas y examen. La suma debe ser exactamente 100%; al modificarla se recalculan las calificaciones existentes.

## Usuario docente

Los usuarios se administran mediante ASP.NET Core Identity. No se permite el registro público.

## Reglas de integridad

- La matrícula es única.
- Las evaluaciones se conservan al dar de baja a un alumno.
- Los puntajes se validan contra los máximos definidos en [Reglas_Evaluacion.md](Reglas_Evaluacion.md).