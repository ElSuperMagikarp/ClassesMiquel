using Microsoft.Extensions.Configuration;
using StoreProject.Services;
using StoreProject.Application.EndPoints;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Configuració
builder.Configuration
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
DatabaseConnection dbConn = new DatabaseConnection(connectionString);

WebApplication webApp = builder.Build();

// Registra els endpoints en un mètode separat
webApp.MapProductEndpoints(dbConn);
webApp.MapProductFamilyEndpoints(dbConn);
webApp.MapShoppingCartEndpoints(dbConn);
webApp.MapShoppingCartProductEndpoints(dbConn);

webApp.Run();
