using MongoDB.Driver;
using SlotMachine.API.Data.Interfaces;
using SlotMachine.API.Entities;
using SlotMachine.API.Settings;

namespace SlotMachine.API.Data
{
    public class GameContext: IGameContext
    {
        public IMongoCollection<Player> Players { get; }
        public IMongoCollection<GameConfiguration> Configuration { get; }
        public IMongoCollection<Spin> Spins { get; }


        public GameContext(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Players = database.GetCollection<Player>(settings.CollectionNames.Players);
            Configuration = database.GetCollection<GameConfiguration>(settings.CollectionNames.Configuration);
            Spins = database.GetCollection<Spin>(settings.CollectionNames.Spins);

            GameContextSeed.SeedData(Players, Configuration);
        }
    }
}
