using Inf03.Solver.Business.PlayWrightBusinessLogic;
using Inf03.Solver.Tests.Helper.DIHelper;
using Microsoft.Playwright.NUnit;

namespace Inf03.Solver.Tests;
    [TestFixture]
    public class ExamDataBaseConnectionBaseTest : PageTest
    {
        private IFindElement _findElement;
        private IFoundElementService _foundElementService;

        [SetUp]
        public async Task InitAsync()
        {
            // Arrange
            await Page.GotoAsync("https://www.praktycznyegzamin.pl/inf03ee09e14/teoria/wszystko/");
            _findElement = DiProvider.GetRequiredService<IFindElement>() ?? throw new ArgumentNullException(nameof(IFindElement));
            _foundElementService = DiProvider.GetRequiredService<IFoundElementService>() ?? throw new ArgumentNullException(nameof(IFoundElementService));
        }

        [TearDown]
        public async Task CleanupAsync()
        {
            await Page.CloseAsync();
        }
}
