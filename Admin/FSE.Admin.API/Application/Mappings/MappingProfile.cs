namespace FSE.Admin.API.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FseProfileDTO, FseProfile>();
            CreateMap<FseProfile, FseProfileDTO>();
            CreateMap<SkillDTO, Skill>();
            CreateMap<Skill, SkillDTO>();
        }
    }
}
