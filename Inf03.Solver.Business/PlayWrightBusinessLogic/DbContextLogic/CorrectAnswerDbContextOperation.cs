using Inf03.Solver.Business.PlayWrightBusinessLogic.BaseInterfaces;
using Inf03.Solver.Business.PlayWrightBusinessLogic.CorrectAnswerElementLogic;
using Inf03.Solver.DataAccess.Db;
using Inf03.Solver.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Playwright;
using System.Web;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic.DbContextLogic
{
    public class CorrectAnswerDbContextOperation : IDbContextOperation
    {
        private const int indexDefaultValue = 0;

        private readonly IFindElement _findElement;
        private readonly IFoundCorrectAnswerElementService _foundElementService;
        private readonly ExamDbContext _examDbContext;

        public CorrectAnswerDbContextOperation(IFindElement findElement, IFoundCorrectAnswerElementService foundElementService, ExamDbContext examDbContext)
        {
            _foundElementService = foundElementService;
            _findElement = findElement;
            _examDbContext = examDbContext;
        }

        public async Task<IList<Inf03QuestionModel>> AddDataToDatabase(IPage page)
        {
            try
            {
                var container = await _findElement.FindElementContainerOnPage(page);
                int index = indexDefaultValue;

                // Update Correct Answer column in exam table 

                List<string> values = new List<string>();
                await foreach(var item in _foundElementService.GetFoundElementContent(container))
                {
                    values.Add(item);
                }

                await _examDbContext.exam.ForEachAsync(x => x.CorrectAnswer = HttpUtility.HtmlDecode(values[index++]));
                await _examDbContext.SaveChangesAsync();

                if (_examDbContext is null)
                {
                    throw new NullReferenceException("Null reference in the database definition has been found");
                }

                IList<Inf03QuestionModel> inf03QuestionModels = new List<Inf03QuestionModel>();
                return inf03QuestionModels;
            }
            catch(IndexOutOfRangeException ex)
            {
                throw new Exception("Please set the value of index variable to 0 otherwise the index fetch up out of context ||" + ex.Message);
            }
        }
    }
}
