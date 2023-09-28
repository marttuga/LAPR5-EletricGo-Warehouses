using DDDSample1.Domain.Deliveries;


namespace testProject
{
    public class DeliveryMassTest
    {
        [Fact]
        public void TestNewMass()
        {
            Assert.NotNull(2);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void ValidMass(int massDel)
        {

            //Arrange
            var mass = massDel;

            //Act
            int expected = mass;

            //Assert
            Assert.IsType<int>(expected);
        }

    }
}
