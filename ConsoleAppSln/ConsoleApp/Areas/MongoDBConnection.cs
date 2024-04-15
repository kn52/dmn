using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MySqlConnector;
using System;
using System.Linq;

namespace ConsoleApp.Areas
{
    public static class MongoDBConnection
    {
        public static void DBConnection()
        {
            try
            {
                Console.WriteLine("====================================================");
                Console.WriteLine("Configuration Setting: 127.0.0.1:27017");
                Console.WriteLine("====================================================");
                string connectionString = "mongodb://127.0.0.1:27017";
                string dbString = "testDB";
                MongoClient client = null;
                MongoServer server = null;
                MongoDatabase database = null;
                MongoCollection symbolcollection = null;

                client = new MongoClient(connectionString);
                server = client.GetServer();
                database = server.GetDatabase(dbString);
                //database.DropCollection("Symbol");
                symbolcollection = database.GetCollection<Symbol>("Symbol");
                Console.WriteLine(symbolcollection.Count().ToString());
                ObjectId id = new ObjectId();


                //Symbol symbol = new Symbol();
                //symbol.Name = "ani";
                //symbolcollection.Insert(symbol);
                //id = symbol.ID;

                //symbol = new Symbol();
                //symbol.Name = "aki";
                //symbolcollection.Insert(symbol);
                //id = symbol.ID;

                List<Symbol> query = symbolcollection.AsQueryable<Symbol>().Select(sb => new Symbol()
                {
                    ID = sb.ID,
                    Name = sb.Name,
                }).ToList();
                Console.WriteLine(query.ToString());

                var s1ymbol = (Symbol)symbolcollection.AsQueryable<Symbol>().Where<Symbol>(sb => sb.Name == "ani");
                Console.WriteLine(s1ymbol);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    public class Symbol
    {
        public string Name { get; set; }
        public ObjectId ID { get; set; }
        public ObjectId _id { get; set; }
    }
}
