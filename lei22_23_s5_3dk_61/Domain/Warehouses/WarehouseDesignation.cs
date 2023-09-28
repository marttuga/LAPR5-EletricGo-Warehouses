using System;
using DDDSample1.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DDDSample1.Domain.Warehouses
{
    [Owned]
    public class WarehouseDesignation : IValueObject
    {
        [StringLength(50, ErrorMessage="Designation cannot have more than 50 characters in length.")]
        public string Designation { get; private set; }


        private WarehouseDesignation()
        {         
        }

        public WarehouseDesignation(string designation)
        {
            this.Designation = validateDesignation(designation);
        }

        private string validateDesignation(string designation){
            if(string.IsNullOrEmpty(designation))
                throw new ArgumentNullException("Designation cannot be null nor empty!");
            if(designation.Length > 50)
                throw new BusinessRuleValidationException("Designation cannot have more than 50 characters in length!");
            return designation;
        }

    }
}