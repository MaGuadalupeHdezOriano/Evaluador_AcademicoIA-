Usuario 
↓ 
App Service 
↓ 
ASP.NET Core 
↓ 
Azure SQL

La aplicación es ASP.NET Core MVC. ASP.NET Core Identity controla el acceso docente; Entity Framework Core persiste alumnos, evaluaciones, configuración y usuarios en SQL Server/Azure SQL. La exportación `.xlsx` se genera en el servidor.

La integración con Azure AI Foundry no forma parte del flujo transaccional de calificaciones y no está conectada en esta versión.