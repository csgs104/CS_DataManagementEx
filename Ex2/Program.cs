using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;
using static Ex2.Constants;

Console.WriteLine("Ex2");

Console.WriteLine("...");
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


void Query1()
{
    try
    {
        using var cn = new SqlConnection(ConnectionString);
        using var cmd = new SqlCommand(query1 /* command = SELECT ... */, cn /* connection */);
        cn.Open(); /* open connection */
        using var reader = cmd.ExecuteReader();
        while (reader?.Read() == true)
        {
            var museumName = string.Empty;
            var artworkName = string.Empty;
            var characterName = string.Empty;

            try { museumName = reader.GetString("MuseumName"); }
            catch (SqlNullValueException) { museumName = "NULL"; }
            try { artworkName = reader.GetString("ArtworkName"); }
            catch (SqlNullValueException) { artworkName = "NULL"; }
            try { characterName = reader.GetString("CharacterName"); }
            catch (SqlNullValueException) { characterName = "NULL"; }

            Console.Error.WriteLine($"MuseumName: {museumName}, ArtworkName: {artworkName}, CharacterName: {characterName}");
        }
    }
    catch (SqlException ex)
    {
        Console.Error.WriteLine(ex);
    }
}

void Query2()
{
    try
    {
        using var cn = new SqlConnection(ConnectionString);
        using var cmd = new SqlCommand(query2 /* command = SELECT ... */, cn /* connection */);
        cn.Open(); /* open connection */
        using var reader = cmd.ExecuteReader();
        while (reader?.Read() == true)
        {
            var artistName = string.Empty;
            var artworkName = string.Empty;

            try { artistName = reader.GetString("ArtistName"); }
            catch (SqlNullValueException) { artistName = "NULL"; }
            try { artworkName = reader.GetString("ArtworkName"); }
            catch (SqlNullValueException) { artworkName = "NULL"; }

            Console.Error.WriteLine($"ArtistName: {artistName}, ArtworkName: {artworkName}");
        }
    }
    catch (SqlException ex)
    {
        Console.Error.WriteLine(ex);
    }
}

void Query3()
{
    try
    {
        using var cn = new SqlConnection(ConnectionString);
        using var cmd = new SqlCommand(query3 /* command = SELECT ... */, cn /* connection */);
        cn.Open(); /* open connection */
        using var reader = cmd.ExecuteReader();
        while (reader?.Read() == true)
        {
            var cityName = string.Empty;
            var artworkName = string.Empty;

            try { cityName = reader.GetString("CityName"); }
            catch (SqlNullValueException) { cityName = "NULL"; }

            Console.Error.WriteLine($"CityName: {cityName}");
        }
    }
    catch (SqlException ex)
    {
        Console.Error.WriteLine(ex);
    }
}

Console.WriteLine("Query1: " + query1);
Console.WriteLine("Results:");
Query1();

Console.WriteLine("...");
Console.WriteLine("...");

Console.WriteLine("Query2:" + query2);
Console.WriteLine("Results:");
Query2();

Console.WriteLine("...");
Console.WriteLine("...");

Console.WriteLine("Query3:" + query3);
Console.WriteLine("Results:");
Query3();

Console.WriteLine("...");
Console.WriteLine("...");

Console.WriteLine("GOODBYE.");