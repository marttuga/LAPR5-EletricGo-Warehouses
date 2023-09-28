using DDDSample1.Controllers;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;
using Moq;
using testProject.MockData;

namespace testProject.Integration;

public class WarehouseControllerServiceTest
{
    private Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
    private Mock<IWarehouseRepository> _repoMock = new Mock<IWarehouseRepository>();


    [Fact]
    public async Task TestGetAllAsync()
    {
        //Arrange
        var warehouselist = WarehouseMockData.GetWarehousesList();
        var warehouselistDto = WarehouseMockData.GetWarehousesDtoList();
        this._repoMock.Setup(_ => _.GetAllAsync()).ReturnsAsync(warehouselist);
        var warehouseService = new WarehouseService(_unitOfWorkMock.Object, _repoMock.Object);
        var controller = new WarehousesController(warehouseService);
        
        //Act
        var actual = await controller.GetAll();

        //Assert
        Assert.Equal(warehouselistDto.Count, actual.Value.Count());

    }
    
    [Fact]
    public async Task TestGetByWarehouseIdAsync()
    {
        //Arrange
        string warehouseId = "W10";
        var warehouse = WarehouseMockData.GetWarehouse();
        this._repoMock.Setup(repo => repo.GetByWarehouseIdAsync(warehouse.WarehouseIdentifier.WarehouseIdentifier)).ReturnsAsync(warehouse);
        var warehouseService = new WarehouseService(_unitOfWorkMock.Object, _repoMock.Object);
        var controller = new WarehousesController(warehouseService);
        
        //ACT
        var actual = await controller.GetGetByWarehouseId(warehouseId);

        //Assert
        Assert.Equal(warehouseId, actual.Value.WarehouseIdentifier);
        
    }
    
    [Fact]
    public async Task TestCreate()
    {
        //Arrange
        var warehouse = WarehouseMockData.GetWarehouse();
        var creatingWarehouse = WarehouseMockData.GetCreatingWarehouseDto();
        this._repoMock.Setup(repo => repo.AddAsync(warehouse)).ReturnsAsync(warehouse);
        var _service = new WarehouseService(_unitOfWorkMock.Object, _repoMock.Object);
        var controller = new WarehousesController(_service);
        
        //Act
        var actual = await controller.Create(creatingWarehouse);
        
        //Assert
        Assert.NotNull((actual.Result));

    }
    
   
    
    [Fact]
    public async Task TestUpdate()
    {
        
        //Arrange
        var warehouse = WarehouseMockData.GetWarehousePut();
        var warehouseaDto = WarehouseMockData.GetWarehouseDtoUpdated();
        this._repoMock.Setup(repo => repo.GetByWarehouseIdAsync(warehouse.WarehouseIdentifier.WarehouseIdentifier)).ReturnsAsync(warehouse);
        var _service = new WarehouseService(_unitOfWorkMock.Object, _repoMock.Object);
        var controller = new WarehousesController(_service);
        
        //Act
        var update = await controller.UpdateWarehouse("W01",warehouseaDto);
        
        //Assert
        Assert.NotNull(update);
        Assert.NotNull(update.Result);
       

    }
    
    
}



