using Microsoft.Playwright;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic;
    public class FindElement : IFindElement
    {
    protected FindElement(){}
    public async Task<IReadOnlyList<ILocator>> FindElementContainerOnPage(IPage page)
    {
        IReadOnlyList<ILocator> elements = await page.Locator(".question").AllAsync();
        if(elements is null)
        {
            throw new NullReferenceException();
        }
        return elements;
    }
    public static FindElement CreateElementFinder()
    {
        return new FindElement();
    }

    }
