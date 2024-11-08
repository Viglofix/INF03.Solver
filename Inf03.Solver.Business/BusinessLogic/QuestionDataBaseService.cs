using Inf03.Solver.Business.BusinessLogicInit;
using OpenQA.Selenium.Chrome;

namespace Inf03.Solver.Business.BusinessLogic;
    public class QuestionDataBaseService
    {
       public void Init()
        {
        WebDriver webDriver = WebDriver.CreateWebDriver(new ChromeDriver(), new ChromeOptions());
        }
    }

