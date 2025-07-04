﻿using Inf03.Solver.Business.Extensions;
using Inf03.Solver.Business.PlayWrightBusinessLogic.BaseInterfaces;
using Inf03.Solver.Business.PlayWrightBusinessLogic.Helper;
using Microsoft.Playwright;
using System.Web;

namespace Inf03.Solver.Business.PlayWrightBusinessLogic.TitleElementLogic;
public class FoundTitleElementService : IFoundTitleElementService
{
    private readonly (string, string) _indexContent = ("<div class=\"title\">", "</div>");
    private readonly DistanceFromTheSignGraterThan _distanceFromTheSignGraterThan;
    private readonly IFindElement _findElement;
    private readonly IList<ISpecification> _specifications;
    private const int _indexSmallerThanTen = 0;
    private const int _indexGraterThanTenOrEqualAndSmallerThanHoundred = 1;
    private const int _indexGraterThanHoundredOrEqualAndSmallerThanThousand = 2;
    private const int _indexGraterThanThousand = 3;
    private const int _defaultIndexValue = 0;
    public FoundTitleElementService(DistanceFromTheSignGraterThan distanceFromTheSignGraterThan,IFindElement findElement, IList<ISpecification> specifications)
    {
        _distanceFromTheSignGraterThan = distanceFromTheSignGraterThan;
        _findElement = findElement;
        _specifications = specifications;
    }
    public async IAsyncEnumerable<string> GetFoundElementContent(IPage page)
    {
        int index = _defaultIndexValue;
        int startIndex = _defaultIndexValue;

        foreach (var element in await _findElement.FindElementContainerOnPage(page))
        {
            index++;
            startIndex = _defaultIndexValue;
            var title = await element.InnerHTMLAsync();

            _specifications[_indexSmallerThanTen].OperationAfterAssertion(index, () =>
                startIndex = title.IndexOf(_indexContent.Item1) + _indexContent.Item1.Length + _distanceFromTheSignGraterThan._distanceFromTheSignGraterThanOneDigit);
            _specifications[_indexGraterThanTenOrEqualAndSmallerThanHoundred].OperationAfterAssertion(index, () =>
                startIndex = title.IndexOf(_indexContent.Item1) + _indexContent.Item1.Length + _distanceFromTheSignGraterThan._distanceFromTheSignGraterThanTwoDigit);
            _specifications[_indexGraterThanHoundredOrEqualAndSmallerThanThousand].OperationAfterAssertion(index, () =>
                startIndex = title.IndexOf(_indexContent.Item1) + _indexContent.Item1.Length + _distanceFromTheSignGraterThan._distanceFromTheSignGraterThanThreeDigit);
            _specifications[_indexGraterThanHoundredOrEqualAndSmallerThanThousand].OperationAfterAssertion(index, () =>
                startIndex = title.IndexOf(_indexContent.Item1) + _indexContent.Item1.Length + _distanceFromTheSignGraterThan._distanceFromTheSignGraterThanFourDigit);

            int endIndex = title.IndexOf(_indexContent.Item2);
            var titleTrimed = title.Substring2(startIndex, endIndex);
            var titleTrimedHtmlDecoded = HttpUtility.HtmlDecode(titleTrimed);

            yield return titleTrimedHtmlDecoded;
        }
    }
}
