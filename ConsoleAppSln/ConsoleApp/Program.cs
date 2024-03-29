﻿using MySqlConnector;


public class Programs
{
    public static void Main(string[] args)
    {
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
                int id = reader["id"] != null ? Convert.ToInt32(reader["id"]) : 0;
                string name = reader["name"] != null ? reader["name"].ToString() : string.Empty;

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

        Console.WriteLine("Hello, World!");
    }
}