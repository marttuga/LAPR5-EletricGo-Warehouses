using DDDSample1.Domain.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Warehouses;

namespace DDDSample1.Domain.Warehouses
{
    public interface IWarehouseRepository : IRepository<Warehouse,Identifier>
    {
        Task<Warehouse> GetByWarehouseIdAsync(string WarehouseId);

        Task<Warehouse> GetByDesignationAsync(string Designation);
        Task<List<WarehouseDto>> GetByWarehouseIdsAsync(List<WarehouseDto> ids);
       
        
    }
}