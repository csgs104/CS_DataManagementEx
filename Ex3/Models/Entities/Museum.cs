using System;
using System.Collections.Generic;

namespace Ex3.Models.Entities;

public class Museum
{
    // fileds

    public int Id_Museum { get; set; } // = null!;

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;


    // relationships outiside

    public virtual List<Artwork> Artworks { get; set; } = new();
}