using GameStore.api.Data;
using GameStore.api.Endpoints;
using GameStore.api.Repositories;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddScoped<IGamesReposity, InMemGamesRepository>(); // every time IGamesReposity is requested, a new instance of InMemGamesRepository is created 

builder.Services.AddSingleton<IGamesReposity, InMemGamesRepository>(); // only one instance of InMemGamesRepository is created and shared across all requests

var connString = builder.Configuration.GetConnectionString("GameStoreContext"); // get connection string from appsettings.json

builder.Services.AddSqlServer<GameStoreContext>(connString); // add db context to services

var app = builder.Build();

// -------------- Route Grouping -----------------------------------------------------
// var group = app.MapGroup("/games")
//                 .WithParameterValidation(); // Enable parameter validation for all routes in this group(comes from miniapis package)



// create a scope to get a GameStoreContext instance and apply any pending migrations to the database
app.Services.InitializeDb();

app.MapGamesEndpoints(); // after using route group



app.Run();
