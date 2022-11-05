using MongoDB.Driver;
using SlotMachine.API.Entities;

namespace SlotMachine.API.Data.Interfaces
{
    public interface IGameContext
    {
        IMongoCollection<Player> Players { get; }
        IMongoCollection<GameConfiguration> Configuration { get; }
        IMongoCollection<Spin> Spins { get; }
    }
}