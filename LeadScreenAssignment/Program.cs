using LeadScreenAssignment.Business;
using SimpleInjector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();
var container = new Container();
builder.Services.AddSimpleInjector(container);

var businessIoCConfig = new BusinessIoCConfig(container, builder.Services, builder.Configuration); //TODO: make static
businessIoCConfig.RegisterDependencies();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Services.UseSimpleInjector(container);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


