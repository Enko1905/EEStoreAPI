using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NLog;
using Presentation.ActionFilters;
using Repositories.EfCore;
using Services;
using Services.Contracts;
using StoreApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

LogManager.Setup().LoadConfigurationFromFile(String.Concat(Directory.GetCurrentDirectory(), "/nlog.con"));



builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true; //Ýçerik Pazarlýðý Açýk
    config.ReturnHttpNotAcceptable = true;  //Geçersiz kabul edilmediði 406
})

    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly)
   /* .AddNewtonsoftJson(option =>
    { 
        option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

    })*/
  //  .AddCustomCsvFormatter()
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

builder.Services.ConfigureActionFilters();
builder.Services.ConfigureCors();
builder.Services.ConfigureDataShapper();
<<<<<<< HEAD
=======

builder.Services.AddCustomMediaTypes();
builder.Services.AddScoped<IProductLinks,ProductLinks>();
>>>>>>> 475fa9d2df6d15050b6f161b88f099728dd8905c

/*
 * 
builder.Services.AddDbContext<RepositoryContext>(option =>
{
    option.UseMySQL(builder.Configuration.GetConnectionString("MysqlConnection"));
});
*/


//ModelState 
builder.Services.Configure<ApiBehaviorOptions>(option =>
{
    option.SuppressModelStateInvalidFilter = true;
});


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
else
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

/*
"Production", yazýlým ürününün gerçek kullanýcýlar tarafýndan kullanýldýðý ve iþletme için gerçek deðer saðladýðý ortamý ifade eder.*/
if (app.Environment.IsProduction())
{
    /*app.UseHsts() ASP.NET Core uygulamalarýnda HTTPS Strict Transport Security (HSTS) özelliðini etkinleþtiren bir middleware'dir. Bu özellik, tarayýcýlara uygulamanýn sadece HTTPS üzerinden eriþilebileceðini bildiren bir HTTP yanýt baþlýðý gönderir. Böylece, tarayýcýlar bu siteye gelecek isteklerde otomatik olarak HTTPS kullanacaktýr.*/
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
