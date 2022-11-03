using Microsoft.EntityFrameworkCore;
using ShopOnlineApi.Data;

var builder = WebApplication.CreateBuilder(args);
string dataBaseChose = "SQLL";


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (dataBaseChose != "SQL")
{
    builder.Services.AddDbContext<ShopContext>(opt => opt.UseInMemoryDatabase("ShopOnlineList"));
}
else
{
    builder.Services.AddDbContext<ShopContext>(op => op.UseNpgsql(builder.Configuration.GetConnectionString("ShopContext")));
}
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
