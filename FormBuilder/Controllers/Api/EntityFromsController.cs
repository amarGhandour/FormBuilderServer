using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FormBuilder.Models;
using FormBuilder.ViewModels.EntityForm;

namespace FormBuilder.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityFromsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EntityFromsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EntityFroms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntityFroms>>> GetEntityFroms()
        {
            return await _context.EntityFroms.ToListAsync();
        }

        // GET: api/EntityFroms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntityFroms>> GetEntityFroms(int id)
        {
            var entityFroms = await _context.EntityFroms.FindAsync(id);

            if (entityFroms == null)
            {
                return NotFound();
            }

            return entityFroms;
        }

        // PUT: api/EntityFroms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntityFroms(int id, EntityFroms entityFroms)
        {
            if (id != entityFroms.EntityFromsId)
            {
                return BadRequest();
            }

            _context.Entry(entityFroms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityFromsExists(id))
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

        // POST: api/EntityFroms
        [HttpPost]
        public async Task<ActionResult<EntityFroms>> PostEntityFroms(EntityFormCreateVM entityFormVm)
        {
            
            if (entityFormVm == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            // check entity schema is exist
            var entitySchema =  _context.entitySchemas.FirstOrDefault(e => e.EntitySchemaId == entityFormVm.EntityId);
            if (entitySchema == null)
                return BadRequest("Entity Id does't exist.");


            var entityFormJson = new EntityFroms() { EntityFromsName = entityFormVm.formName, EntitySchemaId = entityFormVm.EntityId, FromJson = entityFormVm.formJson };

            _context.EntityFroms.Add(entityFormJson);

            await _context.SaveChangesAsync();


            return Created("GetEntityFroms", null);
        }

        // DELETE: api/EntityFroms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntityFroms(int id)
        {
            var entityFroms = await _context.EntityFroms.FindAsync(id);
            if (entityFroms == null)
            {
                return NotFound();
            }

            _context.EntityFroms.Remove(entityFroms);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntityFromsExists(int id)
        {
            return _context.EntityFroms.Any(e => e.EntityFromsId == id);
        }
    }
}
