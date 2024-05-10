using Microsoft.EntityFrameworkCore;
using Repositories.EfCore;
using StoreApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly) 
    .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureMysqlContext(builder.Configuration);
//builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServicesManager();

/*
builder.Services.AddDbContext<RepositoryContext>(option =>
{
    option.UseMySQL(builder.Configuration.GetConnectionString("MysqlConnection"));
});
*/

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
