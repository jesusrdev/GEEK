using GEEK.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GEEK.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<DetalleOrden> DetalleOrden { get; set; } = null!;
        public virtual DbSet<Imagen> Imagen { get; set; } = null!;
        public virtual DbSet<Marca> Marca { get; set; } = null!;
        public virtual DbSet<Orden> Orden { get; set; } = null!;
        public virtual DbSet<Producto> Producto { get; set; } = null!;
        public virtual DbSet<Usuario> Usuario { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // chatgpt error identity


            modelBuilder.Entity<DetalleOrden>(entity =>
            {
                entity.HasKey(e => new { e.IdOrden, e.IdProducto })
                    .HasName("PK__DetalleOrden");

                entity.ToTable("DetalleOrden");

                entity.Property(e => e.IdOrden)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idOrden")
                    .IsFixedLength();

                entity.Property(e => e.IdProducto)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idProducto")
                    .IsFixedLength();

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasMaxLength(450);

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.Orden)
                    .WithMany(p => p.DetalleOrden)
                    .HasForeignKey(d => d.IdOrden)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleOrden_Orden");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.DetalleOrden)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleOrden_Producto");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.DetalleOrden)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_DetalleOrden_Usuario");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categoria");

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

            modelBuilder.Entity<Imagen>(entity =>
            {
                entity.HasKey(e => e.IdImagen)
                    .HasName("PK__Imagen");

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

                entity.Property(e => e.IdProducto)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idProducto")
                    .IsFixedLength();

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Imagenes)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK_Producto_Imagen");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__Marca");

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
                    .HasName("PK__Orden");

                entity.ToTable("Orden");

                entity.Property(e => e.IdOrden)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idOrden")
                    .IsFixedLength();

                entity.Property(e => e.EstadoOrden)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("estadoOrden")
                    .IsFixedLength();

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasMaxLength(450);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Ordenes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Orden_Usuario");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto");

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
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Descuento)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("descuento");

                entity.Property(e => e.EstadoProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("estadoProducto");

                entity.Property(e => e.IdCategoria)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idCategoria")
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

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK_Producto_Marca");

            });

            //modelBuilder.Entity<Rol>(entity =>
            //{
            //    entity.HasKey(e => e.IdRol)
            //        .HasName("PK__Rol");

            //    entity.ToTable("Rol");

            //    entity.Property(e => e.IdRol)
            //        .HasMaxLength(5)
            //        .IsUnicode(false)
            //        .HasColumnName("idRol")
            //        .IsFixedLength();

            //    entity.Property(e => e.DescripcionRol)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasColumnName("descripcionRol");
            //});

            //modelBuilder.Entity<Usuario>(entity =>
            //{
            //    entity.HasKey(e => e.IdUsuario)
            //        .HasName("PK__Usuario");

            //    entity.ToTable("Usuario");

            //    entity.HasIndex(e => e.Email, "UQ__Usuario__Email")
            //        .IsUnique();

            //    entity.Property(e => e.IdUsuario)
            //        .HasMaxLength(5)
            //        .IsUnicode(false)
            //        .HasColumnName("idUsuario")
            //        .IsFixedLength();

            //    entity.Property(e => e.ApellidoUsuario)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasColumnName("apellidoUsuario");

            //    entity.Property(e => e.Contrasenia)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasColumnName("contrasenia");

            //    entity.Property(e => e.Departamento)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasColumnName("departamento");

            //    entity.Property(e => e.Direccion)
            //        .HasMaxLength(200)
            //        .IsUnicode(false)
            //        .HasColumnName("direccion");

            //    entity.Property(e => e.Email)
            //        .HasMaxLength(100)
            //        .IsUnicode(false)
            //        .HasColumnName("email");

            //    entity.Property(e => e.FechaRegistro)
            //        .HasColumnType("datetime")
            //        .HasColumnName("fechaRegistro")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.IdRol)
            //        .HasMaxLength(5)
            //        .IsUnicode(false)
            //        .HasColumnName("idRol")
            //        .IsFixedLength();

            //    entity.Property(e => e.NombreUsuario)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasColumnName("nombreUsuario");

            //    entity.Property(e => e.Pais)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasColumnName("pais");

            //    entity.HasOne(d => d.IdRolNavigation)
            //        .WithMany(p => p.Usuarios)
            //        .HasForeignKey(d => d.IdRol)
            //        .HasConstraintName("FK_Usuario_Rol");
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
