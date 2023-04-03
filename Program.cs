using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.IServices;
using BEBarberShop.Persistence.Context;
using BEBarberShop.Persistence.Repositories;
using BEBarberShop.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/*CONEXION*/

builder.Services.AddDbContext<AplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("ConexionCasa")));



/*SERVICIOS*/
builder.Services.AddScoped<IUsuarioService,UsuarioService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IEstilistaService, EstilistaService>();
builder.Services.AddScoped<IServicioService, ServicioService>();
builder.Services.AddScoped<IReservacionService, ReservacionService>();
builder.Services.AddScoped<ICalendarioReservacionService, CalendarioReservacionService>();



/*REPOSITORY*/
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IEstilistaRepository, EstilistaRepository>();
builder.Services.AddScoped<IServicioRepository, ServicioRepository>();
builder.Services.AddScoped<IReservacionRepository, ReservacionRepository>();
builder.Services.AddScoped<ICalendarioReservacionRepository, CalendarioReservacionRepository>();


/*CORS*/

builder.Services.AddCors(options => options.AddPolicy("AllowWebApp", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));


/*Add Authentication*/
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
{

    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience = builder.Configuration["Jwt:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])),
    ClockSkew = TimeSpan.Zero
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowWebApp");//CORS
app.UseAuthentication();//Authentication

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
