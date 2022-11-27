namespace FSE.Infrastructure.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ProfileContext _context;

        public ProfileRepository(ProfileContext context)
        {
            _context = context;
        }
        public async Task<string> AddProfile(FseProfile profile)
        {
            var existingProfile = await _context.Profiles!.FirstOrDefaultAsync(t => t.AssociateId == profile.AssociateId);

            if (existingProfile != null)
                return $"FSE Profile with {profile.AssociateId} already exists.";

            profile.CreatedDate = DateTime.Now;
            profile.LastModifiedDate = DateTime.Now;

            await _context.Profiles!.AddAsync(profile);

            await _context.SaveChangesAsync();

            return $"FSE Profile with {profile.AssociateId} successfully created.";
        }

        public async Task<string> UpdateProfile(FseProfile profile)
        {
            var existingProfile = await _context.Profiles!.FirstOrDefaultAsync(t => t.AssociateId == profile.AssociateId);

            if (existingProfile == null)
                return $"FSE Profile with {profile.AssociateId} does not exists.";
            else if (existingProfile.LastModifiedDate != null && Convert.ToDateTime(existingProfile.LastModifiedDate) > DateTime.Now.AddDays(-10))
                return $"Profile update is allowed only after 10 days of adding or modifications.";

            existingProfile.Skills = profile.Skills;
            existingProfile.LastModifiedDate = DateTime.Now;
            
            _context.Profiles!.Update(existingProfile);

            await _context.SaveChangesAsync();

            return $"FSE Profile with {profile.AssociateId} successfully updated.";
        }
    }
}
