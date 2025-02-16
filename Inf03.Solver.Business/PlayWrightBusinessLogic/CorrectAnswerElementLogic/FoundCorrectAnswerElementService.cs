using Inf03.Solver.Business.Extensions;
using Microsoft.Playwright;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic.CorrectAnswerElementLogic;
public class FoundCorrectAnswerElementService : IFoundCorrectAnswerElementService
{
    private readonly (string,string) _indexContent = ("<div class=\"answer  correct\">", "</div>");
    private readonly string _strongTag = "</strong>";
    public async IAsyncEnumerable<string> GetFoundElementContent(IReadOnlyList<ILocator> locators)
    {
        int index = 0;

        foreach (var element in locators)
        {
            index++;
            var correctAnswer = await element.InnerHTMLAsync();
            int startIndex = correctAnswer.IndexOf(_indexContent.Item1) + _indexContent.Item1.Length;
            var correctAnswerStartIndexTrimed = correctAnswer.Substring(startIndex);

            var correctAnswerTrimed = correctAnswerStartIndexTrimed.Substring2(correctAnswerStartIndexTrimed.IndexOf(_strongTag) + _strongTag.Length,correctAnswerStartIndexTrimed.IndexOf(_indexContent.Item2));
            yield return correctAnswerTrimed;
        }
    }
}