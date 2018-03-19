using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;

namespace RealtAutomationProject.Shared.Core
{
  public enum BrowserType
  {
    Chrome,
    Firefox,
    InternetExplorer,
    Safari,
    RemoteFirefox,
    RemoteChrome,
    RemoteInternetExplorer,
    RemoteSafari
  }

  public class BrowserFactory
  {
    public static IWebDriver GetDriver(BrowserType browserType, int timeOutSec)
    {
      IWebDriver driver = null;
      switch (browserType)
      {
        case BrowserType.Chrome:
          {
            var service = ChromeDriverService.CreateDefaultService();
            var options = new ChromeOptions();
            options.AddArgument("disable-infobars");
            driver = new ChromeDriver(service, options, TimeSpan.FromSeconds(timeOutSec));
            break;
          }
        case BrowserType.Firefox:
          {
            var service = FirefoxDriverService.CreateDefaultService();
            var options = new FirefoxOptions();
            driver = new FirefoxDriver(service, options, TimeSpan.FromSeconds(timeOutSec));
            break;
          }
        case BrowserType.InternetExplorer:
          {
            var service = InternetExplorerDriverService.CreateDefaultService();
            var options = new InternetExplorerOptions();
            driver = new InternetExplorerDriver(service, options, TimeSpan.FromSeconds(timeOutSec));
            break;
          }
        case BrowserType.Safari:
          {
            var service = SafariDriverService.CreateDefaultService();
            var options = new SafariOptions();
            driver = new SafariDriver(service, options, TimeSpan.FromSeconds(timeOutSec));
            break;
          }
        case BrowserType.RemoteFirefox:
          {
            var capability = DesiredCapabilities.Firefox();
            capability.SetCapability(CapabilityType.BrowserName, "firefox");
            capability.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
            driver = new RemoteWebDriver(new Uri("http://ecsc00a00bed:4444/wd/hub"), capability);
            break;
          }
        case BrowserType.RemoteChrome:
          {
            var capability = DesiredCapabilities.Chrome();
            capability.SetCapability(CapabilityType.BrowserName, "chrome");
            capability.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
            driver = new RemoteWebDriver(new Uri("http://ecsc00a00bed:4444/wd/hub"), capability);
            break;
          }
        case BrowserType.RemoteInternetExplorer:
          {
            var capability = DesiredCapabilities.InternetExplorer();
            capability.SetCapability(CapabilityType.BrowserName, "internet explorer");
            capability.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
            driver = new RemoteWebDriver(new Uri("http://ecsc00a00bed:4444/wd/hub"), capability);
            break;
          }
        case BrowserType.RemoteSafari:
          {
            var capability = DesiredCapabilities.Safari();
            capability.SetCapability(CapabilityType.BrowserName, "safari");
            capability.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
            driver = new RemoteWebDriver(new Uri("http://ecsc00a00bed:4444/wd/hub"), capability);
            break;
          }
      }
      return driver;
    }
  }
}