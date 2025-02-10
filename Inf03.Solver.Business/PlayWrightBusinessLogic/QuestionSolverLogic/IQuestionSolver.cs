using Inf03.Solver.DataAccess.Model;
using Microsoft.Playwright;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic.QuestionSolverLogic;
    public interface IQuestionSolver
    {
        public IAsyncEnumerable<string> Operation(IPage page);
    }
