using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SquareService.Domain;
using SquareService.Domain.DomainServices.SquaringService;
using SquareService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<PointListContext>(options =>
    options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=YourDatabaseName;Trusted_Connection=True;"));
builder.Services.AddScoped<ISquareFindingService, SquareFindingService>();
builder.Services.AddScoped<IPointListRepository, PointListRepository>();
builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped<ISquareFindingService, SquareFindingService>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<PointListContext>();
    dataContext.Database.Migrate();
}

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