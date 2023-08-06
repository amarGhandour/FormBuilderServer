using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FormBuilder.Models;

namespace FormBuilder.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributeTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AttributeTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AttributeTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttributeType>>> GetAttributeTypes()
        {
            return await _context.AttributeTypes.ToListAsync();
        }

        // GET: api/AttributeTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AttributeType>> GetAttributeType(int id)
        {
            var attributeType = await _context.AttributeTypes.FindAsync(id);

            if (attributeType == null)
            {
                return NotFound();
            }

            return attributeType;
        }

        // PUT: api/AttributeTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttributeType(int id, AttributeType attributeType)
        {
            if (id != attributeType.AttributeTypeId)
            {
                return BadRequest();
            }

            _context.Entry(attributeType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttributeTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AttributeTypes
        [HttpPost]
        public async Task<ActionResult<AttributeType>> PostAttributeType(AttributeType attributeType)
        {
            _context.AttributeTypes.Add(attributeType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttributeType", new { id = attributeType.AttributeTypeId }, attributeType);
        }

        // DELETE: api/AttributeTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttributeType(int id)
        {
            var attributeType = await _context.AttributeTypes.FindAsync(id);
            if (attributeType == null)
            {
                return NotFound();
            }

            _context.AttributeTypes.Remove(attributeType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttributeTypeExists(int id)
        {
            return _context.AttributeTypes.Any(e => e.AttributeTypeId == id);
        }
    }
}
