using Microsoft.Playwright;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic;
    public interface IFoundElementService
    {
        Task<IList<string>> GetFoundElementContent(IReadOnlyList<ILocator> locators);
    }
