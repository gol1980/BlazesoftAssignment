using SlotMachine.API.Models.Requests;
using SlotMachine.API.Models.Responses;
using System.Threading.Tasks;

namespace SlotMachine.API.BLs.Interfaces
{
    public interface ISpinBL
    {
        Task<int> GetConsecutiveResultAsync(int[] reels);
        Task<SpinResponse> PlayAsync(SpinRequest spinData);
        Task<int[]> SpinReelsAsync(int numOfReels);
    }
}