using Microsoft.Playwright;
using System.Collections;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic;
public class FoundTitleElementService : IFoundElementService
{
    private const int DistanceFromTheSignGraterThan = 4;
    private const string endIndexContent = "</div>";
    private const char startIndexContent = '>';
    protected FoundTitleElementService() 
    {
    }
    public async Task<IList<string>> GetFoundElementContent(IReadOnlyList<ILocator> locators)
    {
        IList<string> stringsList = new List<string>();

        foreach (var element in locators)
        {
            var title = await element.InnerHTMLAsync();
            int startIndex = title.IndexOf('>') + DistanceFromTheSignGraterThan;
            int endIndex = title.IndexOf("</div>");
            var titleTrimed = title.Substring(startIndex, (endIndex - startIndex));
            stringsList.Add(titleTrimed);
        }
        return stringsList;
    }

    public static FoundTitleElementService CreateFoundTitleElementService()
    {
        return new FoundTitleElementService();
    }
}
