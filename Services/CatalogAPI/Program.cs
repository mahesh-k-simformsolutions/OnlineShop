using AutoMapper;
using Catalog.Data;
using Catalog.Data.Repository;
using Catalog.Data.Repository.Interface;
using Catalog.ServiceLayer;
using Catalog.ServiceLayer.Interface;
using Catalog.ServiceLayer.Mapping;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CatalogDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("CatalogDbConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Custom Services
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

builder.Services.AddHttpContextAccessor();
MapperConfiguration mappingConfig = new(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

WebApplication? app = builder.Build();

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
