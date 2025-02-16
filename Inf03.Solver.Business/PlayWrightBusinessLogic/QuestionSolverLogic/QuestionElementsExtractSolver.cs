using Inf03.Solver.Business.PlayWrightBusinessLogic.BaseInterfaces;
using Inf03.Solver.Business.PlayWrightBusinessLogic.TitleElementLogic;
using Inf03.Solver.DataAccess.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Playwright;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic.QuestionSolverLogic;
public class QuestionElementsExtractSolver : IQuestionElementsExtractSolver
{
    private readonly IFindElement _findElement;
    private readonly IFoundTitleElementService _foundTitleElementService;
    private readonly ExamDbContext _examDbContext;
    public QuestionElementsExtractSolver(IFoundTitleElementService foundTitleElementService,IFindElement findElement,ExamDbContext examDbContext)
    {
        _foundTitleElementService = foundTitleElementService;
        _findElement = findElement;
        _examDbContext = examDbContext;
    }
    public async IAsyncEnumerable<(string,string)> ExtractValuesFromQuestionContainer(IPage page)
    {
        var container = await _findElement.FindElementContainerOnPage(page);
        var titleFromDbContext = await _examDbContext.exam.ToListAsync();

        // yeild async appplied. this approach repleaces templList method

        await foreach(var element2 in _foundTitleElementService.GetFoundElementContent(container))
        {
            foreach(var dbElement in titleFromDbContext)
            {
                if (element2!.Contains(dbElement.Title!))
                {
                    yield return (dbElement.Title!,dbElement.CorrectAnswer!);
                }
            }
        }
    }
}
