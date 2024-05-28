using EnterprisePatterns.DbContexts;
using EnterprisePatterns.DemoServices;
using EnterprisePatterns.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        // register services for DI
        services.AddLogging(configure => configure.AddDebug().AddConsole());

        services.AddDbContext<OrderDbContext>(o => o.UseSqlite("Data Source=Orders.db;"));

        services.AddScoped<RepositoryDemoService>();
        services.AddScoped<UnitOfWorkDemoService>(); 

    }).Build();


// For demo purposes: overall catch-all to log any exception that might 
// happen to the console & wait for key input afterwards so you can easily 
// inspect the issue.  
try
{
    var logger = host.Services.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Host created.");

    // Run a demo service
    await host.Services.GetRequiredService<RepositoryDemoService>().RunAsync(); 
}
catch (Exception generalException)
{
    // log the exception
    var logger = host.Services.GetRequiredService<ILogger<Program>>();
    logger.LogError(generalException,
        "An exception happened while running the integration service.");
}

Console.ReadKey();
await host.RunAsync();