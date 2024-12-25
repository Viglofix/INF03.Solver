using Microsoft.Playwright.NUnit;
using Inf03.Solver.Business.PlayWrightBusinessLogic;
using Inf03.Solver.Business.Extensions;
using Inf03.Solver.DataAccess;
using Inf03.Solver.DataAccess.Db;

namespace Inf03.Solver.Tests;

[TestFixture]
public class Tests : PageTest {

    private IFindElement _findElement;
    private IFoundElementService _foundElementService;

    [SetUp]
    public async Task SetUp()
    {
        // Arrange
        await Page.GotoAsync("https://www.praktycznyegzamin.pl/inf03ee09e14/teoria/wszystko/");
        _findElement = FindElement.CreateElementFinder();
        _foundElementService = FoundTitleElementService.CreateFoundTitleElementService();
    }
    [Test]
    public async Task PassBrowser_ReturnWebElement()
    {
        //Act
       /*  var elements = await _findElement.FindElementContainerOnPage(Page);
        var title = await _foundElementService.GetFoundElementContent(elements);
        foreach(var element in title)
        {
            Console.WriteLine(element);
        } */

        string examDbContextService = await new ExamDbContextService().JsonConnectionStringDeserialize();
        await TestContext.Out.WriteLineAsync(examDbContextService);

        // Assert
   //     Assert.IsNotNull(elements);
    }
}