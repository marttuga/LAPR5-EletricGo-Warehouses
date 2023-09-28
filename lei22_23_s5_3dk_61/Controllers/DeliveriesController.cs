using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Deliveries;

namespace DDDSample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController : ControllerBase
    {
        private readonly IDeliveryService _service;
        
        public DeliveriesController(IDeliveryService service)
        {
            _service = service;
        }
        

        // GET: api/Deliveries/getAll
        [HttpGet("/api/Deliveries/getAll")]
        public async Task<ActionResult<IEnumerable<DeliveryDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/Deliveries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryDto>> GetGetById(Guid id)
        {
            var del = await _service.GetByIdAsync(new DeliveryId(id));

            if (del == null)
            {
                return NotFound();
            }

            return del;
        }

        // GET: api/Deliveries/5
        [HttpGet("ById/{dIdentifier}")]
        public async Task<ActionResult<DeliveryDto>> GetGetByDeliveryIdentifier(string dIdentifier)
        {
            var del = await _service.GetByDeliveryIdentifierAsync(dIdentifier);

            if (del == null)
            {
                return NotFound();
            }

            return del;
        }

        // POST: api/Deliveries
        [HttpPost]
        public async Task<ActionResult<DeliveryDto>> Create(CreatingDeliveryDto dto)
        {
            var deliveries = await _service.GetByDeliveryIdentifierAsync(dto.DIdentifier.DIdentifier);
            if (deliveries != null)
            {
                throw new BusinessRuleValidationException("Delivery identifier must be unique!");
            }

            try
            {
                var delivery = await _service.AddAsync(dto);

                return CreatedAtAction(nameof(GetGetById), new { id = delivery.Id }, delivery);
            }
            catch(BusinessRuleValidationException ex)
            {
                return BadRequest(new {Message = ex.Message});
            }


        }

        
        // PUT: api/Deliveries/5
        [HttpPut("{id}")]
        public async Task<ActionResult<DeliveryDto>> Update(Guid id, DeliveryDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            try
            {
                var del = await _service.UpdateAsync(dto);
                
                if (del == null)
                {
                    return NotFound();
                }
                return Ok(del);
            }
            catch(BusinessRuleValidationException ex)
            {
                return BadRequest(new {Message = ex.Message});
            }
        }

        // PUT: api/Deliveries/5
        [HttpPut("Update/{dIdentifier}")]
        public async Task<ActionResult<DeliveryDto>> UpdateDelivery(string dIdentifier, DeliveryDto dto)
        {
            if (dIdentifier != dto.DIdentifier.DIdentifier)
            {
                return BadRequest();
            }
    

            try
            {
                var del = await _service.UpdateDeliveryAsync(dto);
                
                if (del == null)
                {
                    return NotFound();
                }
                return Ok(del);
            }
            catch(BusinessRuleValidationException ex)
            {
                return BadRequest(new {Message = ex.Message});
            }
        }

        // Inactivate: api/Deliveries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeliveryDto>> SoftDelete(Guid id)
        {
            var del = await _service.InactivateAsync(new DeliveryId(id));

            if (del == null)
            {
                return NotFound();
            }

            return Ok(del);
        }
        
        // DELETE: api/Deliveries/5
        [HttpDelete("{id}/hard")]
        public async Task<ActionResult<DeliveryDto>> HardDelete(Guid id)
        {
            try
            {
                var del = await _service.DeleteAsync(new DeliveryId(id));

                if (del == null)
                {
                    return NotFound();
                }

                return Ok(del);
            }
            catch(BusinessRuleValidationException ex)
            {
               return BadRequest(new {Message = ex.Message});
            }
        }
    }
}