namespace FSE.Admin.Infrastructure.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ProfileContext _context;

        public ProfileRepository(ProfileContext context)
        {
            _context = context;
        }

        public async Task<FseProfile> SearchByAssociateId(string associateId)
        {
            return _context.Profiles.AsEnumerable().FirstOrDefault(user => user.AssociateId.ToLower() == associateId.ToLower());
        }

        public async Task<List<FseProfile>> SearchbyAssociateName(string name)
        {
            return _context.Profiles.AsEnumerable().Where(user => user.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public async Task<IEnumerable<FseProfile>> SearchBySkillName(string skillName)
        {
            return _context.Profiles.AsEnumerable()
                .Where(user => user.Skills.Any(skill => skill.SkillName.Equals(skillName, StringComparison.OrdinalIgnoreCase) 
                                                                && skill.Proficiency >= 10));
        }
    }
}
