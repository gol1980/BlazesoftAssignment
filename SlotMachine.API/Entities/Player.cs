using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SlotMachine.API.Entities
{
    public class Player
    {
        [BsonId]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
    }
}
