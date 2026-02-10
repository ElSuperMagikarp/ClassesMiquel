using Microsoft.Extensions.Configuration;
using StoreProject.Infraestructure.Services;
using StoreProject.Application.EndPoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Configuració
builder.Configuration
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// JSON Web Token

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(builder.Configuration["Jwt:JwtSecretKey"]!)
                ),

            ValidateIssuer = true,
            ValidIssuer = "demo",

            ValidateAudience = true,
            ValidAudience = "public",

            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromSeconds(30)
        };
    });

builder.Services.AddAuthorization();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
DatabaseConnection dbConn = new DatabaseConnection(connectionString);

WebApplication webApp = builder.Build();

// Registra els endpoints en un mètode separat
webApp.MapProductEndpoints(dbConn);
webApp.MapProductFamilyEndpoints(dbConn);
webApp.MapShoppingCartEndpoints(dbConn);
webApp.MapShoppingCartProductEndpoints(dbConn);

webApp.Run();
