using Microsoft.Playwright;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic.DbContextLogic
{
    public interface IDbContextAddToDbOperation
    {
        Task AddDataToDatabase(IPage page);
    }
}
