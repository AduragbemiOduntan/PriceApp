using PriceApp_API.Extensions;
using PriceApp_Application.Common;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Configuration for logging service (uisng serilog)
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
// Add services to the container.
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureDependencyInjection();
builder.Services.AddAutoMapper(typeof(MapInitializer));
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
/*builder.Services.ConfigureJWT(builder.Configuration);*/

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();
/*builder.Services.ConfigureSwaggerAuth();*/

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else if (app.Environment.IsProduction())
{
    app.UseHsts();
}

/*app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All
});*/

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

/*app.UseAuthentication();*/

app.UseAuthorization();

app.MapControllers();

app.Run();
