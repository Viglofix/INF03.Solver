using Microsoft.Playwright;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic;
    public interface IFindElement
    {
    Task<IReadOnlyList<ILocator>> FindElementContainerOnPage(IPage page);
    }
