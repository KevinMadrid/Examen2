using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Examen2.DataContext;

namespace Examen2.Modelos
{
    public class CiudadanoDataContext : DbContext
    {
        public DbSet<Ciudadano> Ciudadanos{ get; set; }
        public DbSet<Ciudad> Ciudads { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=KEVIN-PC;DataBase=Examen2DB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CiudadanoMap());
            base.OnModelCreating(modelBuilder);

        }
    }
}
