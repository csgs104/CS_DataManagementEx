using System;

using Ex3.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex3.Repositories.DbContexts.Configurations;

public class CharacterConfiguration : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> entity)
    {
        entity.HasKey(e => e.Id_Character).HasName("PK_Character");

        entity.ToTable("Character");

        entity.Property(e => e.Id_Character)
            .HasColumnName("Id_Character")
            .IsRequired(true);

        entity.Property(e => e.Name)
            .HasColumnName("Name")
            .HasMaxLength(100)
            .IsUnicode(true)
            .IsRequired(true);
    }
}
