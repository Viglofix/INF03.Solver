using Inf03.Solver.Business.PlayWrightBusinessLogic.BaseInterfaces;
using Inf03.Solver.Business.PlayWrightBusinessLogic.CorrectAnswerElementLogic;
using Inf03.Solver.Business.PlayWrightBusinessLogic.DbContextLogic;
using Inf03.Solver.DataAccess.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Playwright;

namespace Inf03.Solver.Tests.POM;
public class GetCorrectAnswerElementFromQuestionContainerPage
{
    private readonly IPage _page;
    private readonly IFindElement _findElement;
    private readonly IFoundCorrectAnswerElementService _foundElementService;
    private readonly IDbContextAddToDbOperation _dbContextAddToDbOperation;
    private readonly ExamDbContext _examDbContext;

    public GetCorrectAnswerElementFromQuestionContainerPage(IPage page)
    {
        // Arrange

        _page = page;
        _findElement = new FindElement();
        _foundElementService = new FoundCorrectAnswerElementService(_findElement);
        _examDbContext = new ExamDbContext(new DbContextOptionsBuilder<ExamDbContext>().UseNpgsql(ExamDbContextService.CreateExamDbContextService().JsonConnectionStringDeserialize()).Options);
        _dbContextAddToDbOperation = new CorrectAnswerDbContextOperation(_findElement, _foundElementService, _examDbContext);
    }

    public async Task AddDataToDatabase()
    {
        //Act
        await _dbContextAddToDbOperation.AddDataToDatabase(_page);
    }
}
