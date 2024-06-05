using Microsoft.EntityFrameworkCore;
using NLog;
using Repositories.EfCore;
using Services.Contracts;
using StoreApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

LogManager.Setup().LoadConfigurationFromFile(String.Concat(Directory.GetCurrentDirectory(), "/nlog.con"));



builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true; //��erik Pazarl��� A��k
    config.ReturnHttpNotAcceptable = true;  //Ge�ersiz kabul edilmedi�i 406
})

    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly)
    .AddNewtonsoftJson()
    .AddCustomCsvFormatter()
    .AddXmlDataContractSerializerFormatters();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureMysqlContext(builder.Configuration);
//builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServicesManager();
builder.Services.ConfigureLoggerSerciesManager();
builder.Services.AddAutoMapper(typeof(Program));
/*
builder.Services.AddDbContext<RepositoryContext>(option =>
{
    option.UseMySQL(builder.Configuration.GetConnectionString("MysqlConnection"));
});
*/

var app = builder.Build();

//StoreApi> Extension>ExceptionMiddlewareExtension
var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*
"Production", yaz�l�m �r�n�n�n ger�ek kullan�c�lar taraf�ndan kullan�ld��� ve i�letme i�in ger�ek de�er sa�lad��� ortam� ifade eder.*/
if (app.Environment.IsProduction())
{
    /*app.UseHsts() ASP.NET Core uygulamalar�nda HTTPS Strict Transport Security (HSTS) �zelli�ini etkinle�tiren bir middleware'dir. Bu �zellik, taray�c�lara uygulaman�n sadece HTTPS �zerinden eri�ilebilece�ini bildiren bir HTTP yan�t ba�l��� g�nderir. B�ylece, taray�c�lar bu siteye gelecek isteklerde otomatik olarak HTTPS kullanacakt�r.*/
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
