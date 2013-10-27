using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Heisenberg.Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Heisenberg.MongoDataStore
{
    public class Tracer : ITracer
    {
        public IEnumerable<string> DbConnectionCheck()
        {
            var connectionstring = ConfigurationManager.AppSettings.Get("MONGOLAB_URI");
            var url = new MongoUrl(connectionstring);
            var client = new MongoClient(url);
            var server = client.GetServer();
            var database = server.GetDatabase(url.DatabaseName);

            var collection = database.GetCollection<Thingy>("Thingies");

            // insert object
            collection.Insert(new Thingy { Name = Guid.NewGuid().ToString() });

            // fetch all objects
            var thingies = collection.FindAll();

            return thingies.Select(x => x.Name);
        }

        public class Thingy
        {
            public ObjectId Id { get; set; }
            public string Name { get; set; }
        }
    }
}
