using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Inf03.Solver.Business.BusinessLogicInit;
public class CustomWebDriverBuilder
{
    private IWebDriver? _webDriver { get; set; }
    private DriverOptions? _driverOptions { get; set; }

    private CustomWebDriverBuilder() { }
    public static CustomWebDriverBuilder Empty() => new();
    public CustomWebDriverBuilder InitDriverOptions(DriverOptions options)
    {
        _driverOptions = options;
        return this;
    }
    public CustomWebDriverBuilder InitWebDriver(IWebDriver webDriver)
    {
        _webDriver = webDriver;
        return this; 
    }
    public CustomWebDriverBuilder AddCustomOptions(Action options)
    {
        if(_driverOptions is null)
        {
            throw new ArgumentNullException();
        }
        return this;
    }
    public ICustomWebDriver Build()
    {
        return new CustomWebDriver()
        {
            _driverOptions = _driverOptions,
            _webDriver = _webDriver
        };
    }
}
