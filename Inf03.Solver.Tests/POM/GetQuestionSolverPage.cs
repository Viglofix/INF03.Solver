using Inf03.Solver.Business.PlayWrightBusinessLogic.BaseInterfaces;
using Inf03.Solver.Business.PlayWrightBusinessLogic.QuestionSolverLogic;
using Inf03.Solver.Business.PlayWrightBusinessLogic.TitleElementLogic;
using Inf03.Solver.DataAccess.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Playwright;

namespace Inf03.Solver.Tests.POM;
public class GetQuestionSolverPage
{
    private readonly IPage _page;
    private readonly IFindElement _findElement;
    private readonly IFoundTitleElementService _foundTitleElementService;
    private readonly IQuestionElementsExtractSolver _questionSolver;
    private readonly ExamDbContext _examDbContext;

    public GetQuestionSolverPage(IPage page)
    {
        _page = page;
        _findElement = new FindElement();
        _foundTitleElementService = new FoundTitleElementService(new DistanceFromTheSignGraterThan());
        _examDbContext = new ExamDbContext(new DbContextOptionsBuilder<ExamDbContext>().UseNpgsql(ExamDbContextService.CreateExamDbContextService().JsonConnectionStringDeserialize()).Options);
        _questionSolver = new QuestionElementsExtractSolver(_foundTitleElementService,_findElement,_examDbContext);
    }

    public async Task Dispaly_MatchedData_FromDataBase_And_Page()
    {
        foreach(var titleElement in await _questionSolver.ExtractValuesFromQuestionContainer(_page))
        {
           await TestContext.Out.WriteLineAsync(titleElement);
           Assert.NotNull(titleElement);
        }
    }
    public async Task Solve_Quiz_Automation()
    {
        QuestionElementsBotSolver bot = new QuestionElementsBotSolver(_foundTitleElementService,_findElement,_examDbContext,_questionSolver);
        await bot.CompleteTheQuestions(_page);
    }
}
