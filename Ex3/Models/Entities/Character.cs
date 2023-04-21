using System;
using System.Collections.Generic;

namespace Ex3.Models.Entities;

public class Character
{
    // fileds

    public int Id_Character { get; set; } // = null!;

    public string Name { get; set; } = null!;


    // relationships outiside

    public virtual List<Artwork> Artworks { get; set; } = new();
}