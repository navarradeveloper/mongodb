using System;
using System.Data.Entity;
using Blog.Entities.Entities;
using MongoDB.Driver;

namespace Blog.DA
{
    public class MyContext : IDisposable
    {

        public MongoDatabase DB{get; protected set;}

        public MyContext(string connString){
            /*
            var con = new MongoConnectionStringBuilder(connString);
            var server = MongoServer.Create(con);
            DB = server.GetDatabase(con.DatabaseName);
            */
            var con = new MongoConnectionStringBuilder(connString);
            var client = new MongoClient(connString);
            var server = client.GetServer();
            DB = server.GetDatabase(con.DatabaseName);
        }


        public void Dispose() {
            GC.SuppressFinalize(this);
        }

    }
}
