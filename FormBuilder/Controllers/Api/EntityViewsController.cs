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
    public class EntityViewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EntityViewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EntityViews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntityView>>> GetEntityView()
        {
            return await _context.EntityViews.ToListAsync();
        }

        // GET: api/EntityViews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntityView>> GetEntityView(Guid id)
        {
            var entityView = await _context.EntityViews.FindAsync(id);

            if (entityView == null)
            {
                return NotFound();
            }

            return entityView;
        }

        // PUT: api/EntityViews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntityView(Guid id, EntityView entityView)
        {
            if (id != entityView.EntityViewId)
            {
                return BadRequest();
            }

            _context.Entry(entityView).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityViewExists(id))
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

        // POST: api/EntityViews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EntityView>> PostEntityView(EntityView entityView)
        {
            _context.EntityViews.Add(entityView);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntityView", new { id = entityView.EntityViewId }, entityView);
        }

        // DELETE: api/EntityViews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntityView(Guid id)
        {
            var entityView = await _context.EntityViews.FindAsync(id);
            if (entityView == null)
            {
                return NotFound();
            }

            _context.EntityViews.Remove(entityView);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntityViewExists(Guid id)
        {
            return _context.EntityViews.Any(e => e.EntityViewId == id);
        }
    }
}
