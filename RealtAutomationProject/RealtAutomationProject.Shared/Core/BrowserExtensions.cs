using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace RealtAutomationProject.Shared.Core
{
  public static class BrowserExtensions
  {
    private static readonly Logger Log = new Logger(MethodBase.GetCurrentMethod().DeclaringType);

    public static void TakeScrenshoot(this Browser browser, string name)
    {
      var screenShoot = ((ITakesScreenshot)browser.Driver).GetScreenshot();
      var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
      var filename = Configuration.GetConfigurationVariable("ScreenshootsFolder") + name + "_" + timestamp + ".png";
      Trace.Write(filename);
      screenShoot.SaveAsFile(filename);
      Log.Info("Taking {0} screenshot.", name);
    }

    public static IWebElement FindElement(this Browser browser, params By[] locators)
    {
      IWebElement element = null;
      try
      {
        foreach (var locator in locators)
        {
          WaitForElement(browser, locator);
          element = browser.Driver.FindElement(locator);
        }
        Log.Info("Element has been loaded.");
        return element;
      }
      catch (WebDriverTimeoutException ex)
      {
        Log.Error(ex.Message);
        throw;
      }
    }

    public static ReadOnlyCollection<IWebElement> FindElements(this Browser browser, By locator)
    {
      try
      {
        WaitForElements(browser, locator);
        Log.Info("Element has been loaded.");
        return browser.Driver.FindElements(locator);
      }
      catch (WebDriverTimeoutException ex)
      {
        Log.Error(ex.Message);
        throw;
      }
    }

    private static void WaitForElement(this Browser browser, By locator)
    {
      WebDriverWait waiter = new WebDriverWait(browser.Driver, TimeSpan.FromSeconds(browser.TimeoutForElement));
      IWebElement element = waiter.Until(ExpectedConditions.ElementIsVisible(locator));
      Log.Info("Element Loading");
    }
    
    
    private static void WaitForElements(this Browser browser, By locator)
    {
      WebDriverWait waiter = new WebDriverWait(browser.Driver, TimeSpan.FromSeconds(browser.TimeoutForElement));
      var elements = waiter.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
      Log.Info("Elements Loading... {0} elements founded", elements.Count);
    }

  }
}