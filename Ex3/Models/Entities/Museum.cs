using System;
using System.Collections.Generic;

namespace Ex3.Models.Entities;

public class Museum
{
    // fileds

    public int IdMuseum { get; set; } // = null!;

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;


    // relationships outiside

    public virtual ICollection<Artwork> Artworks { get; set; } = new List<Artwork>();
}