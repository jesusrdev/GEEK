using GEEK.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GEEK.Data
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrito> Carrito { get; set; } = null!;
        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<EstadoOrden> EstadoOrden { get; set; } = null!;
        public virtual DbSet<EstadoProducto> EstadoProducto { get; set; } = null!;
        public virtual DbSet<Imagen> Imagen { get; set; } = null!;
        public virtual DbSet<Marca> Marca { get; set; } = null!;
        public virtual DbSet<Orden> Orden { get; set; } = null!;
        public virtual DbSet<Producto> Producto { get; set; } = null!;
        public virtual DbSet<Rol> Rol { get; set; } = null!;
        public virtual DbSet<Usuario> Usuario { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // chatgpt error identity


            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasKey(e => e.IdCarrito)
                    .HasName("PK__Carrito__7AF85448DBBC2CB4");

                entity.ToTable("Carrito");

                entity.Property(e => e.IdCarrito)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idCarrito")
                    .IsFixedLength();

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdProducto)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idProducto")
                    .IsFixedLength();

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idUsuario")
                    .IsFixedLength();

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK_Carrito_Producto");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Carrito_Usuario");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__8A3D240C0906EB00");

                entity.Property(e => e.IdCategoria)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idCategoria")
                    .IsFixedLength();

                entity.Property(e => e.DescripcionCategoria)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcionCategoria");
            });

            modelBuilder.Entity<EstadoOrden>(entity =>
            {
                entity.HasKey(e => e.IdEstadoOrden)
                    .HasName("PK__EstadoOr__9CDE093F84FDE170");

                entity.ToTable("EstadoOrden");

                entity.Property(e => e.IdEstadoOrden)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idEstadoOrden")
                    .IsFixedLength();

                entity.Property(e => e.NombreEstadoOrden)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreEstadoOrden");
            });

            modelBuilder.Entity<EstadoProducto>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__EstadoPr__62EA894AF09A9C25");

                entity.ToTable("EstadoProducto");

                entity.Property(e => e.IdEstado)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idEstado")
                    .IsFixedLength();

                entity.Property(e => e.NombreEstado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreEstado");
            });

            modelBuilder.Entity<Imagen>(entity =>
            {
                entity.HasKey(e => e.IdImagen)
                    .HasName("PK__Imagen__EA9A7136B8013B6F");

                entity.ToTable("Imagen");

                entity.Property(e => e.IdImagen)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idImagen")
                    .IsFixedLength();

                entity.Property(e => e.RutaImagen)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("rutaImagen");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__Marca__70331812333F1414");

                entity.ToTable("Marca");

                entity.Property(e => e.IdMarca)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idMarca")
                    .IsFixedLength();

                entity.Property(e => e.NombreMarca)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreMarca");

                entity.Property(e => e.RutaImagen)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("rutaImagen");
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.HasKey(e => e.IdOrden)
                    .HasName("PK__Orden__C8AAF6F3DED97662");

                entity.ToTable("Orden");

                entity.Property(e => e.IdOrden)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idOrden")
                    .IsFixedLength();

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCarrito)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idCarrito")
                    .IsFixedLength();

                entity.Property(e => e.IdEstadoOrden)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idEstadoOrden")
                    .IsFixedLength();

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idUsuario")
                    .IsFixedLength();

                entity.HasOne(d => d.Carrito)
                    .WithMany(p => p.Ordenes)
                    .HasForeignKey(d => d.IdCarrito)
                    .HasConstraintName("FK_Orden_Carrito");

                entity.HasOne(d => d.EstadoOrden)
                    .WithMany(p => p.Ordenes)
                    .HasForeignKey(d => d.IdEstadoOrden)
                    .HasConstraintName("FK_Orden_EstadoOrden");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Ordenes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Orden_Usuario");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__07F4A1329A87DF85");

                entity.ToTable("Producto");

                entity.Property(e => e.IdProducto)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idProducto")
                    .IsFixedLength();

                entity.Property(e => e.DescripcioGeneral)
                    .IsUnicode(false)
                    .HasColumnName("descripcioGeneral");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Descuento)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("descuento");

                entity.Property(e => e.IdCategoria)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idCategoria")
                    .IsFixedLength();

                entity.Property(e => e.IdEstado)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idEstado")
                    .IsFixedLength();

                entity.Property(e => e.IdMarca)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idMarca")
                    .IsFixedLength();

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombreProducto");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.StockProducto).HasColumnName("stockProducto");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK_Producto_Categoria");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK_Producto_Estado");

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK_Producto_Marca");

                entity.HasMany(d => d.Imagenes)
                    .WithMany(p => p.Productos)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductoImagen",
                        l => l.HasOne<Imagen>().WithMany().HasForeignKey("IdImagen").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ProductoImagen_ImagenProducto"),
                        r => r.HasOne<Producto>().WithMany().HasForeignKey("IdProducto").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ProductoImagen_Producto"),
                        j =>
                        {
                            j.HasKey("IdProducto", "IdImagen").HasName("PK__Producto__795D06214F0DF451");

                            j.ToTable("ProductoImagen");

                            j.IndexerProperty<string>("IdProducto").HasMaxLength(5).IsUnicode(false).HasColumnName("idProducto").IsFixedLength();

                            j.IndexerProperty<string>("IdImagen").HasMaxLength(5).IsUnicode(false).HasColumnName("idImagen").IsFixedLength();
                        });
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Rol__3C872F7625E6BB0F");

                entity.ToTable("Rol");

                entity.Property(e => e.IdRol)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idRol")
                    .IsFixedLength();

                entity.Property(e => e.DescripcionRol)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcionRol");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A6F4C2F037");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Email, "UQ__Usuario__AB6E61640D72C261")
                    .IsUnique();

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idUsuario")
                    .IsFixedLength();

                entity.Property(e => e.ApellidoUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellidoUsuario");

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contrasenia");

                entity.Property(e => e.Departamento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("departamento");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdRol)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idRol")
                    .IsFixedLength();

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreUsuario");

                entity.Property(e => e.Pais)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pais");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_Usuario_Rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
