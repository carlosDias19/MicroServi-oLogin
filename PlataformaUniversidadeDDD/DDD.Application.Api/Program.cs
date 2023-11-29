using ApplicationService.Application;
using ApplicationService.Interface;
using DDD.Infra.SQLServer;
using DDD.Infra.SQLServer.Interfaces;
using DDD.Infra.SQLServer.Repositories;
using DomainService.Interface;
using DomainService.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
//using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Autorização para requisição com o CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder => 
        builder.WithOrigins("*")
               .AllowAnyMethod()
               .AllowAnyHeader());
});

var key = Encoding.ASCII.GetBytes(DDD.Domain.Key.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Add services to the container.

//IOC - Dependency Injection
//builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepositorySqlServer>();

//Dependency Injection Application
builder.Services.AddScoped<IUsuarioApplication, UsuarioApplication>();


//Dependency Injection Service
builder.Services.AddScoped<IUsuarioService, UsuarioService>();



////Dependency Injection SqlContext
builder.Services.AddScoped<SqlContext, SqlContext>();

//builder.Services.AddControllers().AddJsonOptions(x =>
//   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AdmMaster API",
        Version = $"v1",
        Description = "API para consumo de dados do Front em Vue"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Autenticação por token JWT. Entre com o valor no formato: Bearer SEU_TOKEN",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });

}
);


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

////Autorização para requisição CORs
//app.UseCors("corsapp");
//app.UseAuthorization();

//app.UseAuthentication();
//app.UseAuthorization();
app.UseCors("AllowSpecificOrigin");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
