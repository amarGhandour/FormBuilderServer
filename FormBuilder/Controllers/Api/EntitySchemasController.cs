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
using AutoMapper;
using FormBuilder.ViewModels.lookup;
using FormBuilder.Models.Tables;
using System.Data;
using Microsoft.Data.SqlClient;

namespace FormBuilder.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntitySchemasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEntitySchemaRepository entitySchemaRepository;
        private readonly IMapper mapper;

        public EntitySchemasController(ApplicationDbContext context, IEntitySchemaRepository entitySchemaRepository, IMapper mapper)
        {
            _context = context;
            this.entitySchemaRepository = entitySchemaRepository;
            this.mapper = mapper;
        }

        // GET: api/EntitySchemas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntitySchema>>> GetentitySchemas()
        {

            var entitySchemasList = await entitySchemaRepository.GetAllAsync();

            var response = mapper.Map<IEnumerable<EntitySchemaAllResponseVM>>(entitySchemasList);

            return  Ok(response);
        }

        // GET: api/EntitySchemas/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetEntitySchema(Guid id)
        {
            var entitySchema = await entitySchemaRepository.GetByIdAsync(id);

            if (entitySchema == null)
            {
                return NotFound();
            }

            var entitySchemaVm = new EntitySchemaResponseVM()
            { EntityCode = entitySchema.EntityCode, EntitySchemaId = entitySchema.EntitySchemaId.ToString(), EntityName = entitySchema.EntityName };

            var attributesVM = new HashSet<AttributeSchemaResponseVM>();
            foreach (var attribute in entitySchema.AttributeSchemas)
            {
                var attributeVm = new AttributeSchemaResponseVM() { 
                    Id = attribute.AttributeSchemaId.ToString(),
                    Type = attribute.AttributeType.AttributeName, DisplayName = attribute.DisplayName, IsRequired = attribute.IsRequired, Name = attribute.LogicalName
                , MaxLen = attribute.MaxLen, MinLen = attribute.MinLen, Searchable = attribute.IsSearchable};

                if (attribute.AttributeType.AttributeName == "option set" || attribute.AttributeType.AttributeName == "two options")
                {

                    var lookupPatternId = attribute.OptionSetTypeId;
                    var optionsValues = await _context.OptionSetValues.Where(e => e.OptionSetTypeId == lookupPatternId).ToListAsync();

                    foreach (var option in optionsValues)
                    {
                        attributeVm.Options.Add(option.Name, option.Value);
                    }

                }else if (attribute.AttributeType.AttributeName == "lookup")
                {
                    var lookupId = attribute.LookupId;
                    var lookup = await _context.Lookups.Include(e => e.ParentTable).ThenInclude(e => e.EntityViews).FirstOrDefaultAsync(e => e.LookupId == lookupId);

                    if (lookup != null)
                    {
                        var views = lookup.ParentTable.EntityViews;
                        var lookupResponse = new LookupResponseVm() { LookFor = lookup.ParentTable.EntityName, LookupId = lookup.LookupId };

                        foreach (var view in views)
                        {
                            lookupResponse.Views.Add(view.Name);
                        }
                        attributeVm.Lookup = lookupResponse;
                    }

                }
                attributesVM.Add(attributeVm);

            }
            entitySchemaVm.AttributeSchemas = attributesVM;
            return Ok(entitySchemaVm);
        }

        // PUT: api/EntitySchemas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntitySchema(Guid id, EntitySchemaRequestVM entitySchemaRequest)
        {

            var entitySchema = mapper.Map<EntitySchema>(entitySchemaRequest);

            if (entitySchema == null)
            {
                return BadRequest();
            }

            entitySchema = await entitySchemaRepository.EditAsync(id, entitySchema, es => es.EntitySchemaId);

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

            var entitySchema = new EntitySchema() { EntityName = entitySchemaRequest.EntityName, DisplayName = entitySchemaRequest.DisplayName, EntityCode = entitySchemaRequest.EntityCode};

            _context.entitySchemas.Add(entitySchema);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntitySchema", new { id = entitySchema.EntitySchemaId }, entitySchema);
        }

        // DELETE: api/EntitySchemas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntitySchema(Guid id)
        {
            var isDeleted = await entitySchemaRepository.DeleteAsync(id);
            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();

        }

        private bool EntitySchemaExists(Guid id)
        {
            return _context.entitySchemas.Any(e => e.EntitySchemaId == id);
        }


        // GET: api/EntitySchemas/5/forms
        [HttpGet("{id}/forms")]
        public async Task<ActionResult> GetEntityForms(string id)
        {
            var res = await _context.EntityFroms.Include(e => e.EntitySchema).Where(e => e.EntitySchemaId.ToString() == id).ToListAsync();

            var entityFormVms = new List<EntityFormResponseVM>();

            foreach(var form in res)
            {
                var formVm = new EntityFormResponseVM() { EntityName = form.EntitySchema.EntityName, FormName = form.EntityFromsName, FormJson = form.FromJson, Id = form.EntityFromsId.ToString() };
                entityFormVms.Add(formVm);
            }

            return Ok(entityFormVms);
        }

     

        // GET: api/EntitySchemas/5/forms/1
        [HttpGet("{id}/forms/{formId}")]
        public async Task<ActionResult> GetEntityFormById(string id, string formId)
        {
            var res = await _context.EntityFroms.Include(e => e.EntitySchema).Where(e => e.EntitySchemaId.ToString() == id && e.EntityFromsId.ToString() == formId).FirstOrDefaultAsync();

            if (res == null)
                return NotFound();

            var formVm = new EntityFormResponseVM() { EntityName = res.EntitySchema.EntityName, FormName = res.EntityFromsName, FormJson = res.FromJson, Id = res.EntityFromsId.ToString() };

            return Ok(formVm);
        }

        [HttpGet("{entityId}/views")]
        public async Task<ActionResult> GetEntityViews(Guid entityId)
        {
            var res = await _context.EntityViews.Where(e => e.EntitySchemaId == entityId).ToListAsync();

            return Ok(res);
        }


        [HttpGet("viewData")]
        public async Task<ActionResult> GetViewData(string viewName)
        {
            string sqlQuery = $"SELECT * FROM {viewName}";

            string table = "Department";
            Type entityType = Type.GetType(table);

            var res = await _context.Database.SqlQueryRaw<SqlDataAdapter>(sqlQuery).ToListAsync();

            return Ok(res);
        }
    }
}
