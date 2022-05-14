using CorneliusCup.Golf.API.Entities;
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

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var corneliusCupDatabase = builder.Configuration.GetConnectionString("CorneliusCupDatabase");
builder.Services.AddDbContext<CorneliusCupDbContext>(options => options.UseNpgsql(corneliusCupDatabase));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Run database migrations
using (var Scope = app.Services.CreateScope())
{
    var context = Scope.ServiceProvider.GetRequiredService<CorneliusCupDbContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
