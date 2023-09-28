using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDDSample1.Domain.Warehouses
{

    public interface IWarehouseService
    {
        Task<List<WarehouseDto>> GetAllAsync();

        Task<WarehouseDto> GetByIdAsync(Identifier id);

        Task<WarehouseDto> GetByWarehouseIdAsync(string warehouseIdentifier);

        Task<WarehouseDto> GetByDesignationAsync(string designation);

        Task<WarehouseDto> AddAsync(CreatingWarehouseDto dto);

        Task<WarehouseDto> UpdateAsync(WarehouseDto dto);

        Task<WarehouseDto> UpdateWarehouseAsync(WarehouseDto dto);
        

        Task<WarehouseDto> InactivateAsync(string warehouseIdentifier);
        
        Task<WarehouseDto> ActivateAsync(string warehouseIdentifier);


        Task<WarehouseDto> DeleteAsync(Identifier id);


    }
}