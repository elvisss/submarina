using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using submarina.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace submarina.Data.Mapping
{
    public class DetectorMap : IEntityTypeConfiguration<Detector>
    {
        public void Configure(EntityTypeBuilder<Detector> builder)
        {
            builder.ToTable("detector")
                .HasKey(d => d.iddetector);
            builder.Property(d => d.code)
                .HasMaxLength(50);
            builder.Property(d => d.description)
                .HasMaxLength(250);
        }
    }
}
