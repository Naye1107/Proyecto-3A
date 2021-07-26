using System;
using Microsoft.EntityFrameworkCore;
using kaninos.Entities;

namespace kaninos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Criador> Criadores { get; set; }
        public virtual DbSet<Cruce> Cruces { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Ejemplar> Ejemplares { get; set; }
        public virtual DbSet<Raza> Razas { get; set; }
        public virtual DbSet<Color> Colores { get; set; }
        public virtual DbSet<Variedad> Variedades { get; set; }
    }
}