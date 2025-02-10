using Inf03.Solver.Business.Extensions;
using Microsoft.Playwright;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic.TitleElementLogic;
public class FoundTitleElementService : IFoundTitleElementService
{
    private readonly (string, string) _indexContent = ("<div class=\"title\">", "</div>");
    private readonly int _distanceFromTheSignGraterThanOneDigit = 3;
    private readonly int _distanceFromTheSignGraterThanTwoDigit = 4;
    private readonly int _distanceFromTheSignGraterThanThreeDigit = 5;
    private readonly int _distanceFromTheSignGraterThanFourDigit = 6;
    public FoundTitleElementService()
    {
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
                startIndex = title.IndexOf(_indexContent.Item1) + _indexContent.Item1.Length + _distanceFromTheSignGraterThanOneDigit;
            }
            else if(index > 10 && index < 100)
            {
                startIndex = title.IndexOf(_indexContent.Item1) + _indexContent.Item1.Length + _distanceFromTheSignGraterThanTwoDigit;
            }
            else if(index > 100 && index < 1000)
            {
                startIndex = title.IndexOf(_indexContent.Item1) + _indexContent.Item1.Length + _distanceFromTheSignGraterThanThreeDigit;
            }
            else
            {
                startIndex = title.IndexOf(_indexContent.Item1) + _indexContent.Item1.Length + _distanceFromTheSignGraterThanFourDigit;
            }

            int endIndex = title.IndexOf(_indexContent.Item2);
            var titleTrimed = title.Substring2(startIndex, endIndex);

            yield return titleTrimed;
        }
    }
}
