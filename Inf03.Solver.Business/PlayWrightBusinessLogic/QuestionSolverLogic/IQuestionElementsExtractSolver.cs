using Microsoft.Playwright;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic.QuestionSolverLogic;
    public interface IQuestionElementsExtractSolver
    {
        public IAsyncEnumerable<string> ExtractValuesFromQuestionContainer(IPage page);
    }
