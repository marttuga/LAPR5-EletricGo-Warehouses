using DDDSample1.Controllers;
using DDDSample1.Domain.Deliveries;
using DDDSample1.Domain.Shared;

using Moq;
using testProject.MockData;

namespace testProject.Integration;

public class DeliveryControllerServiceTest
{
    private Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
    private Mock<IDeliveryRepository> _repoMock = new Mock<IDeliveryRepository>();


    [Fact]
    public async Task TestGetAllAsync()
    {
        
        //Deliveries
        long date1 = 23112022;
        int mass1 = 4;
        int timeLoad1 = 2;
        int timeUnload1 = 5;
        string deliveryWarehouse1 = "W01";
        DeliveryIdentifier identifier1 = new DeliveryIdentifier("1234");

        long date2 = 31102022;
        int mass2 = 2;
        int timeLoad2 = 1;
        int timeUnload2 = 7;
        string deliveryWarehouse2 = "W02";
        DeliveryIdentifier identifier2 = new DeliveryIdentifier("1245");


    
        Delivery delivery1 = new Delivery(identifier1, date1, mass1, timeLoad1, timeUnload1, deliveryWarehouse1);
        Delivery delivery2 = new Delivery(identifier2, date2, mass2, timeLoad2, timeUnload2, deliveryWarehouse2);
        
          
        DeliveryDto deliveryDto1 = new DeliveryDto{Id = delivery1.Id.AsGuid(), DIdentifier = identifier1, Date = date1, Mass = mass1,
            TimeLoad = timeLoad1, TimeUnload = timeUnload1, DeliveryWarehouse=deliveryWarehouse1};
        DeliveryDto deliveryDto2 = new DeliveryDto{Id = delivery2.Id.AsGuid(), DIdentifier = identifier2, Date = date2, Mass = mass2,
            TimeLoad = timeLoad2, TimeUnload = timeUnload2, DeliveryWarehouse=deliveryWarehouse2};
       

        List<DeliveryDto> listDeliveriesDto = new List<DeliveryDto>();
        listDeliveriesDto.Add(deliveryDto1);
        listDeliveriesDto.Add(deliveryDto2);
    
        List<Delivery> listDeliveries = new List<Delivery>();
        listDeliveries.Add(delivery1);
        listDeliveries.Add(delivery2);

        //Arrange
        var deliveryList = listDeliveries;
        var deliverylistDto = listDeliveriesDto;
        this._repoMock.Setup(_ => _.GetAllAsync()).ReturnsAsync(deliveryList);
        var deliveryService = new DeliveryService(_unitOfWorkMock.Object, _repoMock.Object);
        var controller = new DeliveriesController(deliveryService);
        
        //Act
        var actual = await controller.GetAll();

        //Assert
        Assert.Equal(deliverylistDto.Count, actual.Value.Count());

    }
    
    [Fact]
    public async Task TestGetByDeliveryIdentifierAsync()
    {
        
        //Deliveries
        long date1 = 23112022;
        long date2 = 24122022;
        int mass1 = 4;
        int timeLoad1 = 2;
        int timeUnload1 = 5;
        string deliveryWarehouse1 = "W01";
        DeliveryIdentifier identifier1 = new DeliveryIdentifier("1234");


        CreatingDeliveryDto cDeliveryDto1 = new CreatingDeliveryDto(identifier1,date1,mass1,timeLoad1,timeUnload1, deliveryWarehouse1);

        Delivery delivery1 = new Delivery(identifier1, date1, mass1, timeLoad1, timeUnload1, deliveryWarehouse1);
        //Arrange
        string deliveryIdentifier = "1234";
        var delivery = delivery1;
        this._repoMock.Setup(repo => repo.GetByDeliveryIdentifierAsync(delivery.DIdentifier.DIdentifier)).ReturnsAsync(delivery);
        var deliveryService = new DeliveryService(_unitOfWorkMock.Object, _repoMock.Object);
        var controller = new DeliveriesController(deliveryService);
        
        //ACT
        var actual = await controller.GetGetByDeliveryIdentifier(deliveryIdentifier);

        //Assert
        Assert.Equal(deliveryIdentifier, actual.Value.DIdentifier.DIdentifier);
        
    }
    
    [Fact]
    public async Task TestCreate()
    {
        
        //Deliveries
        long date1 = 23112022;
        long date2 = 24122022;
        int mass1 = 4;
        int timeLoad1 = 2;
        int timeUnload1 = 5;
        string deliveryWarehouse1 = "W01";
        DeliveryIdentifier identifier1 = new DeliveryIdentifier("1234");


        CreatingDeliveryDto cDeliveryDto1 = new CreatingDeliveryDto(identifier1,date1,mass1,timeLoad1,timeUnload1, deliveryWarehouse1);

        Delivery delivery1 = new Delivery(identifier1, date1, mass1, timeLoad1, timeUnload1, deliveryWarehouse1);
        //Arrange
        var delivery = delivery1;
        var creatingDelivery = cDeliveryDto1;
        this._repoMock.Setup(repo => repo.AddAsync(delivery)).ReturnsAsync(delivery);
        var _service = new DeliveryService(_unitOfWorkMock.Object, _repoMock.Object);
        var controller = new DeliveriesController(_service);
        
        //Act
        var actual = await controller.Create(creatingDelivery);
        
        //Assert
        Assert.NotNull((actual.Result));

    }
    
   
    
    [Fact]
    public async Task TestUpdate()
    {
        
        //Deliveries
        long date1 = 23112022;
        long date2 = 24122022;
        int mass1 = 4;
        int timeLoad1 = 2;
        int timeUnload1 = 5;
        string deliveryWarehouse1 = "W01";
        DeliveryIdentifier identifier1 = new DeliveryIdentifier("1234");


        CreatingDeliveryDto cDeliveryDto1 = new CreatingDeliveryDto(identifier1,date1,mass1,timeLoad1,timeUnload1, deliveryWarehouse1);

        Delivery delivery1 = new Delivery(identifier1, date1, mass1, timeLoad1, timeUnload1, deliveryWarehouse1);
        Delivery delivery2 = new Delivery(identifier1, date2, mass1, timeLoad1, timeUnload1, deliveryWarehouse1);

        DeliveryDto deliveryDto1 = new DeliveryDto{Id = delivery1.Id.AsGuid(), DIdentifier = identifier1, Date = date1, Mass = mass1,
            TimeLoad = timeLoad1, TimeUnload = timeUnload1, DeliveryWarehouse=deliveryWarehouse1};
        DeliveryDto deliveryDto2 = new DeliveryDto{Id = delivery1.Id.AsGuid(), DIdentifier = identifier1, Date = date2, Mass = mass1,
            TimeLoad = timeLoad1, TimeUnload = timeUnload1, DeliveryWarehouse=deliveryWarehouse1};
        
        //Arrange
        
        //Arrange
        var delivery = delivery2;
        var deliveryDto = deliveryDto2;
        this._repoMock.Setup(repo => repo.GetByDeliveryIdentifierAsync(delivery.DIdentifier.DIdentifier)).ReturnsAsync(delivery);
        var _service = new DeliveryService(_unitOfWorkMock.Object, _repoMock.Object);
        var controller = new DeliveriesController(_service);
        
        //Act
        var update = await controller.UpdateDelivery("1234",deliveryDto);
        
        //Assert
        Assert.NotNull(update);
        Assert.NotNull(update.Result);
       

    }
    
}