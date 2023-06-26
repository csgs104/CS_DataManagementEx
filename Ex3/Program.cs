using Ex3;
using Ex3.Models;
using Ex3.Models.Entities;
using Ex3.Repositories.DbContexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


Console.WriteLine("BEGIN: Ex3");

Console.WriteLine("...");
Initialize.Run();
Console.WriteLine("...");

var db = new ArtTestContext();

Console.WriteLine("...");
Initialize.Insert();
Console.WriteLine("...");

// Nuget Packages For Everyone:
// Micreosoft.EntityFrameworkCore
// Micreosoft.EntityFrameworkCore.SqlServer
// Micreosoft.EntityFrameworkCore.Tools

// Nuget Packages Optional:
// Micreosoft.EntityFrameworkCore.Design
// Needed If You Use MacOs... And, I Use MacOs

// run program... 

// SCAFFOLD For MacOS Users Only:
// install on terminal: dotnet ef

// scaffold on project terminal:
// dotnet ef dbcontext Scaffold "Server=127.0.0.1,1433;Database=ArtTest;User ID=SA;Password=r00t.R00T;Encrypt=True;TrustServerCertificate=True;Connection Timeout=180;" Microsoft.EntityFrameworkCore.SqlServer -o DB

// migration on project terminal:
// do first: dotnet ef migrations add Initial
// do undo: dotnet ef migrations remove
// do update: dotnet ef database update

// migrations: 1. Initial, 2. ...

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
            ArtworkName = r.Name,
            MuseumOut = r.Museum,
            CharacterOut = r.Character
        }).ToList();

    foreach (var r in rs) 
    {
        Console.WriteLine($"MuseumName: {r.MuseumOut.Name}, ArtworkName: {r.ArtworkName}, CharacterName: {r.CharacterOut?.Name ?? "NULL"}");
    }
}

var query2 = $@"
    SELECT ar.[Name] AS ArtistName, ak.[Name] AS ArtworkName
    FROM [Art].[dbo].[Artwork] ak
    JOIN [Art].[dbo].[Museum] mm ON mm.[Id_Museum] = ak.[Id_Museum]
    JOIN [Art].[dbo].[Artist] ar ON ar.[Id_Artist] = ak.[Id_Artist]
    WHERE mm.[City] = 'Parigi'";

void Query2()
{
    var rs = db?.Artworks
        .Include(museum => museum.Museum)
        .Include(artist => artist.Artist)
        .Where(r => r.Museum.City == "Parigi")
        .Select(r => new {
            ArtworkName = r.Name,
            ArtistOut = r.Artist
        }).ToList();

    foreach (var r in rs)
    {
        Console.WriteLine($"MuseumName: {r.ArtistOut.Name}, ArtworkName: {r.ArtworkName}");
    }
}

var query3 = $@"
    SELECT mm.[City] AS CityName 
    FROM [Art].[dbo].[Artwork] ak
    JOIN [Art].[dbo].[Museum] mm ON mm.[Id_Museum] = ak.[Id_Museum]
    WHERE ak.[Name] = 'Flora'";

void Query3()
{
    var rs = db?.Artworks
        .Include(museum => museum.Museum)
        .Include(artist => artist.Artist)
        .Where(r => r.Name == "Flora")
        .Select(r => new {
            MuseumOut = r.Museum
        }).ToList();

    foreach (var r in rs)
    {
        Console.WriteLine($"CityName: {r.MuseumOut.City}");
    }
}

Console.WriteLine("Query1: " + query1);
Console.WriteLine("Results:");
Query1();

Console.WriteLine("...");
Console.WriteLine("...");

Console.WriteLine("Query2: " + query2);
Console.WriteLine("Results:");
Query2();

Console.WriteLine("...");
Console.WriteLine("...");

Console.WriteLine("Query3: " + query3);
Console.WriteLine("Results:");
Query3();

Console.WriteLine("...");
Console.WriteLine("...");

Console.WriteLine("END");