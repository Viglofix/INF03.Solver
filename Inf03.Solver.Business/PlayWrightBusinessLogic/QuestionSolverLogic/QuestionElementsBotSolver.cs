using Inf03.Solver.Business.PlayWrightBusinessLogic.BaseInterfaces;
using Inf03.Solver.Business.PlayWrightBusinessLogic.TitleElementLogic;
using Inf03.Solver.DataAccess.Db;
using Microsoft.Playwright;

using Inf03.Solver.Business.PlayWrightBusinessLogic.CorrectAnswerElementLogic;

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
            List<string> list = await _questionElementsExtractSolver.ExtractValuesFromQuestionContainer(page);
            foreach (var correctAnswerElement in list)
            {
               ILocator question = page.Locator(".question").Nth(index++);
               await question.GetByLabel(correctAnswerElement).First.ClickAsync();
            }
            page.GetByRole(AriaRole.Button, new() { Name = "Sprawdź odpowiedzi!" });
            await page.ScreenshotAsync(new()
            {
             Path = "screenshot.png"
            });
    }
    }
