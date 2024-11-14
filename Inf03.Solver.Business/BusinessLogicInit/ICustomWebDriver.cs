using OpenQA.Selenium;

namespace Inf03.Solver.Business.BusinessLogicInit;
    public interface ICustomWebDriver
    {
    public IWebDriver? _webDriver { get; set; }
    public DriverOptions? _driverOptions { get; set; }

    }
