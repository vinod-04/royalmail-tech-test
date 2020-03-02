using AutoMapper;

namespace people.api.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Domain.People, Models.People>();
            CreateMap<Domain.Skills, Models.Skill>();
            CreateMap<Domain.PersonSkills, Models.PersonSkill>()
                //To avoid circular references. .Net Core 3.0 does not support circular references
                .ForMember(dest => dest.Skill, act => act.Ignore())  
                .ForMember(dest => dest.Person, act => act.Ignore());
        }
    }
}
