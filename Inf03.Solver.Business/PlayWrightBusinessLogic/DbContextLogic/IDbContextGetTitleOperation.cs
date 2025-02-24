using Microsoft.Playwright;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic.DbContextLogic;
    public interface IDbContextGetTitleOperation
    {
        IAsyncEnumerable<string> GetFoundDataFromWeb(IPage page);
    }
