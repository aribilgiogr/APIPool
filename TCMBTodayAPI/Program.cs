using Business;
using Core.Abstracts.IServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddCustomServices();

var app = builder.Build();

app.MapGet("/", async (ICurrencyService service) => await service.GetCurrenciesAsync());

app.Run();
