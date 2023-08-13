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

            CreateMap<EntityFroms, EntityFormResponseVM>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EntityFromsId))
               .ForMember(dest => dest.EntityName, opt => opt.MapFrom(src => src.EntitySchema.EntityName))
               .ForMember(dest => dest.FormJson, opt => opt.MapFrom(src => src.FromJson))
               .ForMember(dest => dest.FormName, opt => opt.MapFrom(src => src.EntityFromsName));
        }
    }
}
