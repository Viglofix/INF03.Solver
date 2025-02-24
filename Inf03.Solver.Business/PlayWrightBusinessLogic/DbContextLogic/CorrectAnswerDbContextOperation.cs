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
                throw new NullReferenceException("Null reference in the database definition has been found");
            }
            List<string> listOfCorrectAnswersFromPage = await _foundElementService.GetFoundElementContent(page).ToListAsync();
            var listOfCorrectAnswers = await _examDbContext.exam.
                     OrderBy(x => x.Id)
                     .ToListAsync();

            int index = 0; 
            listOfCorrectAnswers.ForEach(x => x.CorrectAnswer = listOfCorrectAnswersFromPage[index++]);
            await _examDbContext.SaveChangesAsync();
        }
        catch (IndexOutOfRangeException ex)
        {
            throw new Exception("Please set the value of index variable to 0 otherwise the index fetch up out of context ||" + ex.Message);
        }
    }
    }
