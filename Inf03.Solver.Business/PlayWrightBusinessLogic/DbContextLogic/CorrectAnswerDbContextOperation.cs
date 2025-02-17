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
                int index = 1;
                int indexDic = 1;

                // Update Correct Answer column in exam table 


                // Tutaj sie cos correc_answer pojebał i trza naprawić
                Dictionary<int, string> values = new();
                await foreach (var item in _foundElementService.GetFoundElementContent(container))
                {
                    values[indexDic++] = item;
                }

                var list = await _examDbContext.exam
                    .OrderBy(x=>x.Id)
                    .ToListAsync();

                list.ForEach(x => x.CorrectAnswer = HttpUtility.HtmlDecode(values[index++]));

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
