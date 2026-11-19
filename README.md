# Evaluador Académico

Aplicación web ASP.NET Core MVC para que docentes administren alumnos, configuren ponderaciones, capturen y consulten calificaciones y exporten todas las evaluaciones a Excel.

## Requisitos

- .NET 10 SDK
- SQL Server o Azure SQL

## Ejecución local

1. En `src/appsettings.json`, configura `ConnectionStrings:DefaultConnection` para una instancia de SQL Server disponible en tu equipo.
2. Define las credenciales de la primera cuenta docente mediante variables de entorno. La contraseña debe tener al menos 12 caracteres e incluir mayúsculas, minúsculas, números y caracteres especiales:

   ```powershell
   $env:Admin__Email = "docente@ejemplo.edu"
   $env:Admin__Password = "<contraseña segura>"
   ```

3. Desde la carpeta `src`, ejecuta:

   ```powershell
   dotnet run
   ```

La aplicación aplica las migraciones y crea los porcentajes iniciales al iniciar. La configuración de Azure App Service debe incluir `ConnectionStrings__DefaultConnection`, `Admin__Email` y `Admin__Password` como valores de configuración protegidos. No guardes contraseñas ni cadenas de conexión en el repositorio.

## Funcionalidades

- Inicio de sesión docente con bloqueo temporal ante intentos fallidos.
- Alta, baja lógica y reactivación de alumnos; las bajas conservan el historial.
- Captura, consulta, búsqueda y modificación de calificaciones.
- Porcentajes editables con validación de suma igual a 100%; al guardarlos se recalculan todas las evaluaciones.
- Descarga de todas las calificaciones en un archivo `.xlsx`.
- Calificación final en escala de 0 a 10, calculada a partir de los puntajes máximos definidos en [docs/Reglas_Evaluacion.md](docs/Reglas_Evaluacion.md).

## Persistencia y despliegue

La aplicación usa ASP.NET Core Identity y Entity Framework Core con SQL Server/Azure SQL. El inicio aplica las migraciones incluidas; los cambios futuros al esquema deben agregarse como migraciones y aplicarse durante el despliegue.

## Pruebas

Desde la raíz del repositorio ejecuta `dotnet test tests/EvaluadorAcademico.Tests.csproj`.