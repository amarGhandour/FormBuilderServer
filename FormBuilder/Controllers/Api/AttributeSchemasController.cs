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
    public class AttributeSchemasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AttributeSchemasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AttributeSchemas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttributeSchema>>> GetAttributeSchemas()
        {
            return await _context.AttributeSchemas.ToListAsync();
        }

        // GET: api/AttributeSchemas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AttributeSchema>> GetAttributeSchema(int id)
        {
            var attributeSchema = await _context.AttributeSchemas.FindAsync(id);

            if (attributeSchema == null)
            {
                return NotFound();
            }

            return attributeSchema;
        }

        // PUT: api/AttributeSchemas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttributeSchema(int id, AttributeSchema attributeSchema)
        {
            if (id != attributeSchema.AttributeSchemaId)
            {
                return BadRequest();
            }

            _context.Entry(attributeSchema).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttributeSchemaExists(id))
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

        // POST: api/AttributeSchemas
        [HttpPost]
        public async Task<ActionResult<AttributeSchema>> PostAttributeSchema(AttributeSchema attributeSchema)
        {
            _context.AttributeSchemas.Add(attributeSchema);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttributeSchema", new { id = attributeSchema.AttributeSchemaId }, attributeSchema);
        }

        // DELETE: api/AttributeSchemas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttributeSchema(int id)
        {
            var attributeSchema = await _context.AttributeSchemas.FindAsync(id);
            if (attributeSchema == null)
            {
                return NotFound();
            }

            _context.AttributeSchemas.Remove(attributeSchema);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttributeSchemaExists(int id)
        {
            return _context.AttributeSchemas.Any(e => e.AttributeSchemaId == id);
        }
    }
}
