using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SlotMachine.API.Entities
{
    public class GameConfiguration
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int NumOfReels { get; set; }
    }
}
