using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GEEK.Data.Migrations
{
    public partial class LongitudDescripcionProductoA400 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Producto",
                type: "varchar(400)",
                unicode: false,
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Producto",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(400)",
                oldUnicode: false,
                oldMaxLength: 400);
        }
    }
}
