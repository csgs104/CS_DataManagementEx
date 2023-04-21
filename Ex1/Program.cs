using Microsoft.Data.SqlClient;
using static Ex1.Constants;

Console.WriteLine("BEGIN: Ex1");

Console.WriteLine("...");

var createArt = @"
    IF NOT EXISTS (SELECT * FROM [sys].[databases] WHERE [name]='Art') 
    BEGIN CREATE DATABASE [Art] END";

var useArt = @"
    IF EXISTS (SELECT * FROM [sys].[databases] WHERE [name]='Art') 
    BEGIN USE [Art] END";

var createMuseum= @"
    IF NOT EXISTS (SELECT * FROM [sys].[sysobjects] WHERE [name]='Museum' AND [xtype]='U') 
    BEGIN 
    CREATE TABLE [Art].[dbo].[Museum] (
    [Id_Museum] INT PRIMARY KEY, 
    [MuseumName] NVARCHAR(100) NOT NULL, 
    [City] NVARCHAR(100) NOT NULL
    ) END";

var createArtist = @"
    IF NOT EXISTS (SELECT * FROM [sys].[sysobjects] WHERE [name]='Artist' and [xtype]='U') 
    BEGIN 
    CREATE TABLE [Art].[dbo].[Artist] (
    [Id_Artist] INT PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    [Country] NVARCHAR(100) NOT NULL
    ) END";

var createCharacter = @"
    IF NOT EXISTS (SELECT * FROM [sys].[sysobjects] WHERE [name]='Character' and [xtype]='U') 
    BEGIN 
    CREATE TABLE [Art].[dbo].[Character] (
    [Id_Character] INT PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL
    ) END";

var createArtwork = @"
    IF NOT EXISTS (SELECT * FROM [sys].[sysobjects] WHERE [name]='Artwork' and [xtype]='U') 
    BEGIN 
    CREATE TABLE [Art].[dbo].[Artwork] (
    [Id_Artwork] INT PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Id_Museum] INT NOT NULL REFERENCES [Art].[dbo].[Museum], 
    [Id_Artist] INT NOT NULL REFERENCES [Art].[dbo].[Artist], 
    [Id_Character] INT NULL REFERENCES [Art].[dbo].[Character]
    ) END";

var insertMuseums = @"
    IF NOT EXISTS (SELECT * FROM [Art].[dbo].[Museum] WHERE [Id_Museum] = 1) 
    BEGIN INSERT INTO [Art].[dbo].[Museum] VALUES (1,'Santa Maria Gloriosa dei Frari','Venezia') END
    IF NOT EXISTS (SELECT * FROM [Art].[dbo].[Museum] WHERE [Id_Museum] = 2) 
    BEGIN INSERT INTO [Art].[dbo].[Museum] VALUES (2,'Louvre','Parigi') END
    IF NOT EXISTS (SELECT * FROM [Art].[dbo].[Museum] WHERE [Id_Museum] = 3) 
    BEGIN INSERT INTO [Art].[dbo].[Museum] VALUES (3,'Galleria Borghese','Roma') END
    IF NOT EXISTS (SELECT * FROM [Art].[dbo].[Museum] WHERE[Id_Museum] = 4) 
    BEGIN INSERT INTO [Art].[dbo].[Museum] VALUES (4,'Art Institute of Chicagoe','Chicago') END";

var insertArtists = @"
    IF NOT EXISTS (SELECT * FROM [Art].[dbo].[Artist] WHERE [Id_Artist] = 1) 
    BEGIN INSERT INTO [Art].[dbo].[Artist] VALUES (1,'Tiziano Vecellio','Italia') END
    IF NOT EXISTS (SELECT * FROM [Art].[dbo].[Artist] WHERE [Id_Artist] = 2) 
    BEGIN INSERT INTO [Art].[dbo].[Artist] VALUES (2,'Caravaggio','Italia') END
    IF NOT EXISTS (SELECT * FROM [Art].[dbo].[Artist] WHERE [Id_Artist] = 3) 
    BEGIN INSERT INTO [Art].[dbo].[Artist] VALUES (3,'Picasso','Spagna') END";

var insertCharacters = @"
    IF NOT EXISTS (SELECT * FROM [Art].[dbo].[Character] WHERE [Id_Character] = 1) 
    BEGIN INSERT INTO [Art].[dbo].[Character] VALUES (1,'Flora') END
    IF NOT EXISTS (SELECT * FROM [Art].[dbo].[Character] WHERE [Id_Character] = 2) 
    BEGIN INSERT INTO [Art].[dbo].[Character] VALUES (2,'Davide') END
    IF NOT EXISTS (SELECT * FROM [Art].[dbo].[Character] WHERE [Id_Character] = 3) 
    BEGIN INSERT INTO [Art].[dbo].[Character] VALUES (3,'Chitarrista') END";

