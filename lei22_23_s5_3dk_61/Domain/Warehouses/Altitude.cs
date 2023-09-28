using System;
using DDDSample1.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DDDSample1.Domain.Warehouses
{
    [Owned]
    public class Altitude : IValueObject
    {
        
        public string WarehouseAltitude { get; private set; }


        private Altitude()
        {         
        }

        public Altitude(string warehouseAltitude)
        {
            this.WarehouseAltitude = validateAltitude(warehouseAltitude);
        }

        private string validateAltitude(string warehouseAltitude){
            if(string.IsNullOrEmpty(warehouseAltitude))
                throw new ArgumentNullException("Altitude cannot be null nor empty!");
            float value;
            bool success = float.TryParse(warehouseAltitude, out value);
            if(!success)
                throw new FormatException("Altitude not acceptable!");
            if(value<0)
                throw new ArgumentOutOfRangeException("Altitude cannot be negative!");
            return warehouseAltitude;
        }
 
    }
}