using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FormBuilder.Models;
using FormBuilder.ViewModels.AttributeSchema;
using FormBuilder.ViewModels.EntityForm;
using FormBuilder.ViewModels.EntitySchema;
using FormBuilder.Interfaces.Repositories;
using Microsoft.VisualBasic;

namespace FormBuilder.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntitySchemasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEntitySchemaRepository entitySchemaRepository;

        public EntitySchemasController(ApplicationDbContext context, IEntitySchemaRepository entitySchemaRepository)
        {
            _context = context;
            this.entitySchemaRepository = entitySchemaRepository;
        }

        // GET: api/EntitySchemas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntitySchema>>> GetentitySchemas()
        {
            return  Ok(await entitySchemaRepository.GetAllAsync());
        }

        // GET: api/EntitySchemas/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetEntitySchema(int id)
        {
            var entitySchema = await entitySchemaRepository.GetByIdAsync(id);

            if (entitySchema == null)
            {
                return NotFound();
            }

            var entitySchemaVm = new EntitySchemaVM()
            { EntityCode = entitySchema.EntityCode, EntitySchemaId = entitySchema.EntitySchemaId, EntityName = entitySchema.EntityName };

            var attributesVM = new HashSet<AttributeSchemaVM>();
            foreach (var attribute in entitySchema.AttributeSchemas)
            {
                var attributeVm = new AttributeSchemaVM() { 
                    Id = attribute.AttributeSchemaId,
                    Type = attribute.AttributeType.AttributeName, DisplayName = attribute.DisplayName, IsRequired = attribute.IsRequired, Name = attribute.LogicalName
                , MaxLen = attribute.MaxLen, MinLen = attribute.MinLen, Searchable = attribute.IsSearchable};

                if (attribute.AttributeType.AttributeName == "option set" || attribute.AttributeType.AttributeName == "two options")
                {

                    var lookupPatternId = attribute.OptionSetTypeId;
                    var optionsValues = await _context.OptionSetValues.Where(e => e.OptionSetTypeId == lookupPatternId).ToListAsync();

                    // var optionSetValues = _context.AttributeSchemaOptionSetTypes
                    //.Include(e => e.AttributeSchema ).Include(e => e.OptionSetTypeId)
                    //.Where(e => e.AttributeSchemaId == attribute.AttributeSchemaId)
                    //.Select(e => e.OptionSetType).ToList();


                    foreach (var option in optionsValues)
                    {
                        attributeVm.Options.Add(option.Name, option.Value);
                    }


                }
                attributesVM.Add(attributeVm);

            }
            entitySchemaVm.AttributeSchemas = attributesVM;
            return Ok(entitySchemaVm);
        }

        // PUT: api/EntitySchemas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntitySchema(int id, EntitySchemaRequestVM entitySchemaRequest)
        {
            var entitySchema = _context.entitySchemas.FirstOrDefault(e => e.EntitySchemaId == id);
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
        public async Task<ActionResult<EntitySchema>> PostEntitySchema(EntitySchemaRequestVM entitySchemaRequest)
        {
            if (entitySchemaRequest == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entitySchema = new EntitySchema() { EntityName = entitySchemaRequest.EntityName, EntityCode = entitySchemaRequest.EntityCode};

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
            var res = await _context.EntityFroms.Include(e => e.EntitySchema).Where(e => e.EntitySchemaId == id).ToListAsync();

            var entityFormVms = new List<EntityFormVM>();

            foreach(var form in res)
            {
                var formVm = new EntityFormVM() { EntityName = form.EntitySchema.EntityName, FormName = form.EntityFromsName, FormJson = form.FromJson, Id = form.EntityFromsId };
                entityFormVms.Add(formVm);
            }

            return Ok(entityFormVms);
        }

        // GET: api/EntitySchemas/5/forms/default
        //[HttpGet("{id}/forms/{formName}")]
        //public async Task<ActionResult> GetEntityFormByName(int id, string formName)
        //{
        //    var res = await _context.EntityFroms.Include(e => e.EntitySchema).Where(e => e.EntitySchemaId == id).Where(e => e.EntityFromsName == formName).FirstOrDefaultAsync();

        //    if (res == null)
        //        return NotFound();

        //   var formVm = new EntityFormVM() { EntityName = res.EntitySchema.EntityName, FormName = res.EntityFromsName, FormJson = res.FromJson, Id = res.EntityFromsId };
  
        //    return Ok(formVm);
        //}

        // GET: api/EntitySchemas/5/forms/1
        [HttpGet("{id}/forms/{formId}")]
        public async Task<ActionResult> GetEntityFormById(int id, int formId)
        {
            var res = await _context.EntityFroms.Include(e => e.EntitySchema).Where(e => e.EntitySchemaId == id && e.EntityFromsId == formId).FirstOrDefaultAsync();

            if (res == null)
                return NotFound();

            var formVm = new EntityFormVM() { EntityName = res.EntitySchema.EntityName, FormName = res.EntityFromsName, FormJson = res.FromJson, Id = res.EntityFromsId };

            return Ok(formVm);
        }

    }
}
