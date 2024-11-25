using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obligatorio2Web.Migrations
{
    public partial class UpdateTablasBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Huespedes_Usuarios_IdUsuario",
                table: "Huespedes");

            migrationBuilder.DropIndex(
                name: "IX_Huespedes_IdUsuario",
                table: "Huespedes");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Huespedes");

            migrationBuilder.AddColumn<int>(
                name: "HuespedIdHuesped",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_HuespedIdHuesped",
                table: "Usuarios",
                column: "HuespedIdHuesped");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Huespedes_HuespedIdHuesped",
                table: "Usuarios",
                column: "HuespedIdHuesped",
                principalTable: "Huespedes",
                principalColumn: "IdHuesped");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Huespedes_HuespedIdHuesped",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_HuespedIdHuesped",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "HuespedIdHuesped",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Huespedes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Huespedes_IdUsuario",
                table: "Huespedes",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Huespedes_Usuarios_IdUsuario",
                table: "Huespedes",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
