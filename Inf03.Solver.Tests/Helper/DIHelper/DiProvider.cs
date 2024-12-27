using Inf03.Solver.Business.PlayWrightBusinessLogic;
using Inf03.Solver.DataAccess.Db;
using Microsoft.Extensions.DependencyInjection;

namespace Inf03.Solver.Tests.Helper.DIHelper;
    public class DiProvider
    {
    private static IServiceProvider Provider() 
    {
        var services  = new ServiceCollection();

        services.AddScoped<IFindElement,FindElement>();
        services.AddScoped<IFoundElementService, FoundTitleElementService>();

        services.AddDbContext<ExamDbContext>();

        return services.BuildServiceProvider();
    }
    public static T GetRequiredService<T>()
    {
        var provider = Provider();
        return provider.GetRequiredService<T>();
    }

    }
