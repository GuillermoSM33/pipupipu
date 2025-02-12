using GarciaGuillermo.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GarciaGuillermo.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
          public DbSet<Usuario> Usuarios { get; set; }
          public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(r => r.IdRol);
                entity.Property(r => r.Nombre).HasMaxLength(50).IsRequired();

                entity.HasData(
                    new Rol { IdRol = 1, Nombre = "Administrador" },
                    new Rol { IdRol = 2, Nombre = "Usuario" }
                );
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Nombre).HasMaxLength(100).IsRequired();
                entity.Property(u => u.UserName).HasMaxLength(50).IsRequired();
                entity.Property(u => u.Password).HasMaxLength(200).IsRequired();

                entity.HasData(
                    new Usuario
                    {
                        Id = 1,
                        Nombre = "Guillermo García",
                        UserName = "guillermo_admin",
                        Password = "password123", 
                        IdRol = 1
                    },
                    new Usuario
                    {
                        Id = 2,
                        Nombre = "Alisson García",
                        UserName = "alisson_user",
                        Password = "password456",
                        IdRol = 2
                    }
                );
            });

            base.OnModelCreating(modelBuilder);
        }


    }
}
