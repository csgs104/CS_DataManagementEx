using System;
using System.Collections.Generic;

namespace Ex3.Models.Entities;

public class Artwork
{
    // fileds

    public int IdArtwork { get; set; } // = null!;

    public string Name { get; set; } = null!;

    public int IdMuseum { get; set; } // = null!;

    public int IdArtist { get; set; } // = null!;

    public int? IdCharacter { get; set; } // = null!;



    // relationships inside 

    public virtual Artist Artist { get; set; } = null!;

    public virtual Museum Museum { get; set; } = null!;

    public virtual Character? Character { get; set; } // = null
}