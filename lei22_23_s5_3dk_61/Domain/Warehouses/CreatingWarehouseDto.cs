namespace DDDSample1.Domain.Warehouses
{
    public class CreatingWarehouseDto
    {

        public string WarehouseIdentifier { get; set; }

        public string Designation { get; set; }
        
        public float Latitude { get; set; }
        
        public float Longitude { get; set; }

        public string Street { get; set; }

        public int DoorNumber { get; set; }
        
        public string City { get; set; }
        
        public string ZipCode { get; set; }
        public string  WarehouseAltitude { get; set; }


        public CreatingWarehouseDto(string warehouseIdentifier,string designation, float latitude, float longitude, string street, int doorNumber, string city, string zipCode,string warehouseAltitude)
        {
            this.WarehouseIdentifier = warehouseIdentifier;
            this.Designation = designation;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Street = street;
            this.DoorNumber = doorNumber;
            this.City = city;
            this.ZipCode = zipCode;
            this.WarehouseAltitude = warehouseAltitude;
        }
    }
}
