namespace FSE.Infrastructure
{
    public class ProfileContext : DbContext
    {
        public DbSet<FseProfile>? Profiles { get; set; }

        public ProfileContext(DbContextOptions<ProfileContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FseProfile>()
                .ToContainer("SkillTrackerContainer")
                .HasKey(k => k.AssociateId);
        }
    }
}
