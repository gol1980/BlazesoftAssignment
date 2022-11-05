using SlotMachine.API.Entities;
using System.Threading.Tasks;

namespace SlotMachine.API.Repositories.Interfaces
{
    public interface ISpinRepository
    {
        Task CreateAsync(Spin spin);
    }
}