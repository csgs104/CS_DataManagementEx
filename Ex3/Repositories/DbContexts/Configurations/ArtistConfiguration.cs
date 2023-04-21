using System;

using Ex3.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex3.Repositories.DbContexts.Configurations;

public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> entity)
    {
        entity.HasKey(e => e.Id_Artist).HasName("PK_Artist");

        entity.ToTable("Artist");

        entity.Property(e => e.Id_Artist)
            .HasColumnName("Id_Artist")
            .IsRequired(true);

        entity.Property(e => e.Name)
            .HasColumnName("Name")
            .HasMaxLength(100)
            .IsUnicode(true)
            .IsRequired(true);

        entity.Property(e => e.Country)
            .HasColumnName("Country")
            .HasMaxLength(100)
            .IsUnicode(true)
            .IsRequired(true);
    }
}