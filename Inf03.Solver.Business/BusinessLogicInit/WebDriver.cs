using OpenQA.Selenium;
using OpenQA;

namespace Inf03.Solver.Business.BusinessLogicInit;
    public class WebDriver
    {
        public IWebDriver? _webDriver { get; init; }
        public DriverOptions? _driverOptions { get; init; }
        
        protected WebDriver(IWebDriver webDriver, DriverOptions driverOptions)
        {
            _webDriver = webDriver;
            _driverOptions = driverOptions;
        }
        public static WebDriver CreateWebDriver(IWebDriver webDriver,DriverOptions driverOptions)
        {
            return new WebDriver(webDriver,driverOptions);
        }
    
    }
