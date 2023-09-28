using DDDSample1.Domain.Deliveries;
using DDDSample1.Domain.Shared;
using Moq;


namespace testProject.Systems.Services;

public class DeliveryServiceTest
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
        
        const String identifier11 = "1234";

        long date2 = 31102022;
        int mass2 = 2;
        int timeLoad2 = 1;
        int timeUnload2 = 7;
        string deliveryWarehouse2 = "W02";
        DeliveryIdentifier identifier2 = new DeliveryIdentifier("1245");
        
        const String identifier22 = "1245";


        CreatingDeliveryDto cDeliveryDto1 = new CreatingDeliveryDto(identifier1,date1,mass1,timeLoad1,timeUnload1, deliveryWarehouse1);
        CreatingDeliveryDto cDeliveryDto2 = new CreatingDeliveryDto(identifier2,date2,mass2,timeLoad2,timeUnload2, deliveryWarehouse2);
        
        Delivery delivery1 = new Delivery(identifier1, date1, mass1, timeLoad1, timeUnload1, deliveryWarehouse1);
        Delivery delivery2 = new Delivery(identifier2, date2, mass2, timeLoad2, timeUnload2, deliveryWarehouse2);
        
        DeliveryDto deliveryDto1 = new DeliveryDto{Id = delivery1.Id.AsGuid(), DIdentifier = identifier1, Date = date1, Mass = mass1,
            TimeLoad = timeLoad1, TimeUnload = timeUnload1, DeliveryWarehouse=deliveryWarehouse1};
        DeliveryDto deliveryDto2 = new DeliveryDto{Id = delivery2.Id.AsGuid(), DIdentifier = identifier2, Date = date2, Mass = mass2,
            TimeLoad = timeLoad2, TimeUnload = timeUnload2, DeliveryWarehouse=deliveryWarehouse2};
       

        List<Delivery> listDeliveries = new List<Delivery>();
        listDeliveries.Add(delivery1);
        listDeliveries.Add(delivery2);

        
        this._repoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(listDeliveries);
        var _service = new DeliveryService(_unitOfWorkMock.Object, _repoMock.Object);
        var list = await _service.GetAllAsync();
       

        Assert.Equal(identifier11,list[0].DIdentifier.DIdentifier);
        Assert.Equal( identifier22,list[1].DIdentifier.DIdentifier);
        Assert.Equal(2,list.Count);
    }
    

    [Fact]
    public async Task TestGetByWarehouseIdAsync() 
    {
        //Deliveries
        long date1 = 23112022;
        int mass1 = 4;
        int timeLoad1 = 2;
        int timeUnload1 = 5;
        string deliveryWarehouse1 = "W01";
        DeliveryIdentifier identifier1 = new DeliveryIdentifier("1234");
        
        Delivery delivery1 = new Delivery(identifier1, date1, mass1, timeLoad1, timeUnload1, deliveryWarehouse1);

        
        this._repoMock.Setup(repo => repo.GetByDeliveryIdentifierAsync(delivery1.DIdentifier.DIdentifier)).ReturnsAsync(delivery1);
        var _service = new DeliveryService(_unitOfWorkMock.Object, _repoMock.Object);
        var get_delivery = await _service.GetByDeliveryIdentifierAsync(delivery1.DIdentifier.DIdentifier);

        Assert.Equal(delivery1.DIdentifier, get_delivery.DIdentifier);
    }

    [Fact]
    public async Task TestPostAsync()
    {
        //Deliveries
        long date1 = 23112022;
        int mass1 = 4;
        int timeLoad1 = 2;
        int timeUnload1 = 5;
        string deliveryWarehouse1 = "W01";
        DeliveryIdentifier identifier1 = new DeliveryIdentifier("1234");
        
        Delivery delivery1 = new Delivery(identifier1, date1, mass1, timeLoad1, timeUnload1, deliveryWarehouse1);
        
        this._repoMock.Setup(repo => repo.AddAsync(delivery1)).ReturnsAsync(delivery1);
        var _service = new DeliveryService(_unitOfWorkMock.Object, _repoMock.Object);
        var get_delivery = await _service.AddAsync(new CreatingDeliveryDto(delivery1.DIdentifier, delivery1.Date, delivery1.Mass,
            delivery1.TimeLoad, delivery1.TimeUnload, delivery1.DeliveryWarehouse));

        Assert.Equal(delivery1.DIdentifier,get_delivery.DIdentifier);

    }

    [Fact]
    public async Task TestPutAsync()
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

        
  
       

        //Arrange
        var delivery = new Delivery(identifier1, date1, mass1, timeLoad1, timeUnload1, deliveryWarehouse1);;
        var deliveryDto =  new DeliveryDto{Id = delivery.Id.AsGuid(), DIdentifier = identifier1, Date = date2, Mass = mass2,
            TimeLoad = timeLoad2, TimeUnload = timeUnload2, DeliveryWarehouse=deliveryWarehouse2};;
        this._repoMock.Setup(repo => repo.GetByDeliveryIdentifierAsync(delivery.DIdentifier.DIdentifier)).ReturnsAsync(delivery);
        var _service = new DeliveryService(_unitOfWorkMock.Object, _repoMock.Object);
        
        //Act
        var update = await _service.UpdateDeliveryAsync(deliveryDto);
        
        //Assert
        Assert.Equal(deliveryDto.DIdentifier.DIdentifier,update.DIdentifier.DIdentifier);
      
    }
}

