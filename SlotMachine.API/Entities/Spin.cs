using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace SlotMachine.API.Entities
{
    public class Spin
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int Bet { get; set; }
        public DateTime SpinDateTime { get; set; }
        public int[] Result { get; set; }
        public int PlayerId { get; set; }

    }
}
