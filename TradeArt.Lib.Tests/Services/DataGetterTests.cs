using Moq;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using TradeArt.Lib.Services;

namespace TradeArt.Lib.Tests.Services
{
    public class DataGetterTests
    {
        private IDataGetter _dataGetter;
        private Mock<IExternalService> _externalService;

        [SetUp]
        public void SetUp()
        {
            _externalService = new Mock<IExternalService>();
            _dataGetter = new DataGetter(_externalService.Object);
        }

        [Test]
        public async Task Should_Return_Data_Without_Minus_Ones()
        {
            // Arrange 
            _externalService.Setup(e => e.ProcessAsync(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var numbers = await _dataGetter.GetAsync();

            // Assert
            Assert.IsFalse(numbers.Any(n => n == -1));
        }

        [Test]
        public async Task Should_Return_Data_With_Minus_Ones()
        {
            // Arrange 
            _externalService.Setup(e => e.ProcessAsync(It.IsAny<int>())).ReturnsAsync(false);

            // Act
            var numbers = await _dataGetter.GetAsync();

            // Assert
            Assert.IsTrue(numbers.Any(n => n == -1));
        }
    }
}
