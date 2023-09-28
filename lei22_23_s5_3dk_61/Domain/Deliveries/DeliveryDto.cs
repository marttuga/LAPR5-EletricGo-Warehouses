using System;

namespace DDDSample1.Domain.Deliveries
{
    public class DeliveryDto
    {
        public Guid Id { get; set; }

        public DeliveryIdentifier DIdentifier {get; set;}
        public long Date  { get; set; }

        public int Mass { get;  set; }

         public int TimeLoad { get;  set; }

         public int TimeUnload { get; set; }

         public string DeliveryWarehouse {get; set;}

        
    }
}