using DDDSample1.Domain.Deliveries;
using DDDSample1.Infrastructure.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Infrastructure.Deliveries
{
    public class DeliveryRepository : BaseRepository<Delivery, DeliveryId>, IDeliveryRepository
    {
    private readonly DDDSample1DbContext _context;
    public DeliveryRepository(DDDSample1DbContext context):base(context.Deliveries)
    {
         _context=context;
    }

    public async Task<Delivery> GetByDeliveryIdentifierAsync(string dIdentifier){
            return await _context.Deliveries.Where(x => dIdentifier.Equals(x.DIdentifier.DIdentifier)
            && x.Active).FirstOrDefaultAsync();
    }

    public Task<List<DeliveryDto>> GetByDeliveryIdentifiersAsync(List<DeliveryDto> ids ){
            throw new System.NotImplementedException();

    }


    }
}