using FormBuilder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalSettingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GlobalSettingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.GlobalSettings.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var url = await _context.GlobalSettings.FirstOrDefaultAsync(url => url.Id == id);
            return Ok(url);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GlobalSettings globalSettings)
        {
            if(globalSettings == null)
            {
                return BadRequest();
            }
            
            _context.GlobalSettings.Add(globalSettings);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetById", new { id = globalSettings.Id }, globalSettings);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id , GlobalSettings globalSettings)
        {
            if (globalSettings == null)
            {
                return BadRequest();
            }

            if (!GlobalSettingsExit(id))
            {
                return NotFound();
            }

            _context.Entry(globalSettings).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var url = await _context.GlobalSettings.FirstOrDefaultAsync(x => x.Id == id);
            if(url == null)
            {
                return NotFound();
            }
            _context.GlobalSettings.Remove(url);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool GlobalSettingsExit(Guid id)
        {
            return _context.GlobalSettings.Any(url => url.Id == id);
        }
    }
}
