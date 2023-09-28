using System;

namespace DDDSample1.Domain.Warehouses
{
    public class WarehouseDto
    {
        public Guid Id { get; set; }

        public string WarehouseIdentifier { get; set; }

        public string Designation { get; set; }
        
        public float Latitude { get; set; }
        
        public float Longitude { get; set; }

        public string Street { get; set; }

        public int DoorNumber { get; set; }
        
        public string City { get; set; }
        
        public string ZipCode { get; set; }
        public string  WarehouseAltitude { get; set; }
        
        public bool  Status { get; set; }

       
    }
}