/*
using DDDNetCore.Controllers;
using DDDNetCore.Domain.Warehouses;
using DDDSample1.Controllers;
using DDDSample1.Domain.Delivery;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;
using Moq;

namespace testProject.Tests.Controller;

public class WarehouseControllerIntegrationTest
{
    [Fact]
    public async void GetAllTest()
    {
        var repo = new Mock<IWarehouseRepository>();
        var unit = new Mock<IUnitOfWork>();
        
        var driverServiceMock = new Mock<IWarehouseService>();
        string warehouseIdentifier = "33N";
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "3879-202";
        string country = "Porto Portugal";
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;

        var warehouse = new Warehouse(new WarehouseId(warehouseIdentifier), new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude));

        var warehouseDto = new WarehouseDTO(warehouse.Id.AsGuid(), warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude);
        
        var warehouseDtoList = new List<WarehouseDTO> { warehouseDto };
        var warehouseList = new List<Warehouse> { warehouse };

        var warehouseService = new WarehouseService(unit.Object, repo.Object);

        repo.Setup(_ => _.GetAllAsync()).ReturnsAsync(warehouseList);

        var controller = new WarehousesController(warehouseService);

        var actual = await controller.GetAll();
        
        Assert.Equal(warehouseDtoList.Count, actual.Value.Count());
    }

    [Fact]
    public async void CreateTest()
    {
        var repo = new Mock<IWarehouseRepository>();
        var unit = new Mock<IUnitOfWork>();

        var driverServiceMock = new Mock<IWarehouseService>();
        string warehouseIdentifier = "33N";
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "3879-202";
        string country = "Porto Portugal";
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;

        var warehouse = new Warehouse(new WarehouseId(warehouseIdentifier), new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude));

        var warehouseDto = new WarehouseDTO(warehouse.Id.AsGuid(), warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude);
        
        var warehouseDtoList = new List<WarehouseDTO> { warehouseDto };
        var warehouseList = new List<Warehouse> { warehouse };
        
        var warehouseService = new WarehouseService(unit.Object, repo.Object);

        repo.Setup(_ => _.GetAllAsync()).ReturnsAsync(warehouseList);

        var controller = new WarehousesController(warehouseService);
        
        var actual = await controller.Create(warehouseDto);
        
        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
    }
    
    [Fact]
    public async void GetByDeliveryIdTest()
    {
        var repo = new Mock<IWarehouseRepository>();
        var unit = new Mock<IUnitOfWork>();

        var driverServiceMock = new Mock<IWarehouseService>();
        string warehouseIdentifier = "33N";
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "3879-202";
        string country = "Porto Portugal";
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;

        var warehouse = new Warehouse(new WarehouseId(warehouseIdentifier), new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude));

        var warehouseDto = new WarehouseDTO(warehouse.Id.AsGuid(), warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude);
        
        var warehouseDtoList = new List<WarehouseDTO> { warehouseDto };
        var warehouseList = new List<Warehouse> { warehouse };
        
        var warehouseService = new WarehouseService(unit.Object, repo.Object);

        repo.Setup(_ => _.GetAllAsync()).ReturnsAsync(warehouseList);
        var controller = new WarehousesController(warehouseService);
        
        var actual = await controller.GetByWarehouseId(warehouseDto.WarehouseIdentifier);
        
        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
    }
    
    [Fact]
    public async void GetByDesignationIdTest()
    {
        var repo = new Mock<IWarehouseRepository>();
        var unit = new Mock<IUnitOfWork>();

        var driverServiceMock = new Mock<IWarehouseService>();
        string warehouseIdentifier = "33N";
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "3879-202";
        string country = "Porto Portugal";
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;

        var warehouse = new Warehouse(new WarehouseId(warehouseIdentifier), new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude));

        var warehouseDto = new WarehouseDTO(warehouse.Id.AsGuid(), warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude);
        
        var warehouseDtoList = new List<WarehouseDTO> { warehouseDto };
        var warehouseList = new List<Warehouse> { warehouse };
        
        var warehouseService = new WarehouseService(unit.Object, repo.Object);

        repo.Setup(_ => _.GetAllAsync()).ReturnsAsync(warehouseList);
        var controller = new WarehousesController(warehouseService);
        
        var actual = await controller.GetByDesignation(warehouseDto.Designation);
        
        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
    }
    
    [Fact]
    public async void GetByIdTest()
    {
        var repo = new Mock<IWarehouseRepository>();
        var unit = new Mock<IUnitOfWork>();

        var driverServiceMock = new Mock<IWarehouseService>();
        string warehouseIdentifier = "33N";
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "3879-202";
        string country = "Porto Portugal";
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;

        var warehouse = new Warehouse(new WarehouseId(warehouseIdentifier), new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude));

        var warehouseDto = new WarehouseDTO(warehouse.Id.AsGuid(), warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude);
        
        var warehouseDtoList = new List<WarehouseDTO> { warehouseDto };
        var warehouseList = new List<Warehouse> { warehouse };
        
        var warehouseService = new WarehouseService(unit.Object, repo.Object);

        repo.Setup(_ => _.GetAllAsync()).ReturnsAsync(warehouseList);
        var controller = new WarehousesController(warehouseService);
        
        var actual = await controller.GetById(warehouseDto.Id);
        
        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
    }
    
    [Fact]
    public async void UpdateTest()
    {
        var repo = new Mock<IWarehouseRepository>();
        var unit = new Mock<IUnitOfWork>();

        var driverServiceMock = new Mock<IWarehouseService>();
        string warehouseIdentifier = "33N";
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "3879-202";
        string country = "Porto Portugal";
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;

        var warehouse = new Warehouse(new WarehouseId(warehouseIdentifier), new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude));

        var warehouseDto = new WarehouseDTO(warehouse.Id.AsGuid(), warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude);
        
        var warehouseDtoList = new List<WarehouseDTO> { warehouseDto };
        var warehouseList = new List<Warehouse> { warehouse };
        
        var warehouseService = new WarehouseService(unit.Object, repo.Object);

        repo.Setup(_ => _.GetAllAsync()).ReturnsAsync(warehouseList);
        var controller = new WarehousesController(warehouseService);
        
        var actual = await controller.Update(warehouseDto.Id,warehouseDto);
        
        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
    }
    
    [Fact]
    public async void UpdateByWarehouseIdTest()
    {
        var repo = new Mock<IWarehouseRepository>();
        var unit = new Mock<IUnitOfWork>();

        var driverServiceMock = new Mock<IWarehouseService>();
        string warehouseIdentifier = "33N";
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "3879-202";
        string country = "Porto Portugal";
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;

        var warehouse = new Warehouse(new WarehouseId(warehouseIdentifier), new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude));

        var warehouseDto = new WarehouseDTO(warehouse.Id.AsGuid(), warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude);
        
        var warehouseDtoList = new List<WarehouseDTO> { warehouseDto };
        var warehouseList = new List<Warehouse> { warehouse };
        
        var warehouseService = new WarehouseService(unit.Object, repo.Object);

        repo.Setup(_ => _.GetAllAsync()).ReturnsAsync(warehouseList);
        var controller = new WarehousesController(warehouseService);
        
        var actual = await controller.UpdateWarehouseAsync(warehouseDto.WarehouseIdentifier,warehouseDto);
        
        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
    }

    [Fact]
    public async void SoftDeleteTest()
    {
        var repo = new Mock<IWarehouseRepository>();
        var unit = new Mock<IUnitOfWork>();

        var driverServiceMock = new Mock<IWarehouseService>();
        string warehouseIdentifier = "33N";
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "3879-202";
        string country = "Porto Portugal";
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;

        var warehouse = new Warehouse(new WarehouseId(warehouseIdentifier), new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude));

        var warehouseDto = new WarehouseDTO(warehouse.Id.AsGuid(), warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude);
        
        var warehouseDtoList = new List<WarehouseDTO> { warehouseDto };
        var warehouseList = new List<Warehouse> { warehouse };
        
        var warehouseService = new WarehouseService(unit.Object, repo.Object);

        repo.Setup(_ => _.GetAllAsync()).ReturnsAsync(warehouseList);
        var controller = new WarehousesController(warehouseService);
        
        var actual = await controller.SoftDelete(warehouseDto.Id);
        
        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
    }
    
    [Fact]
    public async void HardDeleteTest()
    {
        var repo = new Mock<IWarehouseRepository>();
        var unit = new Mock<IUnitOfWork>();

        var driverServiceMock = new Mock<IWarehouseService>();
        string warehouseIdentifier = "33N";
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "3879-202";
        string country = "Porto Portugal";
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;

        var warehouse = new Warehouse(new WarehouseId(warehouseIdentifier), new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude));

        var warehouseDto = new WarehouseDTO(warehouse.Id.AsGuid(), warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude);
        
        var warehouseDtoList = new List<WarehouseDTO> { warehouseDto };
        var warehouseList = new List<Warehouse> { warehouse };
        
        var warehouseService = new WarehouseService(unit.Object, repo.Object);

        repo.Setup(_ => _.GetAllAsync()).ReturnsAsync(warehouseList);
        var controller = new WarehousesController(warehouseService); 
        
        var actual = await controller.HardDelete(warehouseDto.Id);
        
        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
    }

}*/