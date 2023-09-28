using DDDSample1.Domain.Warehouses;
using DDDSample1.Infrastructure.Shared;
using DDDSample1.Domain.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Infrastructure.Warehouses
{
    public class WarehouseRepository : BaseRepository<Warehouse, Identifier>,IWarehouseRepository
    {
        private readonly DDDSample1DbContext _context;
        public WarehouseRepository(DDDSample1DbContext context):base(context.Warehouses)
        {
            _context=context;
        }

        public async Task<Warehouse> GetByWarehouseIdAsync(string warehouseIdentifier){
            
            return await _context.Warehouses.Where(x => warehouseIdentifier.Equals(x.WarehouseIdentifier.WarehouseIdentifier) ).FirstOrDefaultAsync();
        }

        public async Task<Warehouse> GetByDesignationAsync(string designation){
            
            return await _context.Warehouses.Where(x => designation.Equals(x.Designation.Designation) && x.Active).FirstOrDefaultAsync();
        }
        public Task<List<WarehouseDto>> GetByWarehouseIdsAsync(List<WarehouseDto> ids){
            throw new System.NotImplementedException();
        }
        
        
    }
}