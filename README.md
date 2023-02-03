# API CRM CUSTOM

API CRM CUSTOM es un programa de Gestión de la Relación con el Cliente desarrollado en C# Entity Framework con base de datos PostgreSQL.

# Entorno de Desarrollo
## 1. Requerimientos

- **Visual Studio 2022** (IDE) - [Descargar](https://visualstudio.microsoft.com/es/)
  
  Elegir las siguientes opciones **antes** de empezar a instalar:
  - [x] Desarrollo de ASP.NET y web
  - [x] Desarrollo de Escritorio de .NET
  
- **Entity Framework 6 (EF6)** - (Paquete NuGet)
- **PostgreSQL version 15.1** (Base de Datos) - [Descargar](https://www.postgresql.org/download/)
- **DBeaver** (Sistema de Gestión de Base de Datos) - [Descargar](https://dbeaver.io/download/)
***
## 1.1. Instalación y Configuración
### **Clonar Proyecto**

- Ejecutar el siguiente comando en la terminal (cmd, Powershell, Git Bash) en un directorio de preferencia.
```
  git clone http://192.168.121.211:3000/administrador/api-crm-custom.git
```
Una vez finalizado, se creará una carpeta llamada "api-crm-custom".

- Abrir Visual Studio, elegir "Abrir un proyecto o solución", buscar el proyecto clonado previamente y abrir el archivo **crm-custom2.sln**.
***
## 1.2. Librerías y Dependencias (NuGet)

  | Descripción  | Versión |
  | ------------- | ------------- |
  | AutoMapper.Extensions.Microsoft.DependencyInjection  | {11.0.0}   |
  | CsvHelper  | {27.2.1}  |
  | DotNetZip | {1.16.0}  |
  | EFCore.BulkExtensions | {6.4.4} |
  | EntityFramework 6 | {6.4.4}  |
  | Enums.NET | {4.0.0} |
  | FluentValidation.AspNetCore | {11.0.1} |
  | Handlebars.Net | {2.1.2} |
  | Hangfire.AspNetCore | {1.8.0-beta4} |
  | Hangfire.Core | {1.8.0-beta4}  |
  | Hangfire.PostgreSql | {1.9.7} |
  | Humanizer.Core | {2.14.1} |
  | IdentityModel | {6.0.0} |
  | Labmem.EntityFrameworkCorePlus | {1.0.0-rc3} |
  | Microsoft.AspNetCore.Authentication.JwtBearer | {3.1.2} |
  | Microsoft.AspNetCore.Mvc.Versioning | {4.1.1} |
  | Microsoft.EntityFrameworkCore.Design | {7.0.0-preview.1.22076.6} |
  | Microsoft.EntityFrameworkCore.Tools | {6.0.6} |
  | Microsoft.Extensions.DependencyInjection.Abstractions | {2.2.0} |
  | Npgsql | {7.0.0-preview.1} |
  | Npgsql.EntityFrameworkCore.PostgreSQL |  {7.0.0-preview.1} |
  | ObjectsComparer | {1.4.1} |
  | SendGrid | {9.28.0} |
  | Serilog | {2.9.0} |
  | Serilog.AspNetCore | {3.2.0} |
  | Serilog.Enrichers.Process | {2.0.1} |
  | Serilog.Enrichers.Thread | {3.1.0} |
  | Serilog.Settings.Configuration | {3.1.0} |
  | Serilog.Sinks.MongoDB | {4.0.0} |
  | Serilog.Sinks.Seq | {4.0.0} |
  | Swashbuckle.AspNetCore | {5.0.0} |
  | System.IdentityModel.Tokens.Jwt | {5.6.0} |
***
## 1.3. Base de Datos
**Abrir DBeaver**
  - Crear una nueva conexion de base de datos
  - Seleccionar PostgreSQL
  - Ingresar los siguientes datos en sus respectivos campos:
```
  Host=192.168.121.16
  Database=crm-desa
  Username=root
  Password=Wer.2022
```
***
## 1.4. Migración y Actualización de Base de Datos
Abrir **Terminal** (Ctrl+Ñ), y ejecutar los siguientes comandos:

- **Para crear una nueva migración:**
```
    dotnet ef migrations add nombreDescriptivo
```
 Las migraciones hacen un seguimiento de los cambios en la estructura de la base de datos a lo largo del tiempo.

- **Para agregar migración a la base de datos:**

```
    dotnet ef database update
```

  Este comando crea la base de datos si no existe, como tambien aplica la última migración creada a la base de datos.
***
## 1.5. Utilizar la API
Luego de ejecutar el programa, para utlizar, probar la API es necesario iniciar sesión, para ello:
- Abrir cualquier Navegador Web de su preferencia e ingresar la siguiente URL
```
  http://localhost:5000/swagger/index.html
```
Una vez dentro, ir hasta "/v1/api/users/login" e ingresar la siguiente información:
```
{
  "userName": "luis.samudio@clt.com.py",
  "password": "admin"
}
```
Como respuesta, se generará un token de acceso en el campo **access_token**, ir hasta el botón **Authorize** que se encuentra en la parte superior de la página e ingresar el token.

***
## License
[CLT S.A](https://www.linkedin.com/company/cltsa/)
