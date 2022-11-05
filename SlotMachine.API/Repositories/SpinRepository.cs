using SlotMachine.API.Data.Interfaces;
using SlotMachine.API.Entities;
using SlotMachine.API.Repositories.Base;
using SlotMachine.API.Repositories.Interfaces;
using System.Threading.Tasks;

namespace SlotMachine.API.Repositories
{
    public class SpinRepository: BaseRepository, ISpinRepository
    {

        public SpinRepository(IGameContext context)
          : base(context)
        {
        }

        public async Task CreateAsync(Spin spin)
        {
            await _context.Spins.InsertOneAsync(spin);
        }
    }
}
