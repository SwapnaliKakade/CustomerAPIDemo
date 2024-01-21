using CoreCustomer.Models;
using CustomerRepository.Implementations;
using CustomerRepository.Interfaces;
using CustomerService.Implementations;
using CustomerService.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CodeDB"));
});
builder.Services.AddScoped<DbContext, AppDBContext>();
builder.Services.AddScoped<IRepository<Customer>,Repository<Customer>>();
builder.Services.AddScoped<ICustomerRepository,CustRepository>();
builder.Services.AddScoped<IService<Customer>,Service<Customer>>();

builder.Services.AddScoped<ICustomerService, CustService>();

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
