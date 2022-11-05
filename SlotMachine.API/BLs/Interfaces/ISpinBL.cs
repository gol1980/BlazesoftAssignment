using SlotMachine.API.Models.Responses;
using System.Threading.Tasks;

namespace SlotMachine.API.BLs.Interfaces
{
    public interface ISpinBL
    {
        Task<SpinResponse> Play(int playerId, int betAmount);
    }
}