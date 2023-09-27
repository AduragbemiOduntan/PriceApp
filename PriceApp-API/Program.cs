using Microsoft.AspNetCore.Mvc.ApiExplorer;
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

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();
/*builder.Services.ConfigureSwaggerAuth();*/

// Configure the API versioning properties of the project. 
builder.Services.AddApiVersioningConfigured();

// Add a Swagger generator and Automatic Request and Response annotations:
builder.Services.AddSwaggerSwashbuckleConfigured();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable middleware to serve the generated OpenAPI definition as JSON files.
    app.UseSwagger();

    // Enable middleware to serve Swagger-UI (HTML, JS, CSS, etc.) by specifying the Swagger JSON files(s).
    var descriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

    app.UseSwaggerUI(options =>
    {
        // Build a swagger endpoint for each discovered API version
        foreach (var description in descriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}
else if (app.Environment.IsProduction())
{
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PriceApp V1");
        c.RoutePrefix = "documentation";  // Set Swagger UI at apps root    
    });
    /*app.UseHsts();*/
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
