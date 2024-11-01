using RTATS.Application.Interfaces;
using RTATS.Infrastructure.Repositories;
using RTATS.Scheduler;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<SchedulerService>();
        //services.AddSingleton<IUnitOfWork>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
    })
    .Build();

await host.RunAsync();
