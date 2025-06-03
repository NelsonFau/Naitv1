using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Naitv1.Models;


namespace Naitv1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-FAL53AC\\SQLEXPRESS;Database=ObliNaitv1;Trusted_Connection=True;TrustServerCertificate=True;",
                x => x.UseNetTopologySuite()
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Actividad>().ToTable("Actividades");
            modelBuilder.Entity<RegistroParticipacion>().ToTable("RegistrosParticipacion");

            modelBuilder.Entity<Usuario>()
                .HasMany(usuario => usuario.RegistrosParticipacion)
                .WithOne(registroParticipacion => registroParticipacion.Participante)
                .HasForeignKey(registroParticipacion => registroParticipacion.ParticipanteId)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<Actividad>()
                .HasMany(actividad => actividad.RegistrosParticipacion)
                .WithOne(registroParticipacion => registroParticipacion.Actividad)
                .HasForeignKey(registroParticipacion => registroParticipacion.ActividadId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Actividad>(entity =>
            {
                entity.Property(actividad => actividad.Ubicacion)
                    .HasColumnType("geography");
            });
            modelBuilder.Entity<RegistroNotificacion>()
            .HasOne(r => r.Usuario)
            .WithMany()
            .HasForeignKey(r => r.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict); // <- Evita cascada

            modelBuilder.Entity<RegistroNotificacion>()
            .HasOne(r => r.Actividad)
            .WithMany()
            .HasForeignKey(r => r.ActividadId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Actividad>()
             .HasOne(a => a.Ciudad)
             .WithMany(c => c.ListActividades)
             .HasForeignKey(a => a.CiudadId);
        }

    

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<RegistroEmail> RegistroEmails { get; set; }
        public DbSet<RegistroParticipacion> RegistrosParticipacion { get; set; }
        public DbSet<RegistroNotificacion> RegistroNotificaciones { get; set; } 
        public DbSet<Ciudad> Ciudades { get; set; }
    }
    
}
