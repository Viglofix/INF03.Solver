using Inf03.Solver.Business;
using Inf03.Solver.Business.BusinessLogic;

namespace Inf03.Solver;
public class App
{
    public async Task Run(string[] args)
    {
        QuestionDataBaseService questionDataBaseService = new QuestionDataBaseService();
        questionDataBaseService.Init();
    }
}
