using DDDSample1.Domain.Warehouses;

namespace testProject.MockData;

public class WarehouseMockData
{
    public static List<Warehouse> GetWarehousesList()
    {
        return new List<Warehouse>
        {
            new Warehouse(new WarehouseId("W07"),
                new WarehouseDesignation("Cascais Warehouse"),
                new Coordinate(34, 58),
                new Address("Rua Luís de Camões", 12, "Cascais", "1060-673"), 
                new Altitude("245")),
            new Warehouse(new WarehouseId("W08"),
                new WarehouseDesignation("Cascais Warehouse"),
                new Coordinate(34, 58),
                new Address("Rua Luís de Camões", 12, "Cascais", "1060-673"), 
                new Altitude("245"))
            
        };
    }
    
    public static List<WarehouseDto> GetWarehousesDtoList()
    {
        return new List<WarehouseDto>
        {
            new WarehouseDto
            {
                Id = new Guid(),
                WarehouseIdentifier = "W07",
                Designation = "Cascais Warehouse",
                Latitude=34,
                Longitude = 58,
                Street = "Rua Luís de Camões",
                DoorNumber = 12, 
                City="Cascais", 
                ZipCode ="1060-673",
                WarehouseAltitude = "245"

            },
            new WarehouseDto
            {
            Id = new Guid(),
            WarehouseIdentifier = "W13",
            Designation = "Cascais Warehouse",
            Latitude=34,
            Longitude = 58,
            Street = "Rua Luís de Camões",
            DoorNumber = 12, 
            City="Cascais", 
            ZipCode ="1060-673",
            WarehouseAltitude = "245"
            }
        

        };
    }
    
    public static WarehouseDto GetWarehouseDto()
    {
        return new WarehouseDto
        {
                Id = new Guid(),
                WarehouseIdentifier ="W01",
                Designation = "Porto Storage Center",
                Latitude = (float)41.15,
                Longitude = (float)-8.61024,
                Street = "Rua do Carmo",
                DoorNumber = 269, 
                City = "Porto", 
                ZipCode = "4050-157", 
                WarehouseAltitude = "200"

            

        };
    }
    
    public static CreatingWarehouseDto GetCreatingWarehouseDto()
    {
        return new CreatingWarehouseDto("W05",
            "Porto Storage Center",
            (float)41.15, (float)-8.61024,
            "Rua do Carmo", 269, "Porto", "4050-157", 
         "200");
    }
    
    public static CreatingWarehouseDto GetCreatingWarehouseDtoIntegration()
    {
        return new CreatingWarehouseDto("W10", "Porto Storage Center",
            (float)41.15, (float)-8.61024,
            "Rua do Carmo", 269, "Porto", "4050-157", 
            "200");
    }
    
    public static WarehouseDto GetWarehouseDtoUpdated()
    {
        return new WarehouseDto
        {
            Id = new Guid(),
            WarehouseIdentifier = "W01",
            Designation = "Paredes Storage Center",
            Latitude=(float)42.15, 
            Longitude =(float)-6.61024,
            Street="Rua do Cemitério",
            DoorNumber=300, 
            City="Paredes",
            ZipCode="4580-167",
            WarehouseAltitude ="189"

            

        };
    }
    
    public static Warehouse GetWarehouse()
    {
        return new Warehouse
        (new WarehouseId("W10"), new WarehouseDesignation("Porto Storage Center"),
            new Coordinate((float)41.15, (float)-8.61024),
            new Address("Rua do Carmo", 269, "Porto", "4050-157"),
            new Altitude("200"));
    }
    
    public static Warehouse GetWarehousePut()
    {
        return new Warehouse
        (new WarehouseId("W01"), new WarehouseDesignation("Porto Storage Center"),
            new Coordinate((float)41.15, (float)-8.61024),
            new Address("Rua do Carmo", 269, "Porto", "4050-157"),
            new Altitude("200"));
    }
}