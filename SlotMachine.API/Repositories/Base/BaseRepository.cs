using SlotMachine.API.Data.Interfaces;

namespace SlotMachine.API.Repositories.Base
{
    public class BaseRepository
    {

        protected IGameContext _context;

        public BaseRepository(IGameContext context)
        {
            _context = context;
        }
    }
}
