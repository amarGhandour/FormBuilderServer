using AutoMapper;
using FormBuilder.Models;
using FormBuilder.ViewModels;
using FormBuilder.ViewModels.AttributeSchema;

namespace FormBuilder.Profiles
{
    public class AttributeSchemaMapper: Profile
    {
        public AttributeSchemaMapper() {

            CreateMap<AttributeSchemaRequestVM, AttributeSchema>();
        }
    }
}
