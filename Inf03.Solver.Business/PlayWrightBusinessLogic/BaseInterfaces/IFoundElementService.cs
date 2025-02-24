using Microsoft.Playwright;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic.BaseInterfaces;
public interface IFoundElementService
{
    IAsyncEnumerable<string> GetFoundElementContent(IPage page);
}
