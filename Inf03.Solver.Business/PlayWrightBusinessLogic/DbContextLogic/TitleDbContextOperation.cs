using Inf03.Solver.Business.PlayWrightBusinessLogic.BaseInterfaces;
using Inf03.Solver.Business.PlayWrightBusinessLogic.TitleElementLogic;
using Inf03.Solver.DataAccess.Db;
using Inf03.Solver.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Playwright;
using System.Web;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic.DbContextLogic;
public class TitleDbContextOperation : IDbContextOperation
{
    private readonly string _sequenceRestartQuery = "ALTER SEQUENCE exam_id_seq RESTART WITH 1;";

    private readonly IFindElement _findElement;
    private readonly IFoundTitleElementService _foundElementService;
    private readonly ExamDbContext _examDbContext;
    public TitleDbContextOperation(IFindElement findElement, IFoundTitleElementService foundElementService, ExamDbContext examDbContext)
    {
        _foundElementService = foundElementService;
        _findElement = findElement;
        _examDbContext = examDbContext;
    }
    public async Task<IList<Inf03QuestionModel>> AddDataToDatabase(IPage page)
    {
        var container = await _findElement.FindElementContainerOnPage(page);

        // here async yield to apply 
        IList<Inf03QuestionModel> model = new List<Inf03QuestionModel>();

        await foreach (var element in _foundElementService.GetFoundElementContent(container))
        {
            var decodedHTMLelement = HttpUtility.HtmlDecode(element);
            model.Add(new Inf03QuestionModel() { Title = decodedHTMLelement });
        }

        if (_examDbContext is null)
        {
            throw new NullReferenceException("Null reference in the database definition has been found");
        }

        if (!await _examDbContext.exam.AnyAsync())
        {
            _examDbContext.exam.FromSqlRaw(_sequenceRestartQuery);
            await _examDbContext.AddRangeAsync(model);
            await _examDbContext.SaveChangesAsync();
        }

        return model;

    }
}
