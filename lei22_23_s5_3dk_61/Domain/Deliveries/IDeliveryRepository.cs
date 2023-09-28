
using DDDSample1.Domain.Shared;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DDDSample1.Domain.Deliveries
{
    public interface IDeliveryRepository: IRepository<Delivery, DeliveryId>
    {

        Task<Delivery> GetByDeliveryIdentifierAsync(string Identifier);
        Task<List<DeliveryDto>> GetByDeliveryIdentifiersAsync(List<DeliveryDto> ids);

    

    }
}