using DDDSample1.Domain.Deliveries;



namespace testProject{
public class DeliveryDateTest
{
 [Fact]
    public void TestNewDate()
    {
        Assert.NotNull(21112022);
    }

    [Theory]
    [InlineData(21122022)]
    [InlineData(31102022)]
    [InlineData(12122011)]
    public void ValidDate(long date)
    {
    
        //Deliveries
        long date1 = 23112022;
        int mass1 = 4;
        int timeLoad1 = 2;
        int timeUnload1 = 5;
        DeliveryIdentifier identifier1 = new DeliveryIdentifier("1234");

        //Arrange
        var data = date;

        //Act
        long expected = data;
      
        //Assert
         Assert.IsType<long>(expected);
    }

}
}