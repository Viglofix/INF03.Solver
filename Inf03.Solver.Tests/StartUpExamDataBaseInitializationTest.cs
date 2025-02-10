using Microsoft.Playwright.NUnit;

namespace Inf03.Solver.Tests;

    [TestFixture]
    internal class StartUpExamDataBaseInitializationTest : PageTest
    {
        [SetUp]
        public async Task InitAsync()
        {
            // Arrange
            await Page.GotoAsync("https://www.praktycznyegzamin.pl/inf03ee09e14/teoria/wszystko/");
        }

        [TearDown]
        public async Task CleanupAsync()
        {
            await Page.CloseAsync();
        }
    }
