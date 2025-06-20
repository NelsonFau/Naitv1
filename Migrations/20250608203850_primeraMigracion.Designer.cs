﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Naitv1.Data;
using NetTopologySuite.Geometries;

#nullable disable

namespace Naitv1.Migrations
{
    [DbContext(typeof(AppDbContext))]
<<<<<<<< HEAD:Migrations/20250602005806_creacionModeloCiudad.Designer.cs
    [Migration("20250602005806_creacionModeloCiudad")]
    partial class creacionModeloCiudad
========
    [Migration("20250608203850_primeraMigracion")]
    partial class primeraMigracion
>>>>>>>> fix-version-controlada:Migrations/20250608203850_primeraMigracion.Designer.cs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Naitv1.Models.Actividad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activa")
                        .HasColumnType("bit");

                    b.Property<int>("AnfitrionId")
                        .HasColumnType("int");

                    b.Property<int>("CiudadId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechCreación")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaFinal")
                        .HasColumnType("datetime2");

                    b.Property<float>("Lat")
                        .HasColumnType("real");

                    b.Property<float>("Lon")
                        .HasColumnType("real");

                    b.Property<string>("MensajeDelAnfitrion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoActividad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Point>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("geography");

                    b.HasKey("Id");

                    b.HasIndex("AnfitrionId");

                    b.HasIndex("CiudadId");

<<<<<<<< HEAD:Migrations/20250602005806_creacionModeloCiudad.Designer.cs
                    b.ToTable("Actividades", (string)null);
========
                    b.ToTable("Actividades");
>>>>>>>> fix-version-controlada:Migrations/20250608203850_primeraMigracion.Designer.cs
                });

            modelBuilder.Entity("Naitv1.Models.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

<<<<<<<< HEAD:Migrations/20250602005806_creacionModeloCiudad.Designer.cs
                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");
========
                    b.Property<int>("IdActividad")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ActividadesUsuarios");
                });

            modelBuilder.Entity("Naitv1.Models.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");
>>>>>>>> fix-version-controlada:Migrations/20250608203850_primeraMigracion.Designer.cs

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("lat")
                        .HasColumnType("real");

                    b.Property<float>("lon")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("Naitv1.Models.RegistroEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Asunto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CuerpoHtml")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destinatario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaProgramada")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("RegistroEmails");
                });

            modelBuilder.Entity("Naitv1.Models.RegistroNotificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActividadId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoNotificacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNotificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActividadId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("RegistroNotificaciones");
                });

            modelBuilder.Entity("Naitv1.Models.RegistroParticipacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActividadId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("ParticipanteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActividadId");

                    b.HasIndex("ParticipanteId");

                    b.ToTable("RegistrosParticipacion", (string)null);
                });

            modelBuilder.Entity("Naitv1.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("Naitv1.Models.Actividad", b =>
                {
                    b.HasOne("Naitv1.Models.Usuario", "Anfitrion")
                        .WithMany()
                        .HasForeignKey("AnfitrionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Naitv1.Models.Ciudad", "Ciudad")
                        .WithMany("ListActividades")
                        .HasForeignKey("CiudadId")
<<<<<<<< HEAD:Migrations/20250602005806_creacionModeloCiudad.Designer.cs
                        .OnDelete(DeleteBehavior.Cascade)
========
                        .OnDelete(DeleteBehavior.Restrict)
>>>>>>>> fix-version-controlada:Migrations/20250608203850_primeraMigracion.Designer.cs
                        .IsRequired();

                    b.Navigation("Anfitrion");

                    b.Navigation("Ciudad");
                });

<<<<<<<< HEAD:Migrations/20250602005806_creacionModeloCiudad.Designer.cs
            modelBuilder.Entity("Naitv1.Models.RegistroNotificacion", b =>
                {
                    b.HasOne("Naitv1.Models.Actividad", "Actividad")
                        .WithMany()
                        .HasForeignKey("ActividadId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Naitv1.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Actividad");

                    b.Navigation("Usuario");
========
            modelBuilder.Entity("Naitv1.Models.Ciudad", b =>
                {
                    b.Navigation("ListActividades");
>>>>>>>> fix-version-controlada:Migrations/20250608203850_primeraMigracion.Designer.cs
                });

            modelBuilder.Entity("Naitv1.Models.RegistroParticipacion", b =>
                {
                    b.HasOne("Naitv1.Models.Actividad", "Actividad")
                        .WithMany("RegistrosParticipacion")
                        .HasForeignKey("ActividadId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Naitv1.Models.Usuario", "Participante")
                        .WithMany("RegistrosParticipacion")
                        .HasForeignKey("ParticipanteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Actividad");

                    b.Navigation("Participante");
                });

            modelBuilder.Entity("Naitv1.Models.Actividad", b =>
                {
                    b.Navigation("RegistrosParticipacion");
                });

            modelBuilder.Entity("Naitv1.Models.Ciudad", b =>
                {
                    b.Navigation("ListActividades");
                });

            modelBuilder.Entity("Naitv1.Models.Usuario", b =>
                {
                    b.Navigation("RegistrosParticipacion");
                });
#pragma warning restore 612, 618
        }
    }
}
