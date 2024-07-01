using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GEEK.Data.Migrations
{
    public partial class ArreglandoRelacionImagenProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductoImagen");

            migrationBuilder.AddColumn<string>(
                name: "idProducto",
                table: "Imagen",
                type: "char(5)",
                unicode: false,
                fixedLength: true,
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Imagen_idProducto",
                table: "Imagen",
                column: "idProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Imagen",
                table: "Imagen",
                column: "idProducto",
                principalTable: "Producto",
                principalColumn: "idProducto",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Imagen",
                table: "Imagen");

            migrationBuilder.DropIndex(
                name: "IX_Imagen_idProducto",
                table: "Imagen");

            migrationBuilder.DropColumn(
                name: "idProducto",
                table: "Imagen");

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductoImagen_idImagen",
                table: "ProductoImagen",
                column: "idImagen");
        }
    }
}
