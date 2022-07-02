using DevInSales.Api.Estatico;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using DevInSales.Core.Data.Context;
using DevInSales.Core.Entities;
using DevInSales.Core.Interfaces;
using DevInSales.Core.Services;
using DevInSales.EFCoreApi.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using DevInSales.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Chave do Secrets do appsetins.json
JWTConfiguracaoAppsetings.Secrets = builder.Configuration.GetValue<string>("JWT:Secret");
JWTConfiguracaoAppsetings.Issuer = builder.Configuration.GetValue<string>("JWT:Issuer");
JWTConfiguracaoAppsetings.Audience = builder.Configuration.GetValue<string>("JWT:Audience");

//Enconding em ASCII da chave Secrets [array de bytes]
JWTConfiguracaoAppsetings.Key = Encoding.ASCII.GetBytes(JWTConfiguracaoAppsetings.Secrets);

/// <summary>
/// Configuração do JWT
/// </summary>
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            ValidIssuer = JWTConfiguracaoAppsetings.Issuer,
            ValidAudience = JWTConfiguracaoAppsetings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(JWTConfiguracaoAppsetings.Key)
        };
    });

builder.Services.AddSingleton<IAuthorizationMiddlewareResultHandler, ExampleAuthorizationMiddlewareResultHandler>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(async swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "JWT Exemplo Criado",
        Description = "JWT Descrição criada"
    });

    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Utilizando JWT Authorization para autenticar"
    });

    var OpenApiReference = new OpenApiReference()
    {
        Type = ReferenceType.SecurityScheme,
        Id = "Bearer"
    };

    var openApiSecurityScheme = new OpenApiSecurityScheme()
    {
        Reference = OpenApiReference
    };

    var openApiSecuryRequeriment = new OpenApiSecurityRequirement()
    {
        {
            openApiSecurityScheme,
            Array.Empty<string>()
        }
    };

    swagger.AddSecurityRequirement(openApiSecuryRequeriment);
});

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection"))
);

builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();
builder.Services.AddScoped<ISaleProductService, SaleProductService>();
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddEndpointsApiExplorer();
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
