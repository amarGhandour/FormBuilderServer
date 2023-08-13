using AutoMapper;
using FormBuilder.Models;
using FormBuilder.ViewModels.EntitySchema;

namespace FormBuilder.Profiles
{
    public class EntitySchemaMapper: Profile
    {
        public EntitySchemaMapper() {

            CreateMap<EntitySchema, EntitySchemaAllResponseVM>();

            CreateMap<EntitySchemaRequestVM, EntitySchema>();
        }
    }
}
