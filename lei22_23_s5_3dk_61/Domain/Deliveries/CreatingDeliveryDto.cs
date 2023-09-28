using System;

namespace DDDSample1.Domain.Deliveries

{
    public class CreatingDeliveryDto
    {

        public DeliveryIdentifier DIdentifier{get; set;}

        public int Mass{ get;  set; }

        public long Date{ get; set; }

        public int TimeLoad{ get;  set; }

        public int TimeUnload{ get;  set; }

        public string DeliveryWarehouse {get;set;}


        public CreatingDeliveryDto(DeliveryIdentifier dIdentifier, long date, int mass, int timeLoad, int timeUnload, string deliveryWarehouse)
        {
            this.DIdentifier = dIdentifier;
            this.Date = date;
            this.Mass = mass;
            this.TimeLoad = timeLoad;
            this.TimeUnload = timeUnload;
            this.DeliveryWarehouse = deliveryWarehouse;
        }


    }
}