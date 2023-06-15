using Application.StartApplication;
using Domain.StarshipsInformationsDomain.Port;
using Infrastructure.StarshipInformationsServiceInfra;
using Infrastructure.StarshipInformationsServiceInfra.Port;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//var app = new App();

//app.Start();

IHost _host = Host.CreateDefaultBuilder().ConfigureServices(
    services =>
    {
        services.AddSingleton<IStarshipInformationService, StarshipInformationsService>();
    })
    .Build();

var service = _host.Services.GetRequiredService<IStarshipInformationService>();

var result = await service.GetBydId(9);


Console.WriteLine(result.ToString());