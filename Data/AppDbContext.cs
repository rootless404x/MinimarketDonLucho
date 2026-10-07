using Microsoft.EntityFrameworkCore;
using MinimarketDonLucho.Models;

namespace MinimarketDonLucho.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Producto> Productos => Set<Producto>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Producto>()
            .HasOne(p => p.Categoria)
            .WithMany(c => c.Productos)
            .HasForeignKey(p => p.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);

        // Datos iniciales
        modelBuilder.Entity<Categoria>().HasData(
            new { Id = 1, Nombre = "Abarrotes" },
            new { Id = 2, Nombre = "Bebidas" },
            new { Id = 3, Nombre = "Lácteos" },
            new { Id = 4, Nombre = "Limpieza" });

        modelBuilder.Entity<Producto>().HasData(
            new { Id = 1, Nombre = "Arroz extra 5 kg", Precio = 24.90m, Stock = 18, FechaVencimiento = (DateTime?)null, CategoriaId = 1 },
            new { Id = 2, Nombre = "Aceite vegetal 1 L", Precio = 11.50m, Stock = 3, FechaVencimiento = (DateTime?)null, CategoriaId = 1 },
            new { Id = 3, Nombre = "Azúcar rubia 1 kg", Precio = 4.20m, Stock = 25, FechaVencimiento = (DateTime?)null, CategoriaId = 1 },
            new { Id = 4, Nombre = "Gaseosa 1.5 L", Precio = 7.50m, Stock = 0, FechaVencimiento = (DateTime?)new DateTime(2027, 3, 15), CategoriaId = 2 },
            new { Id = 5, Nombre = "Agua mineral 625 ml", Precio = 1.80m, Stock = 40, FechaVencimiento = (DateTime?)new DateTime(2027, 6, 30), CategoriaId = 2 },
            new { Id = 6, Nombre = "Leche evaporada 400 g", Precio = 4.10m, Stock = 30, FechaVencimiento = (DateTime?)new DateTime(2027, 1, 20), CategoriaId = 3 },
            new { Id = 7, Nombre = "Yogurt de fresa 1 L", Precio = 7.90m, Stock = 5, FechaVencimiento = (DateTime?)new DateTime(2026, 11, 10), CategoriaId = 3 },
            new { Id = 8, Nombre = "Detergente 750 g", Precio = 9.80m, Stock = 12, FechaVencimiento = (DateTime?)null, CategoriaId = 4 });
    }
}
