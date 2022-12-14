namespace FSE.Admin.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProfileContext>(options =>
                options.UseCosmos(configuration["CosmosDB:ConnectionString"], configuration["CosmosDB:Database"]));

            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<IProfileRepository, ProfileRepository>();

            return services;
        }
    }
}