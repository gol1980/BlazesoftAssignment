using SlotMachine.API.BLs;
using Xunit;
using Moq;
using SlotMachine.API.Repositories.Interfaces;
using System.Threading.Tasks;

namespace SlotMachine.Test
{
    public class SpinBLTests
    {
        private readonly Mock<IGameConfigurationRepository> _gameConfiguration;
        private readonly Mock<ISpinRepository> _spinRepository;
        private readonly Mock<IPlayerRepository> _playerRepository;
        private readonly SpinBL _spinBL;

        public SpinBLTests()
        {
            _gameConfiguration = new Mock<IGameConfigurationRepository>();
            _spinRepository = new Mock<ISpinRepository>();
            _playerRepository = new Mock<IPlayerRepository>();

            _spinBL = new SpinBL(_gameConfiguration.Object,
                _spinRepository.Object,
                _playerRepository.Object);
        }

        [Fact]
        public async Task GetConsecutiveResultAsync_GivenArray_ReturnMultipier()
        {
            int[] reels = new int[] { 5, 5, 3, 3 };
            var result = await _spinBL.GetConsecutiveResultAsync(reels);

            Assert.Equal(10, result);
        }
    }
}
