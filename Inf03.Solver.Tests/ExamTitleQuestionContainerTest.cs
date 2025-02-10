using Inf03.Solver.Tests.POM;

namespace Inf03.Solver.Tests;

[TestFixture]
internal class ExamTitleQuestionContainerTest : StartUpExamDataBaseInitializationTest
{

    private GetTitleElementFromQuestionContainerPage getElementFromContainerPage;

    [SetUp]
    public void InitExamDataBaseConnectionTest()
    {
        getElementFromContainerPage = new GetTitleElementFromQuestionContainerPage(Page);
    }

    [Test]
    public async Task AddTitleElemntsToDataBase_DisplayTitles()
    {
        await getElementFromContainerPage.AddTitleElemntsToDataBase_DisplayTitles();
    }
}