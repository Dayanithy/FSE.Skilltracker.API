namespace FSE.Admin.Infrastructure.Repositories
{
    public class SearchService : ISearchService
    {
        private readonly ICacheService _cacheService;
        private readonly IProfileRepository _profileRepository;

        public SearchService(ICacheService cacheService, IProfileRepository profileRepository)
        {
            _cacheService = cacheService;
            _profileRepository = profileRepository;
        }

        public async Task<FseProfile> SearchByAssociateId(string associateId)
        {
            return await _profileRepository.SearchByAssociateId(associateId);
        }

        public async Task<List<FseProfile>> SearchByAssociateName(string name)
        {
            return await _profileRepository.SearchbyAssociateName(name);
        }

        public async Task<IEnumerable<FseProfile>> SearchBySkillName(string skillName)
        {
            return await _profileRepository.SearchBySkillName(skillName);
        }
    }
}
