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
                    NumHabitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoHabitacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CantidadPersonas = table.Column<int>(type: "int", nullable: false),
                    Tarifa = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitaciones", x => x.NumHabitacion);
                });

            migrationBuilder.CreateTable(
                name: "Huespedes",
                columns: table => new
                {
                    IdHuesped = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumDocumento = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    CorreoElec = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huespedes", x => x.IdHuesped);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    IdPersona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaisOrigen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.IdPersona);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HuespedIdHuesped = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoElec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Huespedes_HuespedIdHuesped",
                        column: x => x.HuespedIdHuesped,
                        principalTable: "Huespedes",
                        principalColumn: "IdHuesped",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHuesped = table.Column<int>(type: "int", nullable: false),
                    NumHabitacion = table.Column<int>(type: "int", nullable: false),
                    HabitacionElegidaNumHabitacion = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPago = table.Column<int>(type: "int", nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reserva_Habitaciones_HabitacionElegidaNumHabitacion",
                        column: x => x.HabitacionElegidaNumHabitacion,
                        principalTable: "Habitaciones",
                        principalColumn: "NumHabitacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Huespedes_IdHuesped",
                        column: x => x.IdHuesped,
                        principalTable: "Huespedes",
                        principalColumn: "IdHuesped",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Usuarios_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    IdPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReserva = table.Column<int>(type: "int", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<int>(type: "int", nullable: false),
                    MetodoPago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RealizacionPago = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.IdPago);
                    table.ForeignKey(
                        name: "FK_Pagos_Reservas_IdReserva",
                        column: x => x.IdReserva,
                        principalTable: "Reservas",
                        principalColumn: "IdReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_IdReserva",
                table: "Pagos",
                column: "IdReserva",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_HabitacionElegidaNumHabitacion",
                table: "Reservas",
                column: "HabitacionElegidaNumHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdHuesped",
                table: "Reservas",
                column: "IdHuesped");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_UsuarioIdUsuario",
                table: "Reservas",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_HuespedIdHuesped",
                table: "Usuarios",
                column: "HuespedIdHuesped");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Habitaciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Huespedes");
        }
    }
}
