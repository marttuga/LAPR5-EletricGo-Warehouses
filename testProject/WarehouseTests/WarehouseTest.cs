using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;

namespace testProject.WarehouseTests
{
    public class WarehouseTest
    {
        [Theory]
        [InlineData(null,"Porto Storage Center","Rua do Carmo",269,"4050-157","Porto",(float) 41.15,(float)-8.61024,"200")]
        [InlineData("W01",null,"Rua do Carmo",269,"4050-157","Porto",(float) 41.15,(float)-8.61024,"200")]
        [InlineData("W01","Porto Storage Center",null,269,"4050-157","Porto",(float) 41.15,(float)-8.61024,"200")]
        [InlineData("W01","Porto Storage Center","Rua do Carmo",269,"4050-157",null,(float) 41.15,(float)-8.61024,"200")]
        [InlineData("W01","Porto Storage Center","Rua do Carmo",269,"4050-157","Porto",(float) 41.15,(float)-8.61024,null)]
        public void AttributesBeingNull(string warehouseIdentifier,string designation,string street,int doorNumber,string zipCode,string city,float latitude,float longitude,string altitude)
        {
            Assert.Throws<ArgumentNullException>(() => new Warehouse(new WarehouseId(warehouseIdentifier),
                new WarehouseDesignation(designation),new Coordinate(latitude, longitude), new Address(
                street, doorNumber, city, zipCode) , new Altitude(altitude)));
        }
        
        [Theory]
        [InlineData("W01","Porto Storage Center","Rua do Carmo",0,"4050-157","Porto",(float) 41.15,(float)-8.61024,"200")]
        [InlineData("W01","Porto Storage Center","Rua do Carmo",-84,"4050-157","Porto",(float) 41.15,(float)-8.61024,"200")]
        [InlineData("W01","Porto Storage Center","Rua do Carmo",269,"4050-157","Porto",(float) 41.15,(float)-8.61024,"-89")]
        public void AltitudeAndDoorNumberBeingZeroOrNegative(string warehouseIdentifier,string designation,string street,int doorNumber,string zipCode,string city,float latitude,float longitude,string altitude)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Warehouse(new WarehouseId(warehouseIdentifier),
                new WarehouseDesignation(designation),new Coordinate(latitude, longitude), new Address(
                    street, doorNumber, city, zipCode) , new Altitude(altitude)));
        }
        
        [Theory]
        [InlineData("W01","Porto Storage Center","Rua do Carmo",269,"40550-1567","Porto",(float) 41.15,(float)-8.61024,"200")]
        [InlineData("W01","Porto Storage Center","Rua do Carmo",269,"4050","Porto",(float) 41.15,(float)-8.61024,"200")]
        [InlineData("W01","Porto Storage Center","Rua do Carmo",269,"5-2","Porto",(float) 41.15,(float)-8.61024,"200")]
        [InlineData("W01","Porto Storage Center","Rua do Carmo",269,"","Porto",(float) 41.15,(float)-8.61024,"200")]
        public void ZipCodeNotValid(string warehouseIdentifier,string designation,string street,int doorNumber,string zipCode,string city,float latitude,float longitude,string altitude)
        {
            Assert.Throws<FormatException>(() => new Warehouse(new WarehouseId(warehouseIdentifier),
                new WarehouseDesignation(designation),new Coordinate(latitude, longitude), new Address(
                    street, doorNumber, city, zipCode) , new Altitude(altitude)));
        }
        
        [Theory]
        [InlineData("9","Porto Storage Center","Rua do Carmo",269,"4050-157","Porto",(float) 41.15,(float)-8.61024,"200")]
        [InlineData("ty657","Porto Storage Center","Rua do Carmo",269,"4050-157","Porto",(float) 41.15,(float)-8.61024,"200")]
        public void WarehouseIdNotValid(string warehouseIdentifier,string designation,string street,int doorNumber,string zipCode,string city,float latitude,float longitude,string altitude)
        {
            Assert.Throws<BusinessRuleValidationException>(() => new Warehouse(new WarehouseId(warehouseIdentifier),
                new WarehouseDesignation(designation),new Coordinate(latitude, longitude), new Address(
                    street, doorNumber, city, zipCode) , new Altitude(altitude)));
        }
        
        [Theory]
        [InlineData("W01","Porto Storage Center Center Center Center Center Center Center Center","Rua do Carmo",269,"4050-157","Porto",(float) 41.15,(float)-8.61024,"200")]
        public void DesignationNotValid(string warehouseIdentifier,string designation,string street,int doorNumber,string zipCode,string city,float latitude,float longitude,string altitude)
        {
            Assert.Throws<BusinessRuleValidationException>(() => new Warehouse(new WarehouseId(warehouseIdentifier),
                new WarehouseDesignation(designation),new Coordinate(latitude, longitude), new Address(
                    street, doorNumber, city, zipCode) , new Altitude(altitude)));
        }
        
       
    }
}


