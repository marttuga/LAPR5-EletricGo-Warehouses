using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;


namespace DDDSample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehouseService _service;

        public WarehousesController(IWarehouseService service)
        {
            _service = service;
        }

        // GET: api/Warehouses
        [HttpGet("/api/warehouse/getAll")]
        public async Task<ActionResult<IEnumerable<WarehouseDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }
        // GET: api/Warehouses
        [HttpPost("/api/warehouse/SGRAI/createAll")]
         public  async Task<List<WarehouseDto>> CreateAllWarehouses()
        {
            var w1 = new CreatingWarehouseDto("W01","Arouca",(float)40.9321,(float)8.2451,"Rua de S. Sebastião",7,"Arouca","4540-099","250");
            var w2 = new CreatingWarehouseDto("W02","Espinho",(float)41.0072,(float)8.6410,"Rua dos Limites",10,"Espinho","4415-416","550");
            var w3 = new CreatingWarehouseDto("W03","Gondomar",(float)41.1396,(float)8.5291,"Avenida Oliveira Martins",23,"Gondomar","4420-134","200");
            var w4 = new CreatingWarehouseDto("W04","Maia",(float)41.2279,(float)8.6210,"Avenida da Campa do Preto",63,"Maia","4465-780","700");
            var w5 = new CreatingWarehouseDto("W05","Matosinhos",(float)41.1844,(float)8.6963,"Avenida dos Combatentes da Grande Guerra",43,"Matosinhos","4100-001","350");
            var w6 = new CreatingWarehouseDto("W06","Oliveira de Azeméis",(float)40.8387,(float)8.4770,"Avenida Nossa Senhora das Flores",46,"Oliveira de Azeméis","3720-091","750");
            var w7 = new CreatingWarehouseDto("W09","Paredes",(float)41.2052,(float)8.3304,"Rua Almeida Garrett",2,"Paredes","4580-001","0");
            var w8 = new CreatingWarehouseDto("W14","Porto",(float)41.1579,(float)8.6291,"Rua Dr. Mário",3,"Porto","1800-412","600");
            var w9 = new CreatingWarehouseDto("W07","Póvoa de Varzim",(float)41.3804,(float)8.7609,"Largo Doutor Vasques Calafate",57,"Póvoa de Varzim","4480-849","400");
            var w10 = new CreatingWarehouseDto("W10","Santa Maria da Feira",(float)40.9268,(float)8.5483,"Avenida Professor Vicente Coelho",43,"Santa Maria da Feira","4520-102","100");
            var w11= new CreatingWarehouseDto( "W11","Santo Tirso",(float)41.3431,(float)8.4738,"Calçada Devesa",47,"Santo Tirso","4780-296","650");
            var w12 = new CreatingWarehouseDto("W12","São João da Madeira",(float)40.9005,(float)8.4907,"Rua Visconde de São João da Madeira",28,"São João da Madeira","3700-008","300");
            var w13 = new CreatingWarehouseDto("W13","Trofa",(float)41.3391,(float)8.5600,"Avenida das Pateiras",10,"Trofa","4785-024","450");
            var w14 = new CreatingWarehouseDto("W08","Vale de Cambra",(float)40.8430,(float)8.3956,"Avenida António Alberto Almeida Pinheiro",23,"Vale de Cambra","3730-031","50");
            var w15 = new CreatingWarehouseDto("W15","Valongo",(float)41.1887,(float)8.4983,"Rua da Paz",49,"Valongo","4440-004","800");
            var w16 = new CreatingWarehouseDto("W16","Vila do Conde",(float)41.3517,(float)8.7479,"Largo dos Artistas",38,"Vila do Conde","4480-001","150");
            var w17 = new CreatingWarehouseDto("W17","Vila Nova de Gaia",(float)41.1239,(float)8.6118,"Rua Camélias",61,"Vila Nova de Gaia","4400-002","500");

            var listW = new List<CreatingWarehouseDto> {w1, w2, w3, w4, w5, w6, w7, w8, w9, w10, w11, w12, w13, w14, w15, w16, w17};

            var listResult = new List<WarehouseDto>();
         
            foreach (var a in listW)
            {
              var dto=  await Create(a);
                listResult.Add(dto.Value);
            }
            
            return  listResult;
        }

        // GET: api/Warehouses/5
        [HttpGet("/api/warehouse/getById/{id}")]
        public async Task<ActionResult<WarehouseDto>> GetGetById(Guid id)
        {
            var warehouse = await _service.GetByIdAsync(new Identifier(id));

            if (warehouse == null)
            {
                return NotFound();
            }

            return warehouse;
        }

        // GET: api/Warehouses/5
        [HttpGet("/api/warehouse/getByWI/{warehouseIdentifier}")]
        public async Task<ActionResult<WarehouseDto>> GetGetByWarehouseId(string warehouseIdentifier)
        {
            var warehouse = await _service.GetByWarehouseIdAsync(warehouseIdentifier);

            if (warehouse == null)
            {
                return NotFound();
            }

            return warehouse;
        }

        // GET: api/Warehouses/5
        [HttpGet("/api/warehouse/getByDesignation/{designation}")]
        public async Task<ActionResult<WarehouseDto>> GetByDesignationAsync(string designation)
        {
            var warehouse = await _service.GetByDesignationAsync(designation);

            if (warehouse == null)
            {
                return NotFound();
            }

            return warehouse;
        }

        // POST: api/Warehouses
        [HttpPost("/api/warehouse/createWarehouse")]
        public async Task<ActionResult<WarehouseDto>> Create(CreatingWarehouseDto dto)
        {
            var warehouses = await _service.GetByWarehouseIdAsync(dto.WarehouseIdentifier);
            if (warehouses != null)
            {
                throw new BusinessRuleValidationException("Warehouse identifier must be unique!");
            }

            try
                {
                    var warehouse = await _service.AddAsync(dto);

                    return CreatedAtAction(nameof(GetGetById), new { id = warehouse.Id }, warehouse);
                }
                catch(BusinessRuleValidationException ex)
                {
                    return BadRequest(new {Message = ex.Message});
                }


        }
            
        

        
        
        /*// PUT: api/Warehouses/5
        [HttpPut("/api/warehouse/updateWarehouse/{id}")]
        public async Task<ActionResult<WarehouseDto>> Update(Guid id, WarehouseDto dto)
        {
            /* if (id != dto.Id)
            {
                return BadRequest();
            } #1#
            dto.Id = id;

            try
            {
                var warehouse = await _service.UpdateAsync(dto);
                
                if (warehouse == null)
                {
                    return NotFound();
                }
                return Ok(warehouse);
            }
            catch(BusinessRuleValidationException ex)
            {
                return BadRequest(new {Message = ex.Message});
            }
        }*/

         // PUT: api/Warehouses/5
        [HttpPut("/api/warehouse/Update/{warehouseIdentifier}")]
        public async Task<ActionResult<WarehouseDto>> UpdateWarehouse(string warehouseIdentifier, WarehouseDto dto)
        {
             if (warehouseIdentifier != dto.WarehouseIdentifier)
            {
                return BadRequest();
            }  
            

            try
            {
                var warehouse = await _service.UpdateWarehouseAsync(dto);
                
                if (warehouse == null)
                {
                    return NotFound();
                }
                return Ok(warehouse);
            }
            catch(BusinessRuleValidationException ex)
            {
                return BadRequest(new {Message = ex.Message});
            }
        }
        
        



        // Inactivate: api/Warehouses/5
        [HttpDelete("/api/warehouse/deleteSoft/{id}")]
        public async Task<ActionResult<WarehouseDto>> SoftDelete(String id)
        {
            var warehouse = await _service.InactivateAsync(id);

            if (warehouse == null)
            {
                return NotFound();
            }

            return Ok(warehouse);
        }
        
        // Inactivate: api/Warehouses/5
        [HttpDelete("/api/warehouse/inhibit/{warehouseIdentifier}")]
        public async Task<ActionResult<WarehouseDto>> Inhibit(string warehouseIdentifier)
        {
            var warehouse = await _service.InactivateAsync(warehouseIdentifier);

            if (warehouse == null)
            {
                return NotFound();
            }

            return Ok(warehouse);
        }
        
        // Inactivate: api/Warehouses/5
        [HttpPatch("/api/warehouse/activate/{warehouseIdentifier}")]
        public async Task<ActionResult<WarehouseDto>> Activate(string warehouseIdentifier)
        {
            var warehouse = await _service.ActivateAsync(warehouseIdentifier);

            if (warehouse == null)
            {
                return NotFound();
            }

            return Ok(warehouse);
        }

        
        // DELETE: api/Warehouses/5
        [HttpDelete("/api/warehouse/deleteHard/{id}")]
        public async Task<ActionResult<WarehouseDto>> HardDelete(Guid id)
        {
            try
            {
                var prod = await _service.DeleteAsync(new Identifier(id));

                if (prod == null)
                {
                    return NotFound();
                }

                return Ok(prod);
            }
            catch(BusinessRuleValidationException ex)
            {
               return BadRequest(new {Message = ex.Message});
            }
        }
        // DELETE: api/Warehouses/5
        [HttpDelete("/api/warehouse/deleteAll")]
        public async Task<ActionResult<WarehouseDto>> DeleteAll()
        {
            try
            {
                var warehouses = await _service.GetAllAsync();
                foreach (var a in warehouses)
                {


                   await _service.DeleteAsync(new Identifier(a.Id));

                    
                }
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new {Message = ex.Message});
            }

            return Ok("All Warehouses Deleted");
        }
    }
}