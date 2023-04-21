using Ex3;
using Ex3.Models;
using Ex3.Models.Entities;
using Ex3.Repositories.DbContexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


Console.WriteLine("Ex3");

Console.WriteLine("...");
Initialize.Run();
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
// dotnet ef dbcontext Scaffold "Server=127.0.0.1,1433;Database=ArtTest;User ID=SA;Password=r00t.R00T;Encrypt=True;TrustServerCertificate=True;Connection Timeout=180;" Microsoft.EntityFrameworkCore.SqlServer -o Models/DB
// dotnet ef dbcontext Scaffold "Server=127.0.0.1,1433;Database=ArtTest;User ID=SA;Password=r00t.R00T;Integrated Security=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=60;" Microsoft.EntityFrameworkCore.SqlServer -o Models/DB


// dotnet ef dbcontext Scaffold "Server=127.0.0.1,1433;Initial Catalog=ArtTest;Persist Security Info=False;User ID=SA;Password=r00t.R00T;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;" -Provider Microsoft.EntityFrameworkCore.SqlServer -o Models/DB
// dotnet ef dbcontext Scaffold "Server=127.0.0.1,1433;Database=ArtTest;Persist Security Info=False;User ID=SA;Password=r00t.R00T;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;" Microsoft.EntityFrameworkCore.SqlServer -o Models/DB
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

Console.WriteLine("GOODBYE.");

