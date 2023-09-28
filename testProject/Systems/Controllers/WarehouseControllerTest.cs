using DDDSample1.Domain.Warehouses;
using DDDSample1.Controllers;
using Moq;
using testProject.MockData;



namespace testProject.Systems.Controllers;

public class WarehouseControllerTest
{
    
    private Mock<IWarehouseService> warhouseMockService = new Mock<IWarehouseService>();


    [Fact]
    public async Task TestGetAllWarehouseAsync()
    {
        //Arrange
        var warehouseDtoList = WarehouseMockData.GetWarehousesDtoList();
        this.warhouseMockService.Setup(s => s.GetAllAsync()).ReturnsAsync(warehouseDtoList);
        //SUT (system under testing)
        var sut = new WarehousesController(warhouseMockService.Object);
        
        //Act
        var result = await sut.GetAll();
        
        //Assert
        Assert.Equal(warehouseDtoList, result.Value);
    }
    
    
    
    [Fact]
    public async Task TestGetByWarehouseId()
    {
        //Arrange
        
        var warehouseDto = WarehouseMockData.GetWarehouseDto();
        warhouseMockService.Setup(s => s.GetByWarehouseIdAsync(It.IsAny<string>())).ReturnsAsync(warehouseDto);
        //SUT (system under testing)
        var sut = new WarehousesController(warhouseMockService.Object);
        
        //Act
        var result = await sut.GetGetByWarehouseId("W01");
        
        //Assert
        Assert.Equal(warehouseDto, result.Value);

    }
    
    [Fact]
    public async Task TestGetByDesignation()
    {
        //Arrange
        var warehouseDto = WarehouseMockData.GetWarehouseDto();
        this.warhouseMockService.Setup(s => s.GetByDesignationAsync(It.IsAny<string>())).ReturnsAsync(warehouseDto);
        //SUT (system under testing)
        var sut = new WarehousesController(warhouseMockService.Object);
        
        //Act
        var result = await sut.GetByDesignationAsync("Porto Storage Center");
        
        //Assert
        Assert.Equal(warehouseDto, result.Value);

    }
    
    [Fact]
    public async Task TestCreate()
    {
        //Arrange
        var warehouse = WarehouseMockData.GetCreatingWarehouseDto();
        var warehouseDto = WarehouseMockData.GetWarehouseDto();
        this.warhouseMockService.Setup(s => s.GetByWarehouseIdAsync(warehouse.WarehouseIdentifier)).ReturnsAsync((WarehouseDto)null);
        this.warhouseMockService.Setup(s => s.AddAsync(warehouse)).ReturnsAsync(warehouseDto);
        var sut = new WarehousesController(warhouseMockService.Object);
        
        //Act
        var result = await sut.Create(warehouse);

        //Assert
        Assert.NotNull(result.Result);

    }
    
    [Fact]
    public async Task UpdateWarehouse()
    {
        //Arrange
        var warehouseDto = WarehouseMockData.GetWarehouseDtoUpdated();
        this.warhouseMockService.Setup(s => s.UpdateWarehouseAsync(It.IsAny<WarehouseDto>())).ReturnsAsync(warehouseDto);
        //SUT (system under testing)
        var sut = new WarehousesController(warhouseMockService.Object);
        
        //Act
        var result = await sut.UpdateWarehouse("W01",warehouseDto);
        
        //Assert
        Assert.NotNull( result.Result);

    }
}
