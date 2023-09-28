using System;
using DDDSample1.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DDDSample1.Domain.Deliveries
{
    [Owned]
    public class DeliveryIdentifier: IValueObject
    {

        public string DIdentifier { get;  private set; }



        private DeliveryIdentifier()
        {         
        }

        public DeliveryIdentifier(string dIdentifier)
        {
        this.DIdentifier = dIdentifier;
        }

        private string validateDeliveryIdentifier(string dIdentifier){
            if(string.IsNullOrEmpty(dIdentifier))
                throw new ArgumentNullException("ID cannot be null nor empty!");
           return dIdentifier;
        }
    }
}