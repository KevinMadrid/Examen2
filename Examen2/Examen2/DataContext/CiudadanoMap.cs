using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Examen2.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2.DataContext
{
    public class CiudadanoMap:IEntityTypeConfiguration<Ciudadano>
    {
        public void Configure(EntityTypeBuilder<Ciudadano> builder)
        {
            builder.ToTable("ciudadano", "dbo");
            builder.HasKey(q => q.id);
            builder.Property(e => e.id).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(e => e.primer_nombre).HasColumnType("varchar(50)");
            builder.Property(e => e.segundo_nombre).HasColumnType("varchar(50)");
            builder.Property(e => e.primer_apellido).HasColumnType("varchar(50)");
            builder.Property(e => e.segundo_apellido).HasColumnType("varchar(50)")

                   .HasMaxLength(50).IsRequired();

           
        }
    }
}
