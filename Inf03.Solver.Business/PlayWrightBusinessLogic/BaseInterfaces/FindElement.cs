using Microsoft.Playwright;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic.BaseInterfaces;
public class FindElement : IFindElement
{
    private readonly string _locatorContainerName = ".question";
    public FindElement() { }

    public async Task<IReadOnlyList<ILocator>> FindElementContainerOnPage(IPage page)
    {
        IReadOnlyList<ILocator> elements = await page.Locator(_locatorContainerName).AllAsync();
        if (elements is null)
        {
            throw new NullReferenceException();
        }
        return elements;
    }

}
