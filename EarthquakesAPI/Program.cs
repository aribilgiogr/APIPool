using Business;
using Core.Abstracts.IServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomServices();

var app = builder.Build();

app.MapGet("/", async (IEarthquakesService service) => await service.GetEarthquakes());
app.MapGet("/{dt}", async (IEarthquakesService service, DateTime dt) => await service.GetEarthquake(dt));

app.Run();
