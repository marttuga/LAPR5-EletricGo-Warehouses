using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;
using Moq;
using testProject.MockData;

namespace testProject.Systems.Services;

public class WarehouseServiceTest
{
    private Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
    private Mock<IWarehouseRepository> _repoMock = new Mock<IWarehouseRepository>();
    private const String WarehouseIdOne = "W07";
    private const String WarehouseIdTwo = "W08";

    [Fact]
    public async Task TestGetAllAsync()
    {
        //Arrange
        var warehouseList = WarehouseMockData.GetWarehousesList;
        this._repoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(warehouseList);
        var _service = new WarehouseService(_unitOfWorkMock.Object, _repoMock.Object);
        
        //Act
        var list = await _service.GetAllAsync();
        
        //Assert
        Assert.Equal( WarehouseIdOne,list[0].WarehouseIdentifier);
        Assert.Equal( WarehouseIdTwo,list[1].WarehouseIdentifier);
        Assert.Equal(2,list.Count);
    }
    
    [Fact]
    public async Task TestGetByWarehouseIdAsync() //TODO
    {
        //Arrange
        var warehouse = WarehouseMockData.GetWarehouse();
        this._repoMock.Setup(repo => repo.GetByWarehouseIdAsync(warehouse.WarehouseIdentifier.WarehouseIdentifier)).ReturnsAsync(warehouse);
        var _service = new WarehouseService(_unitOfWorkMock.Object, _repoMock.Object);
        
        //Act
        var get_warehouse = await _service.GetByWarehouseIdAsync(warehouse.WarehouseIdentifier.WarehouseIdentifier);

        //Assert
        Assert.Equal(warehouse.WarehouseIdentifier.WarehouseIdentifier, get_warehouse.WarehouseIdentifier);
    }

    [Fact]
    public async Task TestPostAsync()
    {
        //Arrange
        var warehouse = WarehouseMockData.GetWarehouse();
        this._repoMock.Setup(repo => repo.AddAsync(warehouse)).ReturnsAsync(warehouse);
        var _service = new WarehouseService(_unitOfWorkMock.Object, _repoMock.Object);
        
        //Act
        var post_warehouse = await _service.AddAsync(new CreatingWarehouseDto(warehouse.WarehouseIdentifier.WarehouseIdentifier, warehouse.Designation.Designation, warehouse.Coordinates.Latitude, warehouse.Coordinates.Longitude,warehouse.Address.Street,warehouse.Address.DoorNumber,warehouse.Address.City, warehouse.Address.ZipCode, warehouse.WarehouseAltitude.WarehouseAltitude));

        //Assert
        Assert.Equal(warehouse.WarehouseIdentifier.WarehouseIdentifier,post_warehouse.WarehouseIdentifier);

    }

    [Fact]
    public async Task TestPutAsync()
    {
        //Arrange
        var warehouse = WarehouseMockData.GetWarehousePut();
        var warehouseaDto = WarehouseMockData.GetWarehouseDtoUpdated();
        this._repoMock.Setup(repo => repo.GetByWarehouseIdAsync(warehouse.WarehouseIdentifier.WarehouseIdentifier)).ReturnsAsync(warehouse);
        var _service = new WarehouseService(_unitOfWorkMock.Object, _repoMock.Object);
        
        //Act
        var update = await _service.UpdateWarehouseAsync(warehouseaDto);
        
        //Assert
        Assert.Equal(warehouseaDto.WarehouseIdentifier,update.WarehouseIdentifier);
        Assert.Equal(warehouseaDto.Designation,update.Designation);
        Assert.Equal(warehouseaDto.Street,update.Street);
        Assert.Equal(warehouseaDto.DoorNumber,update.DoorNumber);
        Assert.Equal(warehouseaDto.City,update.City);
        Assert.Equal(warehouseaDto.ZipCode,update.ZipCode);
        Assert.Equal(warehouseaDto.Latitude,update.Latitude);
        Assert.Equal(warehouseaDto.Longitude,update.Longitude);
        Assert.Equal(warehouseaDto.WarehouseAltitude,update.WarehouseAltitude);
    }
}
