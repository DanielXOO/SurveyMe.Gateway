using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddCors();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(options => options
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

await app.UseOcelot();

app.Run();