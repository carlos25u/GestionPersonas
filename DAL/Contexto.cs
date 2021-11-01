using GestionPersonas.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonas.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Grupos> Grupos { get; set; }
        public DbSet<Aportes> Aportes { get; set; }
        public DbSet<TiposAportes> tiposAportes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\PeopleGestor.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TiposAportes>().HasData(new TiposAportes
            {
                TipoAporteId = 1,
                Descripcion = "Pintura",
                Meta = 20000.00f
            }
            );

            modelBuilder.Entity<TiposAportes>().HasData(new TiposAportes
            {
                TipoAporteId = 2,
                Descripcion = "Sillas",
                Meta = 10000.00f
            }
           );

            modelBuilder.Entity<TiposAportes>().HasData(new TiposAportes
            {
                TipoAporteId = 3,
                Descripcion = "Reparacion",
                Meta = 30000.00f
            }
          );
        }
    }
}
