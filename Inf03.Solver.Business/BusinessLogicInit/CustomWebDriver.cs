using OpenQA.Selenium;
using OpenQA;

namespace Inf03.Solver.Business.BusinessLogicInit;
    public class CustomWebDriver : ICustomWebDriver
    {
        public IWebDriver? _webDriver { get; set; }
        public DriverOptions? _driverOptions { get; set; }
    }
