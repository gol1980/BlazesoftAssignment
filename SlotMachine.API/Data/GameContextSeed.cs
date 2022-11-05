using MongoDB.Driver;
using SlotMachine.API.Entities;
using System.Collections.Generic;

namespace SlotMachine.API.Data
{
    public class GameContextSeed
    {
        public static void SeedData(IMongoCollection<Player> Players, 
            IMongoCollection<GameConfiguration> Configuration)
        {
            bool isPlayerExits = Players.Find(p => true).Any();
            if (!isPlayerExits)
            {
                Players.InsertManyAsync(GetPlayers());
            }

            bool isConfigureExist = Configuration.Find(p => true).Any();
            if (!isConfigureExist)
            {
                GameConfiguration gf = new GameConfiguration { NumOfReels = 3 };
                Configuration.InsertOneAsync(gf);
            }
        }

        public static IEnumerable<Player> GetPlayers()
        {
            return new List<Player>
            {
                new Player
                {
                    Id = 1,
                    Name = "Bar",
                    Balance = 100
                },
                new Player
                {
                    Id = 2,
                    Name = "Mike",
                    Balance = 100
                }
            };
        }
    }
}
