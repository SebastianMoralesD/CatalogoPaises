using CatalogoPaises.DB;
using CatalogoPaises.Service.Contrato;
using CatalogoPaises.Service.Implementacion;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddScoped<IPaisesService, PaisesService>();
builder.Services.AddScoped<IHotelService, HotelesService>();
builder.Services.AddScoped<IRestauranteService, RestauranteService>();



builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CatalogoPaisesContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

string cors = "CorsConfig";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: cors, policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors(cors);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
