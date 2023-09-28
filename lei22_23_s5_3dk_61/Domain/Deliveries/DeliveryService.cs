using System.Threading.Tasks;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Deliveries
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDeliveryRepository _repo;

        public DeliveryService(IUnitOfWork unitOfWork, IDeliveryRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }

        public async Task<List<DeliveryDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            
            List<DeliveryDto> listDto = list.ConvertAll<DeliveryDto>(del => new DeliveryDto {Id = del.Id.AsGuid(), DIdentifier = del.DIdentifier, Date = del.Date, Mass = del.Mass,
            TimeLoad = del.TimeLoad,TimeUnload = del.TimeUnload, DeliveryWarehouse = del.DeliveryWarehouse});

            return listDto;
        }

        public async Task<DeliveryDto> GetByIdAsync(DeliveryId id)
        {
            var del = await this._repo.GetByIdAsync(id);
            
            if(del == null)
                return null;

            return new DeliveryDto {Id=del.Id.AsGuid(),DIdentifier = del.DIdentifier, Date=del.Date,Mass=del.Mass,
            TimeLoad=del.TimeLoad,TimeUnload=del.TimeUnload, DeliveryWarehouse = del.DeliveryWarehouse};

        }

        public async Task<DeliveryDto> GetByDeliveryIdentifierAsync(string identifier)
        {
            var del = await this._repo.GetByDeliveryIdentifierAsync(identifier);
            
            if(del == null)
                return null;

            return new DeliveryDto {Id=del.Id.AsGuid(),DIdentifier = del.DIdentifier, Date=del.Date,Mass=del.Mass,
            TimeLoad=del.TimeLoad,TimeUnload=del.TimeUnload, DeliveryWarehouse = del.DeliveryWarehouse};

        }

        public async Task<DeliveryDto> AddAsync(CreatingDeliveryDto dto)
        {
            var del = new Delivery(dto.DIdentifier,dto.Date, dto.Mass, dto.TimeLoad, dto.TimeUnload, dto.DeliveryWarehouse);

            await this._repo.AddAsync(del);

            await this._unitOfWork.CommitAsync();

            return new DeliveryDto {Id=del.Id.AsGuid(),DIdentifier = del.DIdentifier, Date=del.Date,Mass=del.Mass,
            TimeLoad=del.TimeLoad,TimeUnload=del.TimeUnload, DeliveryWarehouse = del.DeliveryWarehouse };
        }

        public async Task<DeliveryDto> UpdateAsync(DeliveryDto dto)
        {
            var del = await this._repo.GetByIdAsync(new DeliveryId(dto.Id)); 

            if (del == null)
                return null;   

            // change all field
            del.ChangeDate(dto.Date);
            del.ChangeMass(dto.Mass);
            del.ChangeTimeLoad(dto.TimeLoad);
            del.ChangeTimeUnload(dto.TimeUnload);
            
            await this._unitOfWork.CommitAsync();

            return new DeliveryDto{Id=del.Id.AsGuid(), DIdentifier = del.DIdentifier, Date=del.Date,Mass=del.Mass,
            TimeLoad=del.TimeLoad,TimeUnload=del.TimeUnload, DeliveryWarehouse=del.DeliveryWarehouse};
        }


        public async Task<DeliveryDto> UpdateDeliveryAsync(DeliveryDto dto)
        {
            
            var del = await this._repo.GetByDeliveryIdentifierAsync(dto.DIdentifier.DIdentifier); 

            if (del == null)
                return null;   

            // change all field
            del.ChangeDate(dto.Date);
            del.ChangeMass(dto.Mass);
            del.ChangeTimeLoad(dto.TimeLoad);
            del.ChangeTimeUnload(dto.TimeUnload);
            
            await this._unitOfWork.CommitAsync();

            return new DeliveryDto{Id=del.Id.AsGuid(), DIdentifier = del.DIdentifier, Date=del.Date,Mass=del.Mass,
            TimeLoad=del.TimeLoad,TimeUnload=del.TimeUnload, DeliveryWarehouse=del.DeliveryWarehouse};
            }
       
        public async Task<DeliveryDto> InactivateAsync(DeliveryId id)
        {
            var del = await this._repo.GetByIdAsync(id); 

            if (del == null)
                return null;   

            // change all fields
            del.MarkAsInative();
            
            await this._unitOfWork.CommitAsync();

            return new DeliveryDto{Id=del.Id.AsGuid(), DIdentifier = del.DIdentifier, Date=del.Date,Mass=del.Mass,
            TimeLoad=del.TimeLoad,TimeUnload=del.TimeUnload, DeliveryWarehouse=del.DeliveryWarehouse};
        }

         public async Task<DeliveryDto> DeleteAsync(DeliveryId id)
        {
            var del = await this._repo.GetByIdAsync(id); 

            if (del == null)
                return null;   

        
            this._repo.Remove(del);
            await this._unitOfWork.CommitAsync();

            return new DeliveryDto {Id=del.Id.AsGuid(), DIdentifier = del.DIdentifier, Date=del.Date,Mass=del.Mass,
            TimeLoad=del.TimeLoad,TimeUnload=del.TimeUnload, DeliveryWarehouse=del.DeliveryWarehouse };
        }
    }
}