using HotChocolateWebApp;
using Trippin;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton(_ => new Container(new Uri("https://services.odata.org/TripPinRESTierService")));

builder.Services
    .AddGraphQLServer()
    .AddSorting()
    .AddFiltering()
    .AddQueryType<QueryType>()
    ;

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL();

app.Run();
