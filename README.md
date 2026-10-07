# Minimarket Don Lucho

Caso práctico del curso **Aplicaciones Web** (Semana 9): sistema de inventario en ASP.NET Core MVC (.NET 8) con Entity Framework Core Code First y SQL Server LocalDB.

> Este proyecto se entrega **con errores** a propósito. Tu tarea es probarlo, redactar casos de prueba y registrar las incidencias que encuentres. No corrijas nada hasta tener tu lista de incidencias.

## Requisitos

- Visual Studio 2022 (17.8 o superior) con la carga de trabajo *Desarrollo de ASP.NET y web*
- SDK de .NET 8
- SQL Server Express LocalDB (se instala con Visual Studio)

## Cómo ejecutarlo

1. Abre `MinimarketDonLucho.csproj` en Visual Studio.
2. Abre **Herramientas > Administrador de paquetes NuGet > Consola del Administrador de paquetes**.
3. Ejecuta:
   ```
   Add-Migration Inicial
   Update-Database
   ```
4. Presiona **F5**. La aplicación abre en `https://localhost:7180`.

Con la CLI de .NET:

```
dotnet tool install --global dotnet-ef
dotnet ef migrations add Inicial
dotnet ef database update
dotnet run
```

## Datos iniciales

La migración carga 4 categorías y 8 productos de ejemplo.

## Estructura

```
Controllers/   HomeController, ProductosController, CategoriasController
Data/          AppDbContext (DbSets y datos iniciales)
Models/        Producto, Categoria
Views/         Vistas Razor por controlador y _Layout compartido
```
