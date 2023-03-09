using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.IServices;
using BEBarberShop.Persistence.Context;
using BEBarberShop.Persistence.Repositories;
using BEBarberShop.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/*CONEXION*/

builder.Services.AddDbContext<AplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));



/*SERVICIOS*/
builder.Services.AddScoped<IUsuarioService,UsuarioService>();



/*REPOSITORY*/
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

/*CORS*/

builder.Services.AddCors(options => options.AddPolicy("AllowWebApp", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowWebApp");//CORS

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
