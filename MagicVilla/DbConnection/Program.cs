// See https://aka.ms/new-console-template for more information

using MySqlConnector;
using System.Reflection.PortableExecutable;

static void DbConnecitonTest()
{

    //string cs = @"server=localhost;userid=user12;password=34klq*;database=mydb";
    string cs = @"server=localhost;userid=root;password=num@7869#;database=ni";

    MySqlConnection conn = null;

    try
    {
        conn = new MySqlConnection(cs);
        conn.Open();

        string stm = "SELECT * FROM ni.dbtest;";
        MySqlCommand cmd = new MySqlCommand(stm, conn);
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var id = reader.GetInt32("id"); 
            string name = reader.GetString("name"); 

            Console.WriteLine($"ID: {id}, Name: {name}");
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: {0}", ex.ToString());
    }
    finally
    {

        if (conn != null)
        {
            conn.Close();
        }

    }
}
DbConnecitonTest();

Console.WriteLine("Hello, World!");
