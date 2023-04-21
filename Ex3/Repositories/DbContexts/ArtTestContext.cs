using System;
using System.Diagnostics.Metrics;
using Ex3.Models.Entities;
using Ex3.Repositories.DbContexts.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Ex3.Repositories.DbContexts;

public class ArtTestContext : DbContext
{
    public ArtTestContext() { }

    public ArtTestContext(DbContextOptions<ArtTestContext> options)
        : base(options) { }

    public virtual DbSet<Museum> Museums { get; set; }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<Artwork> Artworks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=ArtTest;User ID=SA;Password=r00t.R00T;Encrypt=True;TrustServerCertificate=True;Connection Timeout=180;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MuseumConfiguration());
        modelBuilder.ApplyConfiguration(new ArtistConfiguration());
        modelBuilder.ApplyConfiguration(new CharacterConfiguration());
        modelBuilder.ApplyConfiguration(new ArtworkConfiguration());
    }
}