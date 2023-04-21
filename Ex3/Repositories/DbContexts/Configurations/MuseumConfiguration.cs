using System;

using Ex3.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex3.Repositories.DbContexts.Configurations;

public class MuseumConfiguration : IEntityTypeConfiguration<Museum>
{
    public void Configure(EntityTypeBuilder<Museum> entity)
    {
        entity.HasKey(e => e.Id_Museum).HasName("PK_Museum");

        entity.ToTable("Museum");

        entity.Property(e => e.Id_Museum)
            .HasColumnName("Id_Museum")
            .IsRequired(true);

        entity.Property(e => e.Name)
            .HasColumnName("NameMuseum")
            .HasMaxLength(100)
            .IsUnicode(true)
            .IsRequired(true);

        entity.Property(e => e.City)
            .HasColumnName("City")
            .HasMaxLength(100)
            .IsUnicode(true)
            .IsRequired(true);
    }
}