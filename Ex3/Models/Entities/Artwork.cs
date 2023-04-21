using System;
using System.Collections.Generic;

namespace Ex3.Models.Entities;

public class Artwork
{
    // fileds

    public int Id_Artwork { get; set; } // = null!;

    public string Name { get; set; } = null!;

    public int Id_Museum { get; set; } // = null!;

    public int Id_Artist { get; set; } // = null!;

    public int? Id_Character { get; set; } // = null!;



    // relationships outiside

    public virtual Museum Museum { get; set; } = new();

    public virtual Artist Artist { get; set; } = new();

    public virtual Character? Character { get; set; } // = null;
}