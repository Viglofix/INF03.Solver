using Inf03.Solver.Business.Extensions;
using Inf03.Solver.Business.PlayWrightBusinessLogic.BaseInterfaces;
using Microsoft.Playwright;
using System.Web;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic.CorrectAnswerElementLogic;
public class FoundCorrectAnswerElementService : IFoundCorrectAnswerElementService
{
    private readonly (string,string) _indexContent = ("<div class=\"answer  correct\">", "</div>");
    private readonly string _strongTag = "</strong>";

    private readonly IFindElement _findElement;
    public FoundCorrectAnswerElementService(IFindElement findElement)
    {
        _findElement = findElement;
    }
    public async IAsyncEnumerable<string> GetFoundElementContent(IPage page)
    {
        int index = 0;

        foreach (var element in await _findElement.FindElementContainerOnPage(page))
        {
            index++;
            var correctAnswer = await element.InnerHTMLAsync();
            int startIndex = correctAnswer.IndexOf(_indexContent.Item1) + _indexContent.Item1.Length;
            var correctAnswerStartIndexTrimed = correctAnswer.Substring(startIndex);

            var correctAnswerTrimed = correctAnswerStartIndexTrimed.Substring2(correctAnswerStartIndexTrimed.IndexOf(_strongTag) + _strongTag.Length,correctAnswerStartIndexTrimed.IndexOf(_indexContent.Item2));
            var correctAnswerTrimedHtmlDecoded = HttpUtility.HtmlDecode(correctAnswerTrimed);
            yield return correctAnswerTrimedHtmlDecoded;
        }
    }
}