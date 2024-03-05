using GameStore.api.Endpoints;



var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// -------------- Route Grouping -----------------------------------------------------
// var group = app.MapGroup("/games")
//                 .WithParameterValidation(); // Enable parameter validation for all routes in this group(comes from miniapis package)

app.MapGamesEndpoints(); // after using route group



app.Run();
