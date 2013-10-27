using MongoDB.Bson;

namespace Heisenberg.Entities
{
    public abstract class Entity
    {
        public ObjectId Id { get; set; }
    }
}
