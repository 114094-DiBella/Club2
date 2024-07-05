using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebApplication1.Data;
using WebApplication1.Interfaces.IRepository;
using WebApplication1.Interfaces.IService;
using WebApplication1.Mapper;
using WebApplication1.Repositories;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("cauth2", new OpenApiSecurityScheme
    {
        Description = "Authentication wtih bearer",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
});



builder.Services.AddDbContext<ContextDb>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDatabase"));
});


//Service dependencias
builder.Services.AddScoped<IUserRepository, UsuarioRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDocenteRepository, DocenteRepository>();
builder.Services.AddScoped<IDocenteService, DocenteService>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<ICursoService, CursoService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddDbContext<ContextDb>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDatabase"));
});

var token = builder.Configuration.GetSection("JwtSettings:Token");

var jwtSettingsSection = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSetting>(jwtSettingsSection);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token.Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
