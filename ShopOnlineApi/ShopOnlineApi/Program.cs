using Microsoft.EntityFrameworkCore;
using ShopOnlineApi.Data;
using ShopOnlineApi.Interfaces;
using ShopOnlineApi.ModelsSQL;
using ShopOnlineApi.Repositories;
using ShopOnlineApi.Repositories.Interfaces;
using ShopOnlineApi.Services;
using ShopOnlineApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
string dataBaseChose = "SQLL";


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IAdressRepository, AdressRepository>();
builder.Services.AddTransient<IAdressService, AdressService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IContactService, ContactService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();
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
