using Ex3.Models;
using Ex3.Models.Entities;
using Ex3.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Ex3");

// Nuget Packages For Everyone:
// Micreosoft.EntityFrameworkCore
// Micreosoft.EntityFrameworkCore.SqlServer
// Micreosoft.EntityFrameworkCore.Tools

// Nuget Packages Optional:
// Micreosoft.EntityFrameworkCore.Design
// Needed If You Use MacOs... And, I Use MacOs

// SCAFFOLD For MacOS Users Only:
// install on terminal: dotnet ef

// scaffold on project terminal:
// dotnet ef dbcontext Scaffold "Server=127.0.0.1,1433;Database=Art;Integrated Security=False;User ID=SA;Password=r00t.R00T;Encrypt=True;TrustServerCertificate=True;Connection Timeout=180;" Microsoft.EntityFrameworkCore.SqlServer -o Models/DB

// migration on project terminal:
// do firts: dotnet ef migrations add Initial
// do undo: dotnet ef migrations remove
// do update: dotnet ef database update

// migrations: 1.initial, 2. ...

var db = new ArtTestContext();

var query1 = $@"
    SELECT mm.[MuseumName], ak.[Name] AS ArtworkName, cr.[Name] AS CharacterName
    FROM [Art].[dbo].[Artwork] ak
    JOIN [Art].[dbo].[Museum] mm ON mm.[Id_Museum] = ak.[Id_Museum]
    JOIN [Art].[dbo].[Artist] ar ON ar.[Id_Artist] = ak.[Id_Artist]
    LEFT JOIN [Art].[dbo].[Character] cr ON cr.[Id_Character] = ak.[Id_Character]
    WHERE ar.[Country] = 'Italia'";

void Query1()
{
    var rs = db?.Artworks
        .Include(museum => museum.Museum)
        .Include(artist => artist.Artist)
        .Include(character => character.Character)
        .Where(r => r.Artist.Country == "Italia")
        .Select(r => new {
            MuseumName = r.Museum.Name,
            ArtworkName = r.Name,
            CharacterOut = r.Character,
        }).ToList();

    foreach (var r in rs) 
    {
        Console.WriteLine($"MuseumName: {r.MuseumName}, ArtworkName: {r.ArtworkName}, CharacterName: {r.CharacterOut?.Name ?? "NULL"}");
    }
}

void Query2()
{
    var rs = db?.Artworks
        .Include(museum => museum.Museum)
        .Include(artist => artist.Artist)
        .Include(character => character.Character)
        .Where(r => r.Artist.Country == "Italia")
        .Select(r => new {
            MuseumName = r.Museum.Name,
            ArtworkName = r.Name,
            CharacterOut = r.Character,
        }).ToList();

    foreach (var r in rs)
    {
        Console.WriteLine($"MuseumName: {r.MuseumName}, ArtworkName: {r.ArtworkName}, CharacterName: {r.CharacterOut?.Name ?? "NULL"}");
    }
}

Console.WriteLine("GOODBYE.");

