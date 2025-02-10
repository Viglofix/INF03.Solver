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
    private readonly IQuestionSolver _questionSolver;
    private readonly ExamDbContext _examDbContext;

    public GetQuestionSolverPage(IPage page)
    {
        _page = page;
        _findElement = new FindElement();
        _foundTitleElementService = new FoundTitleElementService();
        _examDbContext = new ExamDbContext(new DbContextOptionsBuilder<ExamDbContext>().UseNpgsql(ExamDbContextService.CreateExamDbContextService().JsonConnectionStringDeserialize()).Options);
        _questionSolver = new QuestionSolver(_foundTitleElementService,_findElement,_examDbContext);
    }

    public async Task Dispaly_MatchedData_FromDataBase_And_Page()
    {
        await foreach(var element in _questionSolver.Operation(_page))
        {
           await TestContext.Out.WriteLineAsync(element);
           Assert.NotNull(element);
        }
    }
}
