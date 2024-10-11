using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GEEK.Data.Migrations
{
    public partial class AgregandoLosModelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    idCategoria = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    descripcionCategoria = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categoria", x => x.idCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Imagen",
                columns: table => new
                {
                    idImagen = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    rutaImagen = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Imagen", x => x.idImagen);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    idMarca = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    nombreMarca = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    rutaImagen = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Marca", x => x.idMarca);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    idRol = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    descripcionRol = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rol", x => x.idRol);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    idProducto = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    nombreProducto = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    descripcion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    descripcioGeneral = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    precio = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    stockProducto = table.Column<int>(type: "int", nullable: true),
                    descuento = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    idMarca = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true),
                    idCategoria = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true),
                    estadoProducto = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto", x => x.idProducto);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria",
                        column: x => x.idCategoria,
                        principalTable: "Categoria",
                        principalColumn: "idCategoria");
                    table.ForeignKey(
                        name: "FK_Producto_Marca",
                        column: x => x.idMarca,
                        principalTable: "Marca",
                        principalColumn: "idMarca");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    nombreUsuario = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    apellidoUsuario = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    contrasenia = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fechaRegistro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    direccion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    departamento = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    pais = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    idRol = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol",
                        column: x => x.idRol,
                        principalTable: "Rol",
                        principalColumn: "idRol");
                });

            migrationBuilder.CreateTable(
                name: "ProductoImagen",
                columns: table => new
                {
                    idProducto = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    idImagen = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__Imagen", x => new { x.idProducto, x.idImagen });
                    table.ForeignKey(
                        name: "FK_ProductoImagen_ImagenProducto",
                        column: x => x.idImagen,
                        principalTable: "Imagen",
                        principalColumn: "idImagen");
                    table.ForeignKey(
                        name: "FK_ProductoImagen_Producto",
                        column: x => x.idProducto,
                        principalTable: "Producto",
                        principalColumn: "idProducto");
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    idOrden = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    idUsuario = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true),
                    estadoOrden = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true),
                    fechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orden", x => x.idOrden);
                    table.ForeignKey(
                        name: "FK_Orden_Usuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario");
                });

            migrationBuilder.CreateTable(
                name: "DetalleOrden",
                columns: table => new
                {
                    idOrden = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    idProducto = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    idUsuario = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    precio = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetalleOrden", x => new { x.idOrden, x.idProducto });
                    table.ForeignKey(
                        name: "FK_DetalleOrden_Orden",
                        column: x => x.idOrden,
                        principalTable: "Orden",
                        principalColumn: "idOrden");
                    table.ForeignKey(
                        name: "FK_DetalleOrden_Producto",
                        column: x => x.idProducto,
                        principalTable: "Producto",
                        principalColumn: "idProducto");
                    table.ForeignKey(
                        name: "FK_DetalleOrden_Usuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrden_idProducto",
                table: "DetalleOrden",
                column: "idProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrden_idUsuario",
                table: "DetalleOrden",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_idUsuario",
                table: "Orden",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_idCategoria",
                table: "Producto",
                column: "idCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_idMarca",
                table: "Producto",
                column: "idMarca");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoImagen_idImagen",
                table: "ProductoImagen",
                column: "idImagen");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idRol",
                table: "Usuario",
                column: "idRol");

            migrationBuilder.CreateIndex(
                name: "UQ__Usuario__Email",
                table: "Usuario",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleOrden");

            migrationBuilder.DropTable(
                name: "ProductoImagen");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Imagen");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
