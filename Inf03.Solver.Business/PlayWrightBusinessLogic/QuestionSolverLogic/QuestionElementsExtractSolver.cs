using Inf03.Solver.Business.PlayWrightBusinessLogic.BaseInterfaces;
using Inf03.Solver.Business.PlayWrightBusinessLogic.TitleElementLogic;
using Inf03.Solver.DataAccess.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Playwright;
using System.Diagnostics;

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
    public async IAsyncEnumerable<string> ExtractValuesFromQuestionContainer(IPage page)
    {
        // yeild async appplied. this approach repleaces templList method

        await foreach(var element2 in _foundTitleElementService.GetFoundElementContent(page))
        {
            int index = 0;
            foreach(var dbElement in await _examDbContext.exam.ToListAsync())
            {
                if (element2.Equals(dbElement.Title!))
                {
                    yield return dbElement.CorrectAnswer!;
                    break;
                }
                index++;
                if (index == 1119)
                {
                    Debug.WriteLine(dbElement.CorrectAnswer);
                    Debug.WriteLine(element2);
                    Debug.WriteLine(dbElement.Title);
                }
            }
        }
    }
}
