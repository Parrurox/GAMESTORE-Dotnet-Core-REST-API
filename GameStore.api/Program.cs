using GameStore.api.Endpoints;
using GameStore.api.Repositories;



var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddScoped<IGamesReposity, InMemGamesRepository>(); // every time IGamesReposity is requested, a new instance of InMemGamesRepository is created 

builder.Services.AddSingleton<IGamesReposity, InMemGamesRepository>(); // only one instance of InMemGamesRepository is created and shared across all requests

var connString = builder.Configuration.GetConnectionString("GameStoreContext"); // get connection string from appsettings.json



var app = builder.Build();

// -------------- Route Grouping -----------------------------------------------------
// var group = app.MapGroup("/games")
//                 .WithParameterValidation(); // Enable parameter validation for all routes in this group(comes from miniapis package)

app.MapGamesEndpoints(); // after using route group



app.Run();
