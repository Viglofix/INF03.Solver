using Inf03.Solver.Business.BusinessLogicInit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System.Security.Cryptography.X509Certificates;

namespace Inf03.Solver.Business.BusinessLogic;
    public class QuestionDataBaseService
    {
       public void Init()
       {
        ICustomWebDriver customWebDriverBuilder = CustomWebDriverBuilder.Empty()
           .InitWebDriver(new ChromeDriver())
           .InitDriverOptions(new ChromeOptions())
           .Build();


       }
    }

