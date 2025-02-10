using Inf03.Solver.Tests.POM;

namespace Inf03.Solver.Tests;

[TestFixture]
internal class ExamCorrectAnswerQuestionContainerTest : StartUpExamDataBaseInitializationTest
{

    private GetCorrectAnswerElementFromQuestionContainerPage getElementFromContainerPage;

    [SetUp]
    public void InitExamDataBaseConnectionTest()
    {
        getElementFromContainerPage = new GetCorrectAnswerElementFromQuestionContainerPage(Page);
    }

    [Test]
    public async Task AddCorrectAnswerElemntsToDataBase_DisplayCorrectAnswer()
    {
        await getElementFromContainerPage.AddCorrectAnswerElemntsToDataBase_DisplayCorrectAnswers();
    }
}