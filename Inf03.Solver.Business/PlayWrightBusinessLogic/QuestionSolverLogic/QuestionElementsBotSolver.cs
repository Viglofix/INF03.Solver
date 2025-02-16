using Inf03.Solver.Business.PlayWrightBusinessLogic.BaseInterfaces;
using Inf03.Solver.Business.PlayWrightBusinessLogic.TitleElementLogic;
using Inf03.Solver.DataAccess.Db;
using Microsoft.Playwright;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic.QuestionSolverLogic;
    public class QuestionElementsBotSolver 
    {
         private readonly IFindElement _findElement;
         private readonly IFoundTitleElementService _foundTitleElementService;
         private readonly IQuestionElementsExtractSolver _questionElementsExtractSolver;
         private readonly ExamDbContext _examDbContext;
         public QuestionElementsBotSolver(IFoundTitleElementService foundTitleElementService, IFindElement findElement, ExamDbContext examDbContext, IQuestionElementsExtractSolver questionElementsExtractSolver)
         {
             _foundTitleElementService = foundTitleElementService;
             _findElement = findElement;
             _examDbContext = examDbContext;
             _questionElementsExtractSolver = questionElementsExtractSolver;
         }

        public async Task CompleteTheQuestions(IPage page)
        {
            await foreach(var (titleElement,correctAnswerElement) in _questionElementsExtractSolver.ExtractValuesFromQuestionContainer(page))
            {
                await page.GetByRole(AriaRole.Checkbox, new() { Name = correctAnswerElement }).CheckAsync();
            }   
        }
    }
