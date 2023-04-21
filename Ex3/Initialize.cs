using System;
using Microsoft.Data.SqlClient;

namespace Ex3;

public static class Initialize
{
    public static void Run() 
    {
        var createArtTest = @"
            IF NOT EXISTS (SELECT * FROM [sys].[databases] WHERE [name]='ArtTest') 
            BEGIN CREATE DATABASE [ArtTest] END";

        using var cn = new SqlConnection("Server=127.0.0.1,1433; Database=Master; Integrated Security=False; User ID=SA; Password=r00t.R00T; Encrypt=True; TrustServerCertificate=True ;Connection Timeout=180;");
        using var cmdCreateArtTest = new SqlCommand(createArtTest, cn);

        try
        {
            Console.WriteLine("START INITIALIZATION.");

            Console.WriteLine("...");

            Console.Write("OPEN CONNECTION...\t\t");
            cn.Open();
            Console.WriteLine("OK!");

            Console.Write("CREATE DATABASE Art...\t\t");
            cmdCreateArtTest.ExecuteNonQuery();
            Console.WriteLine("OK!");

            Console.WriteLine("...");

            Console.WriteLine("FINISH INITIALIZATION.");
        }
        catch (SqlException ex)
        {
            Console.Error.WriteLine(ex);
        }
    }

    public static void Insert() 
    {
        var insertMuseums = @"
            IF NOT EXISTS (SELECT * FROM [ArtTest].[dbo].[Museum] WHERE [Id_Museum] = 1) 
            BEGIN INSERT INTO [ArtTest].[dbo].[Museum] VALUES (1,'Santa Maria Gloriosa dei Frari','Venezia') END
            IF NOT EXISTS (SELECT * FROM [ArtTest].[dbo].[Museum] WHERE [Id_Museum] = 2) 
            BEGIN INSERT INTO [ArtTest].[dbo].[Museum] VALUES (2,'Louvre','Parigi') END
            IF NOT EXISTS (SELECT * FROM [ArtTest].[dbo].[Museum] WHERE [Id_Museum] = 3) 
            BEGIN INSERT INTO [ArtTest].[dbo].[Museum] VALUES (3,'Galleria Borghese','Roma') END
            IF NOT EXISTS (SELECT * FROM [ArtTest].[dbo].[Museum] WHERE[Id_Museum] = 4) 
            BEGIN INSERT INTO [ArtTest].[dbo].[Museum] VALUES (4,'Art Institute of Chicagoe','Chicago') END";

        var insertArtists = @"
            IF NOT EXISTS (SELECT * FROM [ArtTest].[dbo].[Artist] WHERE [Id_Artist] = 1) 
            BEGIN INSERT INTO [ArtTest].[dbo].[Artist] VALUES (1,'Tiziano Vecellio','Italia') END
            IF NOT EXISTS (SELECT * FROM [ArtTest].[dbo].[Artist] WHERE [Id_Artist] = 2) 
            BEGIN INSERT INTO [ArtTest].[dbo].[Artist] VALUES (2,'Caravaggio','Italia') END
            IF NOT EXISTS (SELECT * FROM [ArtTest].[dbo].[Artist] WHERE [Id_Artist] = 3) 
            BEGIN INSERT INTO [ArtTest].[dbo].[Artist] VALUES (3,'Picasso','Spagna') END";

        var insertCharacters = @"
            IF NOT EXISTS (SELECT * FROM [ArtTest].[dbo].[Character] WHERE [Id_Character] = 1) 
            BEGIN INSERT INTO [ArtTest].[dbo].[Character] VALUES (1,'Flora') END
            IF NOT EXISTS (SELECT * FROM [ArtTest].[dbo].[Character] WHERE [Id_Character] = 2) 
            BEGIN INSERT INTO [ArtTest].[dbo].[Character] VALUES (2,'Davide') END
            IF NOT EXISTS (SELECT * FROM [ArtTest].[dbo].[Character] WHERE [Id_Character] = 3) 
            BEGIN INSERT INTO [ArtTest].[dbo].[Character] VALUES (3,'Chitarrista') END";

        var insertArtworks = @"
            IF NOT EXISTS (SELECT * FROM [ArtTest].[dbo].[Artwork] WHERE [Id_Artwork] = 1) 
            BEGIN INSERT INTO [ArtTest].[dbo].[Artwork] VALUES (1,'Flora',1,1,1) END
            IF NOT EXISTS (SELECT * FROM [ArtTest].[dbo].[Artwork] WHERE [Id_Artwork] = 2) 
            BEGIN INSERT INTO [ArtTest].[dbo].[Artwork] VALUES (2,'Concerto campestre',2,1,NULL) END
            IF NOT EXISTS (SELECT * FROM [ArtTest].[dbo].[Artwork] WHERE [Id_Artwork] = 3) 
            BEGIN INSERT INTO [ArtTest].[dbo].[Artwork] VALUES (3,'Davide con la testa di Golia',3,2,2) END
            IF NOT EXISTS (SELECT * FROM [ArtTest].[dbo].[Artwork] WHERE [Id_Artwork] = 4) 
            BEGIN INSERT INTO [ArtTest].[dbo].[Artwork] VALUES (4,'Il vecchio chitarrista cieco',4,3,3) END";

        using var cn = new SqlConnection("Server=127.0.0.1,1433; Database=Master; Integrated Security=False; User ID=SA; Password=r00t.R00T; Encrypt=True; TrustServerCertificate=True ;Connection Timeout=180;");
        using var cmdInsertMuseums = new SqlCommand(insertMuseums, cn);
        using var cmdInsertArtists = new SqlCommand(insertArtists, cn);
        using var cmdInsertCharacters = new SqlCommand(insertCharacters, cn);
        using var cmdInsertArtworks = new SqlCommand(insertArtworks, cn);

        try
        {
            Console.WriteLine("START INSERTION.");

            Console.WriteLine("...");

            Console.Write("OPEN CONNECTION...\t\t");
            cn.Open();
            Console.WriteLine("OK!");

            Console.WriteLine("...");

            Console.Write("INSERT INTO TABLE Museum...\t");
            cmdInsertMuseums.ExecuteNonQuery();
            Console.WriteLine("OK!");

            Console.WriteLine("...");

            Console.Write("INSERT INTO TABLE Artist...\t");
            cmdInsertArtists.ExecuteNonQuery();
            Console.WriteLine("OK!");

            Console.WriteLine("...");

            Console.Write("INSERT INTO TABLE Character...\t");
            cmdInsertCharacters.ExecuteNonQuery();
            Console.WriteLine("OK!");

            Console.WriteLine("...");

            Console.Write("INSERT INTO TABLE Artwork...\t");
            cmdInsertArtworks.ExecuteNonQuery();
            Console.WriteLine("OK!");

            Console.WriteLine("...");

            Console.WriteLine("FINISH INSERTION.");
        }
        catch (SqlException ex)
        {
            Console.Error.WriteLine(ex);
        }
    }
}