using System.Net.Http;
using System.Threading.Tasks;

namespace SlotMachine.API.Clients
{
    public class LockerClient : ILockerClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LockerClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task GetLock(int playerId)
        {
            var httpClient = _httpClientFactory.CreateClient("Locker");
            var httpResponseMessage = await httpClient.GetAsync($"lock/lock/{playerId}");

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                //throw an error
            }
        }

        public async Task GetRelease(int playerId)
        {
            var httpClient = _httpClientFactory.CreateClient("Locker");
            var httpResponseMessage = await httpClient.GetAsync($"lock/release/{playerId}");

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                //throw an error
            }
        }
    }
}
