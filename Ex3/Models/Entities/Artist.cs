using System;
using System.Collections.Generic;

namespace Ex3.Models.Entities;

public class Artist
{
    // fileds

    public int IdArtist { get; set; } // = null!;

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;


    // relationships outiside

    public virtual ICollection<Artwork> Artworks { get; set; } = new List<Artwork>();
}