﻿// <auto-generated />
using System;
using Ex3.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ex3.Migrations
{
    [DbContext(typeof(ArtTestContext))]
    partial class ArtTestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ex3.Models.Entities.Artist", b =>
                {
                    b.Property<int>("IdArtist")
                        .HasColumnType("int")
                        .HasColumnName("Id_Artist");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Country");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("IdArtist")
                        .HasName("PK_Artist");

                    b.ToTable("Artist", (string)null);
                });

            modelBuilder.Entity("Ex3.Models.Entities.Artwork", b =>
                {
                    b.Property<int>("IdArtwork")
                        .HasColumnType("int")
                        .HasColumnName("Id_Artwork");

                    b.Property<int>("IdArtist")
                        .HasColumnType("int")
                        .HasColumnName("Id_Artist");

                    b.Property<int?>("IdCharacter")
                        .HasColumnType("int")
                        .HasColumnName("Id_Character");

                    b.Property<int>("IdMuseum")
                        .HasColumnType("int")
                        .HasColumnName("Id_Museum");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("IdArtwork")
                        .HasName("PK_Artwork");

                    b.HasIndex("IdArtist");

                    b.HasIndex("IdCharacter");

                    b.HasIndex("IdMuseum");

                    b.ToTable("Artwork", (string)null);
                });

            modelBuilder.Entity("Ex3.Models.Entities.Character", b =>
                {
                    b.Property<int>("IdCharacter")
                        .HasColumnType("int")
                        .HasColumnName("Id_Character");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("IdCharacter")
                        .HasName("PK_Character");

                    b.ToTable("Character", (string)null);
                });

            modelBuilder.Entity("Ex3.Models.Entities.Museum", b =>
                {
                    b.Property<int>("IdMuseum")
                        .HasColumnType("int")
                        .HasColumnName("Id_Museum");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("City");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("IdMuseum")
                        .HasName("PK_Museum");

                    b.ToTable("Museum", (string)null);
                });

            modelBuilder.Entity("Ex3.Models.Entities.Artwork", b =>
                {
                    b.HasOne("Ex3.Models.Entities.Artist", "Artist")
                        .WithMany("Artworks")
                        .HasForeignKey("IdArtist")
                        .IsRequired()
                        .HasConstraintName("FK_Id_Artist");

                    b.HasOne("Ex3.Models.Entities.Character", "Character")
                        .WithMany("Artworks")
                        .HasForeignKey("IdCharacter")
                        .HasConstraintName("FK_Id_Character");

                    b.HasOne("Ex3.Models.Entities.Museum", "Museum")
                        .WithMany("Artworks")
                        .HasForeignKey("IdMuseum")
                        .IsRequired()
                        .HasConstraintName("FK_Id_Museum");

                    b.Navigation("Artist");

                    b.Navigation("Character");

                    b.Navigation("Museum");
                });

            modelBuilder.Entity("Ex3.Models.Entities.Artist", b =>
                {
                    b.Navigation("Artworks");
                });

            modelBuilder.Entity("Ex3.Models.Entities.Character", b =>
                {
                    b.Navigation("Artworks");
                });

            modelBuilder.Entity("Ex3.Models.Entities.Museum", b =>
                {
                    b.Navigation("Artworks");
                });
#pragma warning restore 612, 618
        }
    }
}
