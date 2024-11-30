using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obligatorio2Web.Migrations
{
    public partial class CrearTablasBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habitaciones",
                columns: table => new
                {
                    NumHabitacion = table.Column<int>(type: "int", nullable: false),
                    TipoHabitacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantidadPersonas = table.Column<int>(type: "int", nullable: false),
                    Tarifa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitaciones", x => x.NumHabitacion);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    IdPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaPago = table.Column<DateTime>(type: "date", nullable: false),
                    Monto = table.Column<int>(type: "int", nullable: false),
                    MetodoPago = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.IdPago);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Huespedes",
                columns: table => new
                {
                    IdHuesped = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumDocumento = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    CorreoElec = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huespedes", x => x.IdHuesped);
                    table.ForeignKey(
                        name: "FK_Huespedes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    NumHabitacion = table.Column<int>(type: "int", nullable: false),
                    HabitacionElegidaNumHabitacion = table.Column<int>(type: "int", nullable: true),
                    NumeroPersonas = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "date", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "date", nullable: false),
                    FechaReserva = table.Column<DateTime>(type: "date", nullable: false),
                    PagoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reservas_Habitaciones_HabitacionElegidaNumHabitacion",
                        column: x => x.HabitacionElegidaNumHabitacion,
                        principalTable: "Habitaciones",
                        principalColumn: "NumHabitacion");
                    table.ForeignKey(
                        name: "FK_Reservas_Pagos_PagoId",
                        column: x => x.PagoId,
                        principalTable: "Pagos",
                        principalColumn: "IdPago",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Huespedes_CorreoElec",
                table: "Huespedes",
                column: "CorreoElec",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Huespedes_NumDocumento",
                table: "Huespedes",
                column: "NumDocumento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Huespedes_Telefono",
                table: "Huespedes",
                column: "Telefono",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Huespedes_UsuarioId",
                table: "Huespedes",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_HabitacionElegidaNumHabitacion",
                table: "Reservas",
                column: "HabitacionElegidaNumHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_PagoId",
                table: "Reservas",
                column: "PagoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_UsuarioId",
                table: "Reservas",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Huespedes");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Habitaciones");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
