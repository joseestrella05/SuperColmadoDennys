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

            modelBuilder.Entity<Productos>().HasData(
                // Lácteos
                new Productos { Id = 1, Nombre = "Leche Entera", Precio = 200, Stock = 50, CodigoBarras = "1234567890123", CategoriaId = 1, EstaActivo = true, ImagenUrl = "/Imagen/LecheEntera.png" },
                new Productos { Id = 2, Nombre = "Yogur Natural", Precio = 300, Stock = 100, CodigoBarras = "1234567890124", CategoriaId = 1, EstaActivo = true, ImagenUrl = "/Imagen/YogurNatural.jpg" },
                // Panadería
                new Productos { Id = 3, Nombre = "Pan Integral", Precio = 60, Stock = 30, CodigoBarras = "9876543210987", CategoriaId = 2, EstaActivo = true, ImagenUrl = "/Imagen/PanIntegral.jpg" },
                new Productos { Id = 4, Nombre = "Croissant", Precio = 300, Stock = 40, CodigoBarras = "9876543210988", CategoriaId = 2, EstaActivo = true, ImagenUrl = "/Imagen/Croissants.jpg" },
                // Enlatados
                new Productos { Id = 5, Nombre = "Atún en lata", Precio = 400, Stock = 80, CodigoBarras = "5555555555555", CategoriaId = 3, EstaActivo = true, FechaVencimiento = new DateTime(2026, 12, 31), ImagenUrl = "/Imagen/Atun.jpg" },
                new Productos { Id = 6, Nombre = "Sardinas en tomate", Precio = 125, Stock = 60, CodigoBarras = "5555555555556", CategoriaId = 3, EstaActivo = true, FechaVencimiento = new DateTime(2026, 10, 15), ImagenUrl = "/Imagen/Sardina.jpg" },
                new Productos { Id = 7, Nombre = "Maíz enlatado", Precio = 70, Stock = 90, CodigoBarras = "5555555555557", CategoriaId = 3, EstaActivo = true, FechaVencimiento = new DateTime(2027, 3, 1), ImagenUrl = "/Imagen/Maiz.jpg" },
                // Bebidas
                new Productos { Id = 8, Nombre = "Agua Saratoga 1L", Precio = 500, Stock = 200, CodigoBarras = "1111111111111", CategoriaId = 4, EstaActivo = true , ImagenUrl = "/Imagen/AguaSaratoga.jpg" },
                new Productos { Id = 9, Nombre = "Coca Cola 2L", Precio = 80, Stock = 150, CodigoBarras = "1111111111112", CategoriaId = 4, EstaActivo = true , ImagenUrl = "/Imagen/Cocacola.jpg" },
                // Alcohol
                new Productos { Id = 10, Nombre = "Brugal ExtraViejo 700ml", Precio = 700, Stock = 100, CodigoBarras = "2222222222222", CategoriaId = 5, EstaActivo = true , ImagenUrl = "/Imagen/Brugar.jpg" },
                new Productos { Id = 11, Nombre = "Brugal Triple Reserva", Precio = 1060, Stock = 100, CodigoBarras = "2222222222223", CategoriaId = 5, EstaActivo = true , ImagenUrl = "/Imagen/TripleReserva.jpg" }
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