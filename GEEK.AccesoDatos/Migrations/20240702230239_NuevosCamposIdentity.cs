using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GEEK.Data.Migrations
{
    public partial class NuevosCamposIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleOrden_Usuario",
                table: "DetalleOrden");

            migrationBuilder.DropForeignKey(
                name: "FK_Orden_Usuario",
                table: "Orden");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.AlterColumn<string>(
                name: "idUsuario",
                table: "Orden",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(5)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "idUsuario",
                table: "DetalleOrden",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(5)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "ApellidoUsuario",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DNI",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Departamento",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreUsuario",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleOrden_Usuario",
                table: "DetalleOrden",
                column: "idUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orden_Usuario",
                table: "Orden",
                column: "idUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleOrden_Usuario",
                table: "DetalleOrden");

            migrationBuilder.DropForeignKey(
                name: "FK_Orden_Usuario",
                table: "Orden");

            migrationBuilder.DropColumn(
                name: "ApellidoUsuario",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DNI",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NombreUsuario",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "idUsuario",
                table: "Orden",
                type: "char(5)",
                unicode: false,
                fixedLength: true,
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<string>(
                name: "idUsuario",
                table: "DetalleOrden",
                type: "char(5)",
                unicode: false,
                fixedLength: true,
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    idRol = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true),
                    apellidoUsuario = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    contrasenia = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    departamento = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    direccion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    fechaRegistro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    nombreUsuario = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    pais = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idRol",
                table: "Usuario",
                column: "idRol");

            migrationBuilder.CreateIndex(
                name: "UQ__Usuario__Email",
                table: "Usuario",
                column: "email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleOrden_Usuario",
                table: "DetalleOrden",
                column: "idUsuario",
                principalTable: "Usuario",
                principalColumn: "idUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Orden_Usuario",
                table: "Orden",
                column: "idUsuario",
                principalTable: "Usuario",
                principalColumn: "idUsuario");
        }
    }
}
