using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FormBuilder.Models;
using FormBuilder.ViewModels.EntityForm;
using FormBuilder.Interfaces.Repositories;
using AutoMapper;

namespace FormBuilder.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityFromsController : ControllerBase
    {
        
        private readonly IEntityFormRepository entityFormRepository;
        private readonly IEntitySchemaRepository entitySchemaRepository;
        private readonly IMapper mapper;
        private readonly ApplicationDbContext _context;
        public EntityFromsController(ApplicationDbContext context, IEntityFormRepository entityFormRepository, IEntitySchemaRepository entitySchemaRepository, IMapper mapper)
        {
            this.entityFormRepository = entityFormRepository;
            this.entitySchemaRepository = entitySchemaRepository;
            this.mapper = mapper;
            this._context = context;
        }

        // GET: api/EntityFroms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntityFroms>>> GetEntityFroms(string formName)
        {
            var query = _context.EntityFroms.AsQueryable();

            if (formName != null)
            {
                query = query.Where(e => e.EntityFromsName == formName);
            }

            return await query.ToListAsync();
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
        public async Task<IActionResult> PutEntityFroms(Guid id, EntityFormRequestVM entityFormRequest)
        {

            var entityFormFound = await entityFormRepository.FindAsync(id);

            if (entityFormFound == null)
            {
                return NotFound();
            }

            var entitySchema = entitySchemaRepository.GetByIdAsync(entityFormRequest.EntityId);

            if (entitySchema == null)
            {
                return NotFound();
            }

            var entityForm = mapper.Map<EntityFroms>(entityFormRequest);

            await entityFormRepository.EditAsync(id ,entityForm, e => e.EntityFromsId);

            return NoContent();
        }

        // POST: api/EntityFroms
        [HttpPost]
        public async Task<ActionResult<EntityFroms>> PostEntityFroms(EntityFormRequestVM entityFormRequestVm)
        {
            
            if (entityFormRequestVm == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            var entitySchema = await entitySchemaRepository.GetByIdAsync(entityFormRequestVm.EntityId);
            if (entitySchema == null)
                return BadRequest("Entity Id does't exist.");

            var entityForm = mapper.Map<EntityFroms>(entityFormRequestVm);

            var entityFormJson = await entityFormRepository.AddAsync(entityForm);

            var entityFormResponseVm = mapper.Map<EntityFormResponseVM>(entityFormJson);

            return CreatedAtAction("GetEntityFroms", new { id = entityFormJson.EntityFromsId }, entityFormResponseVm);
        }

        // DELETE: api/EntityFroms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntityFroms(Guid id)
        {
            var entityFroms = entityFormRepository.GetByIdAsync(id);
            if (entityFroms == null)
            {
                return NotFound();
            }

            await entityFormRepository.DeleteAsync(entityFroms);

            return NoContent();
        }

        private bool EntityFromsExists(Guid id)
        {
            return _context.EntityFroms.Any(e => e.EntityFromsId == id);
        }
    }
}
