using DDDSample1.Domain.Deliveries;

namespace testProject
{
    public class DeliveryTimeLoadTest
    {
        [Fact]
        public void TestNewTimeLoad()
        {
            Assert.NotNull(2);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void ValidTimeLoad(int timeLoad)
        {

            //Arrange
            var time = timeLoad;

            //Act
            int expected = time;

            //Assert
            Assert.IsType<int>(expected);
        }

    }
}