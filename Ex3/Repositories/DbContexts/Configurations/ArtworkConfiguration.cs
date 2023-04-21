using System;

using Ex3.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex3.Repositories.DbContexts.Configurations;

public class ArtworkConfiguration : IEntityTypeConfiguration<Artwork>
{
    public void Configure(EntityTypeBuilder<Artwork> entity)
    {
        entity.HasKey(e => e.Id_Character).HasName("PK_Artwork");

        entity.ToTable("Artwork");

        entity.Property(e => e.Id_Artwork)
            .HasColumnName("Id_Artwork")
            .IsRequired(false);

        entity.Property(e => e.Name)
            .HasColumnName("Name")
            .HasMaxLength(100)
            .IsUnicode(true)
            .IsRequired(true);

        entity.Property(e => e.Id_Museum)
            .HasColumnName("Id_Museum")
            .IsRequired(true);

        entity.Property(e => e.Id_Artist)
            .HasColumnName("Id_Artist")
            .IsRequired(true);

        entity.Property(e => e.Id_Character)
            .HasColumnName("Id_Character")
            .IsRequired(false);

        entity.HasOne(d => d.Museum).WithMany(p => p.Artworks)
            .HasForeignKey(d => d.Id_Museum)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Id_Museum");

        entity.HasOne(d => d.Artist).WithMany(p => p.Artworks)
            .HasForeignKey(d => d.Id_Artist)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Id_Artist");

        entity.HasOne(d => d.Character).WithMany(p => p.Artworks)
            .HasForeignKey(d => d.Id_Character)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Id_Character");
    }
}