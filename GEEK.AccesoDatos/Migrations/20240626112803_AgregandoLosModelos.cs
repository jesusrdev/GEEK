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
                    table.PrimaryKey("PK__Categori__8A3D240C0906EB00", x => x.idCategoria);
                });

            migrationBuilder.CreateTable(
                name: "EstadoOrden",
                columns: table => new
                {
                    idEstadoOrden = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    nombreEstadoOrden = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EstadoOr__9CDE093F84FDE170", x => x.idEstadoOrden);
                });

            migrationBuilder.CreateTable(
                name: "EstadoProducto",
                columns: table => new
                {
                    idEstado = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    nombreEstado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EstadoPr__62EA894AF09A9C25", x => x.idEstado);
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
                    table.PrimaryKey("PK__Imagen__EA9A7136B8013B6F", x => x.idImagen);
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
                    table.PrimaryKey("PK__Marca__70331812333F1414", x => x.idMarca);
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
                    table.PrimaryKey("PK__Rol__3C872F7625E6BB0F", x => x.idRol);
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
                    idEstado = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__07F4A1329A87DF85", x => x.idProducto);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria",
                        column: x => x.idCategoria,
                        principalTable: "Categoria",
                        principalColumn: "idCategoria");
                    table.ForeignKey(
                        name: "FK_Producto_Estado",
                        column: x => x.idEstado,
                        principalTable: "EstadoProducto",
                        principalColumn: "idEstado");
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
                    table.PrimaryKey("PK__Usuario__645723A6F4C2F037", x => x.idUsuario);
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
                    table.PrimaryKey("PK__Producto__795D06214F0DF451", x => new { x.idProducto, x.idImagen });
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
                name: "Carrito",
                columns: table => new
                {
                    idCarrito = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    idProducto = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true),
                    idUsuario = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Carrito__7AF85448DBBC2CB4", x => x.idCarrito);
                    table.ForeignKey(
                        name: "FK_Carrito_Producto",
                        column: x => x.idProducto,
                        principalTable: "Producto",
                        principalColumn: "idProducto");
                    table.ForeignKey(
                        name: "FK_Carrito_Usuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    idOrden = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    idCarrito = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true),
                    idUsuario = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true),
                    idEstadoOrden = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    fechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orden__C8AAF6F3DED97662", x => x.idOrden);
                    table.ForeignKey(
                        name: "FK_Orden_Carrito",
                        column: x => x.idCarrito,
                        principalTable: "Carrito",
                        principalColumn: "idCarrito");
                    table.ForeignKey(
                        name: "FK_Orden_EstadoOrden",
                        column: x => x.idEstadoOrden,
                        principalTable: "EstadoOrden",
                        principalColumn: "idEstadoOrden");
                    table.ForeignKey(
                        name: "FK_Orden_Usuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_idProducto",
                table: "Carrito",
                column: "idProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_idUsuario",
                table: "Carrito",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_idCarrito",
                table: "Orden",
                column: "idCarrito");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_idEstadoOrden",
                table: "Orden",
                column: "idEstadoOrden");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_idUsuario",
                table: "Orden",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_idCategoria",
                table: "Producto",
                column: "idCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_idEstado",
                table: "Producto",
                column: "idEstado");

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
                name: "UQ__Usuario__AB6E61640D72C261",
                table: "Usuario",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "ProductoImagen");

            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropTable(
                name: "EstadoOrden");

            migrationBuilder.DropTable(
                name: "Imagen");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "EstadoProducto");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
