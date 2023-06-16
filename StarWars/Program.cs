using Application.StartApplication;
using Infrastructure.StarshipInformationsServiceInfra;
using Infrastructure.StarshipInformationsServiceInfra.Port;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost _host = Host.CreateDefaultBuilder().ConfigureServices(
    services =>
    {
        services.AddSingleton<IStarshipInformationService, StarshipInformationsService>();
    })
    .Build();

var service = _host.Services.GetRequiredService<IStarshipInformationService>();

await service.GetBydId(9);

var app = new App(service);

await app.Start();