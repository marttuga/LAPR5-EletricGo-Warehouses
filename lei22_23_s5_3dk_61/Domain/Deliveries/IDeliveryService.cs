using System.Collections.Generic;
using System.Threading.Tasks;


namespace DDDSample1.Domain.Deliveries
{

    public interface IDeliveryService
    {
        Task<List<DeliveryDto>> GetAllAsync();

        Task<DeliveryDto> GetByIdAsync(DeliveryId id);

        Task<DeliveryDto> GetByDeliveryIdentifierAsync(string identifier);
        
        Task<DeliveryDto> AddAsync(CreatingDeliveryDto dto);

        Task<DeliveryDto> UpdateAsync(DeliveryDto dto);

        Task<DeliveryDto> UpdateDeliveryAsync(DeliveryDto dto);

        Task<DeliveryDto> InactivateAsync(DeliveryId id);

        Task<DeliveryDto> DeleteAsync(DeliveryId id);


    }
}