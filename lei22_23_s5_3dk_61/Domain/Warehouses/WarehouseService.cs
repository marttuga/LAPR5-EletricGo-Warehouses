using System.Threading.Tasks;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Warehouses
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWarehouseRepository _repo;



        public WarehouseService(IUnitOfWork unitOfWork, IWarehouseRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }

        public async Task<List<WarehouseDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            
            List<WarehouseDto> listDto = list.ConvertAll(wh => new WarehouseDto{ Id=wh.Id.AsGuid(),WarehouseIdentifier = wh.WarehouseIdentifier.WarehouseIdentifier ,Designation = wh.Designation.Designation, Latitude = wh.Coordinates.Latitude, Longitude = wh.Coordinates.Longitude, Street = wh.Address.Street, DoorNumber = wh.Address.DoorNumber, City = wh.Address.City, ZipCode = wh.Address.ZipCode, WarehouseAltitude = wh.WarehouseAltitude.WarehouseAltitude, Status = wh.Active});

            return listDto;
        }

        public async Task<WarehouseDto> GetByIdAsync(Identifier id)
        {
            var warehouse = await this._repo.GetByIdAsync(id);
            
            if(warehouse == null)
                return null;

            return new WarehouseDto{Id = warehouse.Id.AsGuid(),WarehouseIdentifier = warehouse.WarehouseIdentifier.WarehouseIdentifier , Designation = warehouse.Designation.Designation, Latitude = warehouse.Coordinates.Latitude, Longitude = warehouse.Coordinates.Longitude, Street = warehouse.Address.Street, DoorNumber = warehouse.Address.DoorNumber, City = warehouse.Address.City, ZipCode = warehouse.Address.ZipCode, WarehouseAltitude = warehouse.WarehouseAltitude.WarehouseAltitude};
        }

        public async Task<WarehouseDto> GetByWarehouseIdAsync(string warehouseIdentifier)
        {
            var warehouse = await this._repo.GetByWarehouseIdAsync(warehouseIdentifier);
            
            if(warehouse == null)
                return null;

            return new WarehouseDto{Id = warehouse.Id.AsGuid(),WarehouseIdentifier = warehouse.WarehouseIdentifier.WarehouseIdentifier , Designation = warehouse.Designation.Designation, Latitude = warehouse.Coordinates.Latitude, Longitude = warehouse.Coordinates.Longitude, Street = warehouse.Address.Street, DoorNumber = warehouse.Address.DoorNumber, City = warehouse.Address.City, ZipCode = warehouse.Address.ZipCode, WarehouseAltitude = warehouse.WarehouseAltitude.WarehouseAltitude};
        }

        public async Task<WarehouseDto> GetByDesignationAsync(string designation)
        {
            var warehouse = await this._repo.GetByDesignationAsync(designation);
            
            if(warehouse == null)
                return null;

            return new WarehouseDto{Id = warehouse.Id.AsGuid(),WarehouseIdentifier = warehouse.WarehouseIdentifier.WarehouseIdentifier , Designation = warehouse.Designation.Designation, Latitude = warehouse.Coordinates.Latitude, Longitude = warehouse.Coordinates.Longitude, Street = warehouse.Address.Street, DoorNumber = warehouse.Address.DoorNumber, City = warehouse.Address.City, ZipCode = warehouse.Address.ZipCode, WarehouseAltitude = warehouse.WarehouseAltitude.WarehouseAltitude};
        }

        public async Task<WarehouseDto> AddAsync(CreatingWarehouseDto dto)
        {
            var warehouse = new Warehouse(new WarehouseId(dto.WarehouseIdentifier),new WarehouseDesignation(dto.Designation),new Coordinate(dto.Latitude,dto.Longitude),new Address(dto.Street, dto.DoorNumber,dto.City,dto.ZipCode),new Altitude(dto.WarehouseAltitude));

            await this._repo.AddAsync(warehouse);

            await this._unitOfWork.CommitAsync();

            return new WarehouseDto{Id = warehouse.Id.AsGuid(),WarehouseIdentifier = warehouse.WarehouseIdentifier.WarehouseIdentifier , Designation = warehouse.Designation.Designation, Latitude = warehouse.Coordinates.Latitude, Longitude = warehouse.Coordinates.Longitude, Street = warehouse.Address.Street, DoorNumber = warehouse.Address.DoorNumber, City = warehouse.Address.City, ZipCode = warehouse.Address.ZipCode, WarehouseAltitude = warehouse.WarehouseAltitude.WarehouseAltitude};
        }

        public async Task<WarehouseDto> UpdateAsync(WarehouseDto dto)
        {
            var warehouse = await this._repo.GetByWarehouseIdAsync(dto.WarehouseIdentifier); 

            if (warehouse == null)
                return null;   

            // change all fields
            warehouse.ChangeDesignation(new WarehouseDesignation(dto.Designation));
            warehouse.ChangeCoordinates(new Coordinate(dto.Latitude,dto.Longitude));
            warehouse.ChangeAddress(new Address(dto.Street,dto.DoorNumber,dto.City,dto.ZipCode));
            warehouse.ChangeAltitude(new Altitude(dto.WarehouseAltitude));
            
            await this._unitOfWork.CommitAsync();

            return new WarehouseDto{Id = warehouse.Id.AsGuid(),WarehouseIdentifier = warehouse.WarehouseIdentifier.WarehouseIdentifier , Designation = warehouse.Designation.Designation, Latitude = warehouse.Coordinates.Latitude, Longitude = warehouse.Coordinates.Longitude, Street = warehouse.Address.Street, DoorNumber = warehouse.Address.DoorNumber, City = warehouse.Address.City, ZipCode = warehouse.Address.ZipCode, WarehouseAltitude = warehouse.WarehouseAltitude.WarehouseAltitude};
        }

        public async Task<WarehouseDto> UpdateWarehouseAsync(WarehouseDto dto)
        {
            var warehouse = await this._repo.GetByWarehouseIdAsync(dto.WarehouseIdentifier); 

            if (warehouse == null)
                return null;   

            // change all fields
            warehouse.ChangeDesignation(new WarehouseDesignation(dto.Designation));
            warehouse.ChangeCoordinates(new Coordinate(dto.Latitude,dto.Longitude));
            warehouse.ChangeAddress(new Address(dto.Street,dto.DoorNumber,dto.City,dto.ZipCode));
            warehouse.ChangeAltitude(new Altitude(dto.WarehouseAltitude));
            
            await this._unitOfWork.CommitAsync();

            return new WarehouseDto{Id = warehouse.Id.AsGuid(),WarehouseIdentifier = warehouse.WarehouseIdentifier.WarehouseIdentifier , Designation = warehouse.Designation.Designation, Latitude = warehouse.Coordinates.Latitude, Longitude = warehouse.Coordinates.Longitude, Street = warehouse.Address.Street, DoorNumber = warehouse.Address.DoorNumber, City = warehouse.Address.City, ZipCode = warehouse.Address.ZipCode, WarehouseAltitude = warehouse.WarehouseAltitude.WarehouseAltitude};
        }






        public async Task<WarehouseDto> InactivateAsync(string id)
        {
            var warehouse = await this._repo.GetByWarehouseIdAsync(id); 

            if (warehouse == null)
                return null;   

            warehouse.MarkAsInative();
            
            await this._unitOfWork.CommitAsync();

            return new WarehouseDto{Id = warehouse.Id.AsGuid(),WarehouseIdentifier = warehouse.WarehouseIdentifier.WarehouseIdentifier , Designation = warehouse.Designation.Designation, Latitude = warehouse.Coordinates.Latitude, Longitude = warehouse.Coordinates.Longitude, Street = warehouse.Address.Street, DoorNumber = warehouse.Address.DoorNumber, City = warehouse.Address.City, ZipCode = warehouse.Address.ZipCode, WarehouseAltitude = warehouse.WarehouseAltitude.WarehouseAltitude};
        }

          public async Task<WarehouseDto> ActivateAsync(string warehouseIdentifier)
          {
              var warehouse = await this._repo.GetByWarehouseIdAsync(warehouseIdentifier); 

              if (warehouse == null)
                  return null;   
            
              warehouse.MarkAsActive();
            
              await this._unitOfWork.CommitAsync();

              return new WarehouseDto{Id = warehouse.Id.AsGuid(),WarehouseIdentifier = warehouse.WarehouseIdentifier.WarehouseIdentifier , Designation = warehouse.Designation.Designation, Latitude = warehouse.Coordinates.Latitude, Longitude = warehouse.Coordinates.Longitude, Street = warehouse.Address.Street, DoorNumber = warehouse.Address.DoorNumber, City = warehouse.Address.City, ZipCode = warehouse.Address.ZipCode, WarehouseAltitude = warehouse.WarehouseAltitude.WarehouseAltitude};
          }

          public async Task<WarehouseDto> DeleteAsync(Identifier id)
        {
            var warehouse = await this._repo.GetByIdAsync(id); 

            if (warehouse == null)
                return null;   

            this._repo.Remove(warehouse);
            await this._unitOfWork.CommitAsync();

            return new WarehouseDto{Id = warehouse.Id.AsGuid(),WarehouseIdentifier = warehouse.WarehouseIdentifier.WarehouseIdentifier , Designation = warehouse.Designation.Designation, Latitude = warehouse.Coordinates.Latitude, Longitude = warehouse.Coordinates.Longitude, Street = warehouse.Address.Street, DoorNumber = warehouse.Address.DoorNumber, City = warehouse.Address.City, ZipCode = warehouse.Address.ZipCode, WarehouseAltitude = warehouse.WarehouseAltitude.WarehouseAltitude};
        }


    }
}