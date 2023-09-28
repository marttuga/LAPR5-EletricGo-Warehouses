using DDDSample1.Domain.Deliveries;

namespace testProject{
public class DeliveryTimeUnloadTest
{
 [Fact]
    public void TestNewTimeUnload()
    {
        Assert.NotNull(8);
    }

    [Theory]
    [InlineData(7)]
    [InlineData(11)]
    [InlineData(8)]
    public void ValidTimeUnload(int timeUnload)
    {
    
        //Arrange
        var time = timeUnload;

        //Act
        int expected = time;
      
        //Assert
        Assert.IsType<int>(expected);
    }

}
}