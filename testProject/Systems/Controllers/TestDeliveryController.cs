using DDDSample1.Domain.Deliveries;
using DDDSample1.Controllers;
using Moq;
using Xunit.Abstractions;


namespace testProject {

    public class TestDeliveryController {

    private readonly ITestOutputHelper _output;

    public TestDeliveryController(ITestOutputHelper output)
        {
            _output = output;
        }
    

    [Fact]
	public async Task GetAllItemsAsync_ShouldReturnAllItemsAsync()
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


        CreatingDeliveryDto cDeliveryDto1 = new CreatingDeliveryDto(identifier1,date1,mass1,timeLoad1,timeUnload1, deliveryWarehouse1);
        CreatingDeliveryDto cDeliveryDto2 = new CreatingDeliveryDto(identifier2,date2,mass2,timeLoad2,timeUnload2, deliveryWarehouse2);
        
        Delivery delivery1 = new Delivery(identifier1, date1, mass1, timeLoad1, timeUnload1, deliveryWarehouse1);
        Delivery delivery2 = new Delivery(identifier2, date2, mass2, timeLoad2, timeUnload2, deliveryWarehouse2);
        
        DeliveryDto deliveryDto1 = new DeliveryDto{Id = delivery1.Id.AsGuid(), DIdentifier = identifier1, Date = date1, Mass = mass1,
	        TimeLoad = timeLoad1, TimeUnload = timeUnload1, DeliveryWarehouse=deliveryWarehouse1};
        DeliveryDto deliveryDto2 = new DeliveryDto{Id = delivery2.Id.AsGuid(), DIdentifier = identifier2, Date = date2, Mass = mass2,
	        TimeLoad = timeLoad2, TimeUnload = timeUnload2, DeliveryWarehouse=deliveryWarehouse2};
       

        List<DeliveryDto> listDeliveries = new List<DeliveryDto>();
        listDeliveries.Add(deliveryDto1);
        listDeliveries.Add(deliveryDto2);


		//Arrange
		var deliveryMockService = new Mock<IDeliveryService>();
		deliveryMockService.Setup(ser => ser.GetAllAsync()).ReturnsAsync(listDeliveries);
		
        var theController = new DeliveriesController(deliveryMockService.Object);

		//Act
		var result = await theController.GetAll();

		//Assert
		var items = Assert.IsType<List<DeliveryDto>>(result.Value);
		Assert.Equal(2, items.Count);
	}
	


    [Fact]
	public async Task GetItemByIdAsync_ShouldReturnTheRightItemAsync()
    {

        //Deliveries
        long date1 = 23112022;
        int mass1 = 4;
        int timeLoad1 = 2;
        int timeUnload1 = 5;
        string deliveryWarehouse1 = "W01";
        DeliveryIdentifier identifier1 = new DeliveryIdentifier("1245");


        CreatingDeliveryDto cDeliveryDto1 = new CreatingDeliveryDto(identifier1,date1,mass1,timeLoad1,timeUnload1, deliveryWarehouse1);

        Delivery delivery1 = new Delivery(identifier1, date1, mass1, timeLoad1, timeUnload1, deliveryWarehouse1);

        DeliveryDto deliveryDto1 = new DeliveryDto{Id = delivery1.Id.AsGuid(), DIdentifier = identifier1, Date = date1, Mass = mass1,
	        TimeLoad = timeLoad1, TimeUnload = timeUnload1, DeliveryWarehouse=deliveryWarehouse1};
        
		//Arrange
		var deliveryMockService = new Mock<IDeliveryService>();
		
		deliveryMockService.Setup(d => d.GetByDeliveryIdentifierAsync(It.IsAny<string>())).ReturnsAsync(deliveryDto1);

		var theController = new DeliveriesController(deliveryMockService.Object);

		//Act
		var result = await theController.GetGetByDeliveryIdentifier("1234");

		//Assert
		Assert.Equal(deliveryDto1, result.Value);
    }

	

    [Fact]
	public async Task UpdateItemByIdAsync_ShouldReturnTheRightItemUpdatedAsync()
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
		var deliveryMockService = new Mock<IDeliveryService>();
		deliveryMockService.Setup(t => t.UpdateDeliveryAsync(deliveryDto1)).ReturnsAsync(deliveryDto2);

		var theController = new DeliveriesController(deliveryMockService.Object);

		//Act
		var result = await theController.UpdateDelivery("1234",deliveryDto2);

		//Assert
		Assert.Equal(deliveryDto2,deliveryDto2);
	}
}


} 
