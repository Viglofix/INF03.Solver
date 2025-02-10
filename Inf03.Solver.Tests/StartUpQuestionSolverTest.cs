using Microsoft.Playwright.NUnit;

namespace Inf03.Solver.Tests;

    [TestFixture]
    internal class StartUpQuestionSolverTest : PageTest
    {
        [SetUp]
        public async Task InitAsync()
        {
            await Page.GotoAsync("https://www.praktycznyegzamin.pl/inf03ee09e14/teoria/test/");
        }
        [TearDown]
        public async Task TearDownAsync()
        {
            await Page.CloseAsync();     
        }
    }

