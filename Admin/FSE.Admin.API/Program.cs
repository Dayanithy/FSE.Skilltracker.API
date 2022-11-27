using FSE.Admin.API.Application.Behaviors;
using FSE.Admin.API.AsyncDataServices;
using FSE.Admin.API.EventProcessing;
using FSE.Admin.API.Infrastructure.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(HttpGlobalExceptionFilter));
}).AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);

builder.Services.AddHostedService<MessageBusSubscriber>();
builder.Services.AddSingleton(typeof(IEventProcessor), typeof(EventProcessor));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "FSE Admin API", Version = "v1", Description = "Documentation for FSE Admin API" });
});

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BusinessBehavior<,>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
