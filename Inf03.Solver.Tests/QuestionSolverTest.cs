using Inf03.Solver.Tests.POM;

namespace Inf03.Solver.Tests;

    [TestFixture]
    internal class QuestionSolverTest : StartUpQuestionSolverTest
    {
        private GetQuestionSolverPage getQuestionSolverPage;
        [SetUp]
        public void InitQuestionSolver()
        {
            getQuestionSolverPage = new GetQuestionSolverPage(Page);
        }
        [Test]
        public async Task Dispaly_MatchedData_FromDataBase_And_Page()
        {
            var element = Page.GetByLabel("Zgadzam się");
            await element.ClickAsync();
            await getQuestionSolverPage.Dispaly_MatchedData_FromDataBase_And_Page();
            await getQuestionSolverPage.Solve_Quiz_Automation();
        }
    }
