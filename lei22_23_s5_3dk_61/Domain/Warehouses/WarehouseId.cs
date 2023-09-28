using System;
using DDDSample1.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DDDSample1.Domain.Warehouses
{

    [Owned]
    public class WarehouseId : IValueObject
    {
        [StringLength(3, MinimumLength=3,ErrorMessage="Id must have 3 characters!")]
        public string WarehouseIdentifier { get;  private set; }

        

        private WarehouseId()
        {         
        }

        public WarehouseId( string warehouseIdentifier)
        {
             this.WarehouseIdentifier = validateWarehouseId(warehouseIdentifier);
        
        }

        private string validateWarehouseId(string warehouseId){
            if(string.IsNullOrEmpty(warehouseId))
                throw new ArgumentNullException("ID cannot be null nor empty!");
            if(warehouseId.Length!=3)
                throw new BusinessRuleValidationException("Id must have 3 characters!");  
            return warehouseId;
        }
    }
}