using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Deliveries
{
    public class Delivery : Entity<DeliveryId>, IAggregateRoot
    {
     
        [Required]
        public DeliveryIdentifier DIdentifier {  get; private set; }

        public long Date { get;  private set; }

        public int Mass { get;  private set; }

         public int TimeLoad { get;  private set; }

         public int TimeUnload { get;  private set; }

         public string DeliveryWarehouse { get; private set; }
         
         public bool Active{ get;  private set; }

         public Delivery()
        {
            this.Active=true;
        }

        public Delivery(DeliveryIdentifier dIdentifier,long date, int mass, int timeLoad, int timeUnload, string deliveryWarehouse)
        {
            if (dIdentifier == null)
            {
                throw new BusinessRuleValidationException("Identifier cannot be null nor empty!");
            }

            if (deliveryWarehouse == null)
            {
                    throw new BusinessRuleValidationException("Warehouse Id cannot be null nor empty!");
            
            }

            this.Id = new DeliveryId(Guid.NewGuid());
            this.DIdentifier = dIdentifier;
            this.Date = date;
            this.Mass = mass;
            this.TimeLoad = timeLoad;
            this.TimeUnload = timeUnload;
            this.DeliveryWarehouse = deliveryWarehouse;
            this.Active=true;
    
        }

        public void MarkAsInative()
        {
            this.Active = false;
        }

        public void ChangeDate(long date)
    {
        this.Date = date;
    }


    public void ChangeMass(int mass)
    {
        this.Mass = mass;
    }

     public void ChangeTimeLoad(int timeLoad)
    {
        this.TimeLoad = timeLoad;
    }

     public void ChangeTimeUnload(int timeUnload)
    {
        this.TimeUnload = timeUnload;
    }


    }
}
