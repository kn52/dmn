using ConsoleApp.Areas;

public class Programs
{
    public static void Main(string[] args)
    {
        //SqlDBConnection.DBConnection();
        MongoDBConnection.DBConnection();

        Console.WriteLine("Hello, World!");
    }
}