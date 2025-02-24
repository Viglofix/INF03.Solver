using Inf03.Solver.Business.PlayWrightBusinessLogic.BaseInterfaces;
using Inf03.Solver.Business.PlayWrightBusinessLogic.DbContextLogic;
using Inf03.Solver.Business.PlayWrightBusinessLogic.TitleElementLogic;
using Inf03.Solver.DataAccess.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Playwright;

namespace Inf03.Solver.Tests.POM;
public class GetTitleElementFromQuestionContainerPage
{
    private readonly IPage _page;
    private readonly IFindElement _findElement;
    private readonly IFoundTitleElementService _foundElementService;
    private readonly IDbContextTitleOperation _dbContextTitleOperation;
    private readonly ExamDbContext _examDbContext;

    public GetTitleElementFromQuestionContainerPage(IPage page)
    {
        // Arrange
        _page = page;
        _findElement = new FindElement();
        _foundElementService = new FoundTitleElementService(new DistanceFromTheSignGraterThan(),_findElement);
        _examDbContext = new ExamDbContext(new DbContextOptionsBuilder<ExamDbContext>().UseNpgsql(ExamDbContextService.CreateExamDbContextService().JsonConnectionStringDeserialize()).Options);
        _dbContextTitleOperation = new TitleDbContextOperation(_findElement,_foundElementService, _examDbContext);
    }

    public async Task AddDataToDatabase()
    {
        await _dbContextTitleOperation.AddDataToDatabase(_page);
    }
    public async Task GetFoundDataFromWeb()
    {
        await foreach(var element in _dbContextTitleOperation.GetFoundDataFromWeb(_page))
        {
           await TestContext.Out.WriteLineAsync(element);
        }
    }
}
