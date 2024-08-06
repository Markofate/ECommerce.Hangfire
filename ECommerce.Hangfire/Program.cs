using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Repositories;
using Hangfire;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ECommerceDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

builder.Services.AddSingleton<ICategoryService, CategoryService>();
builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();

builder.Services.AddSingleton<IOrderProductService, OrderProductService>();
builder.Services.AddSingleton<IOrderProductRepository, OrderProductRepository>();

builder.Services.AddSingleton<IOrderService, OrderService>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();

builder.Services.AddSingleton<IFavoriteService, FavoriteService>();
builder.Services.AddSingleton<IFavoriteRepository, FavoriteRepository>();

builder.Services.AddSingleton<IProductPhotoService, ProductPhotoService>();
builder.Services.AddSingleton<IProductPhotoRepository, ProductPhotoRepository>();

builder.Services.AddSingleton<ICartService, CartService>();
builder.Services.AddSingleton<ICartRepository, CartRepository>();

builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();

builder.Services.AddSingleton<ICartProductService, CartProductService>();
builder.Services.AddSingleton<ICartProductRepository, CartProductRepository>();

builder.Services.AddSingleton<IJobService, JobService>();

builder.Services.AddHangfire((sp, conf) =>
{
    var ConncetionString = sp.GetRequiredService<IConfiguration>().GetConnectionString("HangfireDb");

    conf.UseSqlServerStorage(ConncetionString);

});
builder.Services.AddHangfireServer();

var app = builder.Build();

app.UseHangfireDashboard("/hangfire");

var productService = app.Services.GetRequiredService<IProductService>();
RecurringJob.AddOrUpdate("increase-stocks", () => productService.IncreaseStockDaily(), "1 0 * * *");
RecurringJob.AddOrUpdate("increase-price",() => productService.IncreasePriceDaily(), "1 0 * * *");

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
