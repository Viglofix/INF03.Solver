using Microsoft.Playwright.NUnit;
using Inf03.Solver.Business.PlayWrightBusinessLogic;
using Inf03.Solver.Business.Extensions;
using Inf03.Solver.DataAccess;
using Inf03.Solver.DataAccess.Db;

namespace Inf03.Solver.Tests;

[TestFixture]
public class ExamDaaBaseConnectionTest : ExamDataBaseConnectionBaseTest {
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