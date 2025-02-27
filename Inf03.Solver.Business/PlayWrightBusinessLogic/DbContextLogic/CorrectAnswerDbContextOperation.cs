using Inf03.Solver.Business.PlayWrightBusinessLogic.BaseInterfaces;
using Inf03.Solver.Business.PlayWrightBusinessLogic.CorrectAnswerElementLogic;
using Inf03.Solver.DataAccess.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Playwright;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic.DbContextLogic;
    public class CorrectAnswerDbContextOperation : IDbContextAddToDbOperation
    {
        private readonly IFoundCorrectAnswerElementService _foundElementService;
        private readonly ExamDbContext _examDbContext;
        private const string? _nullReferenceExceptionMessage = "Null reference in the database definition has been found";
        private const string? _indexOutOfRangeExceptionMessage = "Please set the value of index variable to 0 otherwise the index fetch up out of context ||";
        private const int _defaultIndexValue = 0;
        public CorrectAnswerDbContextOperation(IFindElement findElement, IFoundCorrectAnswerElementService foundElementService, ExamDbContext examDbContext)
        {
            _foundElementService = foundElementService;
            _examDbContext = examDbContext;
        }

    public async Task AddDataToDatabase(IPage page)
    {
        try
        {
            if (_examDbContext is null)
            {
                throw new NullReferenceException(_nullReferenceExceptionMessage);
            }
            List<string> listOfCorrectAnswersFromPage = await _foundElementService.GetFoundElementContent(page).ToListAsync();
            var listOfCorrectAnswers = await _examDbContext.exam.
                     OrderBy(x => x.Id)
                     .ToListAsync();

            int index = _defaultIndexValue; 
            listOfCorrectAnswers.ForEach(x => x.CorrectAnswer = listOfCorrectAnswersFromPage[index++]);
            await _examDbContext.SaveChangesAsync();
        }
        catch (IndexOutOfRangeException ex)
        {
            throw new Exception(_indexOutOfRangeExceptionMessage + ex.Message);
        }
    }
    }
