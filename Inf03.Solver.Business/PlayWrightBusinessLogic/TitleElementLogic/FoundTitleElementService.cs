using Inf03.Solver.Business.Extensions;
using Inf03.Solver.Business.PlayWrightBusinessLogic.BaseInterfaces;
using Microsoft.Playwright;
using System.Web;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic.TitleElementLogic;
public class FoundTitleElementService : IFoundTitleElementService
{
    private readonly (string, string) _indexContent = ("<div class=\"title\">", "</div>");
    private readonly DistanceFromTheSignGraterThan _distanceFromTheSignGraterThan;
    private readonly IFindElement _findElement;
    public FoundTitleElementService(DistanceFromTheSignGraterThan distanceFromTheSignGraterThan,IFindElement findElement)
    {
        _distanceFromTheSignGraterThan = distanceFromTheSignGraterThan;
        _findElement = findElement;
    }
    public async IAsyncEnumerable<string> GetFoundElementContent(IPage page)
    {
        int index = 0;
        foreach (var element in await _findElement.FindElementContainerOnPage(page))
        {
            index++;
            int startIndex = 0;
            var title = await element.InnerHTMLAsync();

            if (index < 10)
            {
                startIndex = title.IndexOf(_indexContent.Item1) + _indexContent.Item1.Length + _distanceFromTheSignGraterThan._distanceFromTheSignGraterThanOneDigit;
            }
            else if(index >= 10 && index < 100)
            {
                startIndex = title.IndexOf(_indexContent.Item1) + _indexContent.Item1.Length + _distanceFromTheSignGraterThan._distanceFromTheSignGraterThanTwoDigit;
            }
            else if(index >= 100 && index < 1000)
            {
                startIndex = title.IndexOf(_indexContent.Item1) + _indexContent.Item1.Length + _distanceFromTheSignGraterThan._distanceFromTheSignGraterThanThreeDigit;
            }
            else
            {
                startIndex = title.IndexOf(_indexContent.Item1) + _indexContent.Item1.Length + _distanceFromTheSignGraterThan._distanceFromTheSignGraterThanFourDigit;
            }

            int endIndex = title.IndexOf(_indexContent.Item2);
            var titleTrimed = title.Substring2(startIndex, endIndex);
            var titleTrimedHtmlDecoded = HttpUtility.HtmlDecode(titleTrimed);

            yield return titleTrimedHtmlDecoded;
        }
    }
}
