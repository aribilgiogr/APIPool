using Business;

var builder = WebApplication.CreateBuilder(args);

//RestAPI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddShelfDataConnection(builder.Configuration);

var app = builder.Build();

app.MapControllers();

app.Run();
