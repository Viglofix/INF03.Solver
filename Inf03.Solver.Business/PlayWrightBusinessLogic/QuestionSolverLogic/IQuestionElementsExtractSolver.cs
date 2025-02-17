using Microsoft.Playwright;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic.QuestionSolverLogic;
    public interface IQuestionElementsExtractSolver
    {
        public Task<List<string>> ExtractValuesFromQuestionContainer(IPage page);
    }
