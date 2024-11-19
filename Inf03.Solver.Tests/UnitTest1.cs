using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace Inf03.Solver.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest {

    [SetUp]
    public async Task SetUpBasicTest()
    {
        Trace.Listeners.Add(new ConsoleTraceListener());
        await Page.GotoAsync("https://en.wikipedia.org/wiki/Kim_Jong_Un");

    }
    [TearDown]
    public void TearDownBasicTest()
    {
        Trace.Flush();
    }

    [Test]
    public async Task BasicTest()
    {
       Debug.WriteLine("Hello World");
       var element = await Page.Locator("span.mw-page-title-main").First.InnerHTMLAsync();
       Debug.WriteLine(element);
    }
}