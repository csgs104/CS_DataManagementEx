using System;

using Ex3.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex3.Repositories.DbContexts.Configurations;

public class ArtworkConfiguration : IEntityTypeConfiguration<Artwork>
{
    public void Configure(EntityTypeBuilder<Artwork> entity)
    {
        entity.HasKey(e => e.IdCharacter).HasName("PK_Artwork");

        entity.ToTable("Artwork");

        entity.Property(e => e.IdArtwork)
            .ValueGeneratedNever()
            .HasColumnName("Id_Artwork")
            .IsRequired(true);

        entity.Property(e => e.Name)
            .HasColumnName("Name")
            .HasMaxLength(100)
            .IsUnicode(true)
            .IsRequired(true);

        entity.Property(e => e.IdMuseum)
            .HasColumnName("Id_Museum")
            .IsRequired(true);

        entity.Property(e => e.IdArtist)
            .HasColumnName("Id_Artist")
            .IsRequired(true);

        entity.Property(e => e.IdCharacter)
            .HasColumnName("Id_Character")
            .IsRequired(true);

        entity.HasOne(d => d.Museum).WithMany(p => p.Artworks)
            .HasForeignKey(d => d.IdMuseum)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Id_Museum");

        entity.HasOne(d => d.Artist).WithMany(p => p.Artworks)
            .HasForeignKey(d => d.IdArtist)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Id_Artist");

        entity.HasOne(d => d.Character).WithMany(p => p.Artworks)
            .HasForeignKey(d => d.IdCharacter)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Id_Character");
    }
}