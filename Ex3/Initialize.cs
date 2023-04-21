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
}

