using DDDSample1.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Domain.Warehouses
{
    [Owned]
    public class Coordinate : IValueObject
    {

        public float Latitude { get;  private set; }

        public float Longitude { get;  private set; }

        
        private Coordinate()
        {         
        }

        public Coordinate( float latitude, float longitude)
        {
        this.Latitude = latitude;
        this.Longitude = longitude;
        }

        
    }
}