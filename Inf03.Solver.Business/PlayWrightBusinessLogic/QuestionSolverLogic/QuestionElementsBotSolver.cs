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
            int index = 0;
            await foreach (var correctAnswerElement in _questionElementsExtractSolver.ExtractValuesFromQuestionContainer(page))
            {
               ILocator question = page.Locator(".question").Nth(index++);
               await question.GetByLabel(correctAnswerElement).First.ClickAsync();
            }
            await page.GetByRole(AriaRole.Button, new() { Name = "Sprawdź odpowiedzi!" }).ClickAsync();
            await page.ScreenshotAsync(new()
            {
             Path = "screenshot.png"
            });
        }
    }