var insertArtworks = @"
    IF NOT EXISTS (SELECT * FROM [Art].[dbo].[Artwork] WHERE [Id_Artwork] = 1) 
    BEGIN INSERT INTO [Art].[dbo].[Artwork] VALUES (1,'Flora',1,1,1) END
    IF NOT EXISTS (SELECT * FROM [Art].[dbo].[Artwork] WHERE [Id_Artwork] = 2) 
    BEGIN INSERT INTO [Art].[dbo].[Artwork] VALUES (2,'Concerto campestre',2,1,NULL) END
    IF NOT EXISTS (SELECT * FROM [Art].[dbo].[Artwork] WHERE [Id_Artwork] = 3) 
    BEGIN INSERT INTO [Art].[dbo].[Artwork] VALUES (3,'Davide con la testa di Golia',3,2,2) END
    IF NOT EXISTS (SELECT * FROM [Art].[dbo].[Artwork] WHERE [Id_Artwork] = 4) 
    BEGIN INSERT INTO [Art].[dbo].[Artwork] VALUES (4,'Il vecchio chitarrista cieco',4,3,3) END";


using var cn = new SqlConnection(ConnectionString);
using var cmdCreateArt = new SqlCommand(createArt, cn);
using var cmdUseArt = new SqlCommand(useArt, cn);

using var cmdCreateMuseum = new SqlCommand(createMuseum, cn);
using var cmdInsertMuseums = new SqlCommand(insertMuseums, cn);

using var cmdCreateArtist = new SqlCommand(createArtist, cn);
using var cmdInsertArtists = new SqlCommand(insertArtists, cn);

using var cmdCreateCharacter = new SqlCommand(createCharacter, cn);
using var cmdInsertCharacters = new SqlCommand(insertCharacters, cn);

using var cmdCreateArtwork = new SqlCommand(createArtwork, cn);
using var cmdInsertArtworks = new SqlCommand(insertArtworks, cn);

try
{
    Console.WriteLine("START INITIALIZATION.");

    Console.WriteLine("...");

    Console.Write("OPEN CONNECTION...\t\t");
    cn.Open();
    Console.WriteLine("OK!");


    Console.Write("CREATE DATABASE Art...\t\t");
    cmdCreateArt.ExecuteNonQuery();
    Console.WriteLine("OK!");

    Console.Write("USE Art...\t\t\t");
    cmdUseArt.ExecuteNonQuery();
    Console.WriteLine("OK!");

    Console.Write("CREATE TABLE Museum...\t\t");
    cmdCreateMuseum.ExecuteNonQuery();
    Console.WriteLine("OK!");
    Console.Write("INSERT INTO TABLE Museum...\t");
    cmdInsertMuseums.ExecuteNonQuery();
    Console.WriteLine("OK!");

    Console.Write("CREATE TABLE Artist...\t\t");
    cmdCreateArtist.ExecuteNonQuery();
    Console.WriteLine("OK!");
    Console.Write("INSERT INTO TABLE Artist...\t");
    cmdInsertArtists.ExecuteNonQuery();
    Console.WriteLine("OK!");

    Console.Write("CREATE TABLE Character...\t");
    cmdCreateCharacter.ExecuteNonQuery();
    Console.WriteLine("OK!");
    Console.Write("INSERT INTO TABLE Character...\t");
    cmdInsertCharacters.ExecuteNonQuery();
    Console.WriteLine("OK!");

    Console.Write("CREATE TABLE Artwork...\t\t");
    cmdCreateArtwork.ExecuteNonQuery();
    Console.WriteLine("OK!");
    Console.Write("INSERT INTO TABLE Artwork...\t");
    cmdInsertArtworks.ExecuteNonQuery();
    Console.WriteLine("OK!");

    Console.WriteLine("...");

    Console.WriteLine("FINISH INITIALIZATION.");
}
catch (SqlException ex)
{
    Console.Error.WriteLine(ex);
}

Console.WriteLine("...");

var query1 = $@"
    SELECT mm.[MuseumName], ak.[Name] AS ArtworkName, cr.[Name] AS CharacterName
    FROM [Art].[dbo].[Artwork] ak
    JOIN [Art].[dbo].[Museum] mm ON mm.[Id_Museum] = ak.[Id_Museum]
    JOIN [Art].[dbo].[Artist] ar ON ar.[Id_Artist] = ak.[Id_Artist]
    LEFT JOIN [Art].[dbo].[Character] cr ON cr.[Id_Character] = ak.[Id_Character]
    WHERE ar.[Country] = 'Italia'";

var query2 = $@"
    SELECT ar.[Name] AS ArtistName, ak.[Name] AS ArtworkName
    FROM [Art].[dbo].[Artwork] ak
    JOIN [Art].[dbo].[Museum] mm ON mm.[Id_Museum] = ak.[Id_Museum]
    JOIN [Art].[dbo].[Artist] ar ON ar.[Id_Artist] = ak.[Id_Artist]
    WHERE mm.[City] = 'Parigi'";

var query3 = $@"
    SELECT mm.[City] AS CityName 
    FROM [Art].[dbo].[Artwork] ak
    JOIN [Art].[dbo].[Museum] mm ON mm.[Id_Museum] = ak.[Id_Museum]
    WHERE ak.[Name] = 'Flora'";

Console.WriteLine("Query1: " + query1);

Console.WriteLine("...");

Console.WriteLine("Query2:" + query2);

Console.WriteLine("...");

Console.WriteLine("Query3:" + query3);

Console.WriteLine("...");

Console.WriteLine("END");