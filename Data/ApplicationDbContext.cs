using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperColmadoDennys.Models;

namespace SuperColmadoDennys.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Provedores> Provedores { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<ComprasDetalles> ComprasDetalles { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<Ordenes> Ordenes { get; set; }
        public DbSet<OrdenItem> OrdenItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Llama a la configuración base de IdentityDbContext
            base.OnModelCreating(modelBuilder);

            // Configuración de la entidad Categoria
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("Categorias");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Nombre)
                      .IsRequired()
                      .HasMaxLength(50)
                      .HasColumnType("nvarchar(50)");
                entity.Property(c => c.Descripcion)
                      .HasMaxLength(200)
                      .HasColumnType("nvarchar(200)");
                entity.HasIndex(c => c.Nombre)
                      .IsUnique()
                      .HasDatabaseName("IX_Categorias_Nombre");
            });

            // Configuración de la entidad Producto
            modelBuilder.Entity<Productos>(entity =>
            {
                entity.ToTable("Productos");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Nombre)
                      .IsRequired()
                      .HasMaxLength(100)
                      .HasColumnType("nvarchar(100)");
                entity.Property(p => p.Descripcion)
                      .HasMaxLength(500)
                      .HasColumnType("nvarchar(500)");
                entity.Property(p => p.Precio)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)");
                entity.Property(p => p.Stock)
                      .IsRequired();
                entity.Property(p => p.CodigoBarras)
                      .IsRequired()
                      .HasMaxLength(13)
                      .HasColumnType("varchar(13)");
                entity.HasIndex(p => p.CodigoBarras)
                      .IsUnique()
                      .HasDatabaseName("IX_Productos_CodigoBarras");
                entity.HasOne(p => p.Categoria)
                      .WithMany(c => c.Productos)
                      .HasForeignKey(p => p.CategoriaId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Datos iniciales
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nombre = "Lácteos", Descripcion = "Productos derivados de la leche", EstaActiva = true },
                new Categoria { Id = 2, Nombre = "Panadería", Descripcion = "Productos de pan y repostería", EstaActiva = true },
                new Categoria { Id = 3, Nombre = "Enlatados", Descripcion = "Productos enlatados y conservas", EstaActiva = true },
                new Categoria { Id = 4, Nombre = "Bebidas", Descripcion = "Bebidas no alcohólicas", EstaActiva = true },
                new Categoria { Id = 5, Nombre = "Alcohol", Descripcion = "Bebidas alcohólicas", EstaActiva = true } // Corregí "Alchol" a "Alcohol"
            );

            modelBuilder.Entity<Provedores>().HasData(
               new Provedores { ProvedorId = 1, Nombre = "Induveca", Direccion = "calle jino negrin", Telefono = "8098444618", Correo = "servicioalcliente@induveca.com.do." },
               new Provedores { ProvedorId = 2, Nombre = "Nestle", Direccion = "Carretera nagua", Telefono = "8095882870", Correo = "servicios.consumidor@do.nestle.com." },
               new Provedores { ProvedorId = 3, Nombre = "Baldom", Direccion = "calle jino negrin", Telefono = "8092002108", Correo = "atencion.consumidor@baldom.net" },
               new Provedores { ProvedorId = 4, Nombre = "Cerveceria nacional", Direccion = "calle hermana mirabal", Telefono = "8094873200", Correo = "servicioalcliente@CND.com.do." },
               new Provedores { ProvedorId = 5, Nombre = "Yoma", Direccion = "Avenida libertad", Telefono = "8095884606", Correo = "servicioalcliente@Yoma.com.do." }
            );

            modelBuilder.Entity<Estados>().HasData(
                new Estados { EstadoId = 1, Nombre = "Pendiente" },
                new Estados { EstadoId = 2, Nombre = "Completada" },
                new Estados { EstadoId = 3, Nombre = "Cancelada" }
            );


        }
    }
}