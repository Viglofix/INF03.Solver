using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Inf03.Solver;
public class Startup
{
    private Startup()
    {

    }
    public async Task AsyncStartUpManager(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();
        var scope = host.Services.CreateScope();

        var services = scope.ServiceProvider;

        try
        {
            await services.GetRequiredService<App>().Run(args);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public static Startup CreateStartup()
    {
        return new Startup();
    }
    static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, config) =>
            {
                config.AddSingleton<App>();
            });
    }

}
