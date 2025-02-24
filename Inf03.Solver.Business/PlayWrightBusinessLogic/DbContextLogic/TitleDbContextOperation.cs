using Inf03.Solver.Business.PlayWrightBusinessLogic.BaseInterfaces;
using Inf03.Solver.Business.PlayWrightBusinessLogic.TitleElementLogic;
using Inf03.Solver.DataAccess.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Playwright;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic.DbContextLogic;
public class TitleDbContextOperation : IDbContextTitleOperation
{
    private readonly IFindElement _findElement;
    private readonly IFoundTitleElementService _foundElementService;
    private readonly ExamDbContext _examDbContext;
    public TitleDbContextOperation(IFindElement findElement, IFoundTitleElementService foundElementService, ExamDbContext examDbContext)
    {
        _foundElementService = foundElementService;
        _findElement = findElement;
        _examDbContext = examDbContext;
    }
    public async Task AddDataToDatabase(IPage page)
    {
        List<string> listOfTitles = await _foundElementService.GetFoundElementContent(page).ToListAsync();
        if (_examDbContext is not null && !await _examDbContext.exam.AnyAsync())
        {
            listOfTitles.ForEach(async _listElement =>
            {
                await _examDbContext.exam.AddAsync(new() { Title = _listElement });
            });
            await _examDbContext.SaveChangesAsync();
        }
    }
    public async IAsyncEnumerable<string> GetFoundDataFromWeb(IPage page)
    {
        await foreach (var element in _foundElementService.GetFoundElementContent(page))
        {
            yield return element;
        }
    }
}
