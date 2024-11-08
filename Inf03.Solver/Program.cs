namespace Inf03.Solver.DataAccess;
internal class Program
{
    static void Main(string[] args)
    {
        var startup = Startup.CreateStartup();
        startup.AsyncStartUpManager(args).GetAwaiter().GetResult();
    }
}