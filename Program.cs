using RefactorThis.Infrastructure;
using RefactorThis.Infrastructure.Interfaces;
using RefactorThis.Models;
using RefactorThis.Services;
using RefactorThis.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string _strConn = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IProductOptionsService, ProductOptionsService>();
builder.Services.AddScoped<IProductRepository<Product>>(sp =>
{
	return new ProductRepository(_strConn);
});
builder.Services.AddScoped<IProductOptionRepository<ProductOption>>(sp =>
{
	return new ProductOptionRepository(_strConn);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
