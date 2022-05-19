using CorneliusCup.Golf.API;
using CorneliusCup.Golf.API.Entities;
using CorneliusCup.Golf.API.Services;
using CorneliusCup.Golf.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add main appsettings.json first
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
if (!builder.Environment.IsDevelopment())
{
    // Add app settings as added by helm
    builder.Configuration.AddJsonFile("appsettings.Kubernetes.json", optional: true, reloadOnChange: true);
}
else
{
    // Add dev app settings
    builder.Configuration.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);
}

// Add services to the container.
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

builder.Services.AddControllers().AddJsonOptions(options => 
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var corneliusCupDatabase = builder.Configuration.GetConnectionString("CorneliusCupDatabase");
builder.Services.AddDbContext<CorneliusCupDbContext>(options => options.UseNpgsql(corneliusCupDatabase));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(options => 
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

builder.Services.AddTransient<IVenueService, VenueService>();
builder.Services.AddTransient<IPlayerService, PlayerService>();

var app = builder.Build();

// Run database migrations
using (var Scope = app.Services.CreateScope())
{
    var context = Scope.ServiceProvider.GetRequiredService<CorneliusCupDbContext>();
    context.Database.Migrate();
}

var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    foreach (var description in provider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
    }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
