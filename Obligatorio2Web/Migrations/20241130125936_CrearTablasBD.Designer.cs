﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Obligatorio2Web.Datos;

#nullable disable

namespace Obligatorio2Web.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241130125936_CrearTablasBD")]
    partial class CrearTablasBD
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Obligatorio2Web.Modelos.Habitacion", b =>
                {
                    b.Property<int>("NumHabitacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumHabitacion"), 1L, 1);

                    b.Property<int>("CantidadPersonas")
                        .HasColumnType("int");

                    b.Property<int>("Tarifa")
                        .HasColumnType("int");

                    b.Property<string>("TipoHabitacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NumHabitacion");

                    b.ToTable("Habitaciones");
                });

            modelBuilder.Entity("Obligatorio2Web.Modelos.Huesped", b =>
                {
                    b.Property<int>("IdHuesped")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHuesped"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CorreoElec")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NumDocumento")
                        .HasColumnType("int");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.Property<string>("TipoDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("IdHuesped");

                    b.HasIndex("CorreoElec")
                        .IsUnique();

                    b.HasIndex("NumDocumento")
                        .IsUnique();

                    b.HasIndex("Telefono")
                        .IsUnique();

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Huespedes");
                });

            modelBuilder.Entity("Obligatorio2Web.Modelos.Pago", b =>
                {
                    b.Property<int>("IdPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPago"), 1L, 1);

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("date");

                    b.Property<string>("MetodoPago")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Monto")
                        .HasColumnType("int");

                    b.HasKey("IdPago");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("Obligatorio2Web.Modelos.Reserva", b =>
                {
                    b.Property<int>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReserva"), 1L, 1);

                    b.Property<DateTime>("FechaFinal")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaReserva")
                        .HasColumnType("date");

                    b.Property<int?>("HabitacionElegidaNumHabitacion")
                        .HasColumnType("int");

                    b.Property<int>("NumHabitacion")
                        .HasColumnType("int");

                    b.Property<int>("NumeroPersonas")
                        .HasColumnType("int");

                    b.Property<int>("PagoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("IdReserva");

                    b.HasIndex("HabitacionElegidaNumHabitacion");

                    b.HasIndex("PagoId")
                        .IsUnique();

                    b.HasIndex("UsuarioId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Obligatorio2Web.Modelos.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"), 1L, 1);

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("CorreoElec")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Obligatorio2Web.Modelos.Huesped", b =>
                {
                    b.HasOne("Obligatorio2Web.Modelos.Usuario", "Usuario")
                        .WithOne("Huesped")
                        .HasForeignKey("Obligatorio2Web.Modelos.Huesped", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Obligatorio2Web.Modelos.Reserva", b =>
                {
                    b.HasOne("Obligatorio2Web.Modelos.Habitacion", "HabitacionElegida")
                        .WithMany()
                        .HasForeignKey("HabitacionElegidaNumHabitacion");

                    b.HasOne("Obligatorio2Web.Modelos.Pago", "PagoReserva")
                        .WithOne("Reserva")
                        .HasForeignKey("Obligatorio2Web.Modelos.Reserva", "PagoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Obligatorio2Web.Modelos.Usuario", "Usuario")
                        .WithMany("Reservas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HabitacionElegida");

                    b.Navigation("PagoReserva");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Obligatorio2Web.Modelos.Pago", b =>
                {
                    b.Navigation("Reserva")
                        .IsRequired();
                });

            modelBuilder.Entity("Obligatorio2Web.Modelos.Usuario", b =>
                {
                    b.Navigation("Huesped");

                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}