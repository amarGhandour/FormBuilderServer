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
    public class EntitySchemasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EntitySchemasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EntitySchemas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntitySchema>>> GetentitySchemas()
        {
            return await _context.entitySchemas.ToListAsync();
        }

        // GET: api/EntitySchemas/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetEntitySchema(int id)
        {
            var entitySchema =  _context.entitySchemas.Include(e => e.AttributeSchemas).ToList();

            if (entitySchema == null)
            {
                return NotFound();
            }

            return Ok(entitySchema);
        }

        // PUT: api/EntitySchemas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntitySchema(int id, EntitySchema entitySchema)
        {
            if (id != entitySchema.EntitySchemaId)
            {
                return BadRequest();
            }

            _context.Entry(entitySchema).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntitySchemaExists(id))
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

        // POST: api/EntitySchemas
        [HttpPost]
        public async Task<ActionResult<EntitySchema>> PostEntitySchema(EntitySchema entitySchema)
        {
            _context.entitySchemas.Add(entitySchema);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntitySchema", new { id = entitySchema.EntitySchemaId }, entitySchema);
        }

        // DELETE: api/EntitySchemas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntitySchema(int id)
        {
            var entitySchema = await _context.entitySchemas.FindAsync(id);
            if (entitySchema == null)
            {
                return NotFound();
            }

            _context.entitySchemas.Remove(entitySchema);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntitySchemaExists(int id)
        {
            return _context.entitySchemas.Any(e => e.EntitySchemaId == id);
        }


        // GET: api/EntitySchemas/5/forms
        [HttpGet("{id}/forms")]
        public async Task<ActionResult> GetEntityForms(int id)
        {
            var res = await _context.EntityFroms.Where(e => e.EntitySchemaId == id).ToListAsync();

            return Ok(res);
        }
    }
}
