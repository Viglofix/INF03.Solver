using Microsoft.Playwright;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic.BaseInterfaces;
public interface IFindElement
{
    Task<IReadOnlyList<ILocator>> FindElementContainerOnPage(IPage page);
}
