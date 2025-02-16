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
    private readonly IDbContextOperation _dbContextOperation;
    private readonly ExamDbContext _examDbContext;

    public GetTitleElementFromQuestionContainerPage(IPage page)
    {
        // Arrange

        _page = page;
        _findElement = new FindElement();
        _foundElementService = new FoundTitleElementService(new DistanceFromTheSignGraterThan());
        _examDbContext = new ExamDbContext(new DbContextOptionsBuilder<ExamDbContext>().UseNpgsql(ExamDbContextService.CreateExamDbContextService().JsonConnectionStringDeserialize()).Options);
        _dbContextOperation = new TitleDbContextOperation(_findElement,_foundElementService, _examDbContext);
    }

    public async Task AddTitleElemntsToDataBase_DisplayTitles()
    {
        //Act
        var obj = await _dbContextOperation.AddDataToDatabase(_page);
        foreach (var element in obj)
        {
            await TestContext.Out.WriteLineAsync(element.Title);
        }
        // Assert
        Assert.IsNotNull(obj);
    }
}
