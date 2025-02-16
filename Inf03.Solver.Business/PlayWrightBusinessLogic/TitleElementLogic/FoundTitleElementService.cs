using Inf03.Solver.Business.Extensions;
using Microsoft.Playwright;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic.TitleElementLogic;
public class FoundTitleElementService : IFoundTitleElementService
{
    private readonly (string, string) _indexContent = ("<div class=\"title\">", "</div>");
    private readonly DistanceFromTheSignGraterThan _distanceFromTheSignGraterThan;
    public FoundTitleElementService(DistanceFromTheSignGraterThan distanceFromTheSignGraterThan)
    {
        _distanceFromTheSignGraterThan = distanceFromTheSignGraterThan;
    }
    public async IAsyncEnumerable<string> GetFoundElementContent(IReadOnlyList<ILocator> locators)
    {
        int index = 0;
        foreach (var element in locators)
        {
            index++;
            int startIndex = 0;
            var title = await element.InnerHTMLAsync();

            if (index < 10)
            {
                startIndex = title.IndexOf(_indexContent.Item1) + _indexContent.Item1.Length + _distanceFromTheSignGraterThan._distanceFromTheSignGraterThanOneDigit;
            }
            else if(index > 10 && index < 100)
            {
                startIndex = title.IndexOf(_indexContent.Item1) + _indexContent.Item1.Length + _distanceFromTheSignGraterThan._distanceFromTheSignGraterThanTwoDigit;
            }
            else if(index > 100 && index < 1000)
            {
                startIndex = title.IndexOf(_indexContent.Item1) + _indexContent.Item1.Length + _distanceFromTheSignGraterThan._distanceFromTheSignGraterThanThreeDigit;
            }
            else
            {
                startIndex = title.IndexOf(_indexContent.Item1) + _indexContent.Item1.Length + _distanceFromTheSignGraterThan._distanceFromTheSignGraterThanFourDigit;
            }

            int endIndex = title.IndexOf(_indexContent.Item2);
            var titleTrimed = title.Substring2(startIndex, endIndex);

            yield return titleTrimed;
        }
    }
}
