using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

public class AppContext : DbContext
{
  public AppContext(DbContextOptions<AppContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Clientes>(clientes =>
    {
      clientes.ToTable("Clientes");
      clientes.HasKey(c => c.ClienteID);

      clientes.Property(c => c.Nombre)
        .IsRequired()
        .HasMaxLength(100);

      clientes.Property(c => c.Ciudad)
        .IsRequired()
        .HasMaxLength(100);
        
      clientes.Property(c => c.CorreoElectronico)
        .IsRequired();
    });

    modelBuilder.Entity<Productos>(productos =>
    {
      productos.ToTable("Productos");
      productos.HasKey(p => p.ProductoID);

      productos.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(100);

      productos.Property(p => p.Precio)
        .IsRequired();

    });

    modelBuilder.Entity<Pedidos>(pedidos =>
    {
      pedidos.ToTable("Pedidos");
      pedidos.HasKey(p => p.PedidosID);

      pedidos.HasOne(p => p.Cliente)
        .WithMany(c => c.Pedidos)
        .HasForeignKey(p => p.ClienteID)
        .IsRequired();

      pedidos.HasOne(p => p.Producto)
        .WithMany(c => c.Pedidos)
        .HasForeignKey(p => p.ProductoID)
        .IsRequired();

      pedidos.Property(p => p.Cantidad)
        .IsRequired();

      pedidos.Property(p => p.Fecha)
        .IsRequired();
      
    });
  }

  public DbSet<Clientes> clientes { get; set; }
  public DbSet<Productos> productos { get; set; }
  public DbSet<Pedidos> pedidos { get; set; }
}