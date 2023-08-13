using AutoMapper;
using FormBuilder.Models;
using FormBuilder.ViewModels.EntityForm;

namespace FormBuilder.Profiles
{
    public class EntityFormMapper: Profile
    {
        public EntityFormMapper() {
            CreateMap<EntityFormRequestVM, EntityFroms>()
                .ForMember(dest => dest.EntityFromsName, opt => opt.MapFrom(src => src.formName))
                .ForMember(dest => dest.EntitySchemaId, opt => opt.MapFrom(src => src.EntityId))
                .ForMember(dest => dest.FromJson, opt => opt.MapFrom(src => src.formJson));
        }
    }
}
