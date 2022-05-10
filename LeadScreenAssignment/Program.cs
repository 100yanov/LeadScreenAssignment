using LeadScreenAssignment.Business;
using LeadScreenAssignment.Persistence;
using LeadScreenAssignment.Persistence.Interfaces;
using SimpleInjector;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();


var businessIoCConfig = new BusinessIoCConfig(builder.Services, builder.Configuration); //TODO: make static
businessIoCConfig.AddServices();
businessIoCConfig.RegisterDependencies();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var uow = scope.ServiceProvider.GetService<IUnitOfWork>();
    
    DbInitializer.Seed(uow);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


