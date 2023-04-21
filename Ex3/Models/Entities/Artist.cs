using System;
using System.Collections.Generic;

namespace Ex3.Models.Entities;

public class Artist
{
    // fileds

    public int Id_Artist { get; set; } // = null!;

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;


    // relationships outiside

    public virtual List<Artwork> Artworks { get; set; } = new();
}