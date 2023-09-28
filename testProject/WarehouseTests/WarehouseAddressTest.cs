using System;
using DDDSample1.Domain.Warehouses;
using Xunit;

namespace WarehouseTest{}

public class WarehouseAddressTest
{

    /*
    [Fact]
    public void TestNewAddress()
    {
        Assert.NotNull(new Address("Avenida da Liberdade", 230, "Lisboa", "1070-312"));
    }
    
    [Fact]
    public void Test()
    {
        Assert.NotNull(new Address("Avenida da Liberdade", 230, "Lisboa", "1070-312"));
    }
    
    [Theory]
    [InlineData("Avenida da liberdade",200,"Lisbon","1070-234", "Avenida da liberdade")]
    [InlineData("Rua do Carmo",200,"Lisbon","1070-234", "Rua do Carmo")]
    [InlineData("Travessa da fonte",200,"Lisbon","1070-234", "Travessa da fonte")]
    public void CanAddValidStreet(string street, int doorNumber, string city, string zipCode, string expectedResult)
    {
        //Arrange
        var address = new Address();

        //Act
        string expected = address.validateString(street);
      
        //Assert
        Assert.Equal(expected, expectedResult);
    }
    
    [Theory]
    [InlineData("",200,"Lisbon","1070-234")]
    [InlineData(null,200,"Lisbon","1070-234")]
    public void InvalidStreet(string street, int doorNumber, string city, string zipCode)
    {
        //Arrange
        var address = new Address(street,doorNumber,city,zipCode);

        //Act
        //string expected = address.validateString(street);
      
        //Assert
        Assert.Throws<ArgumentNullException>(() => address.validateString(street));
    }*/

   
}