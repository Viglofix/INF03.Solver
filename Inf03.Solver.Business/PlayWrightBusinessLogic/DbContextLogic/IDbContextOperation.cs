using Inf03.Solver.DataAccess.Model;
using Microsoft.Playwright;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic.DbContextLogic
{
    public interface IDbContextOperation
    {
        Task<IList<Inf03QuestionModel>> AddDataToDatabase(IPage page);
    }
}
