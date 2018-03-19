using System;
using System.Linq;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace RealtAutomationProject.Shared.Core
{
  public class Browser
  {
    public double TimeoutForElement;
    public int ImplicitWait;
    private static Browser CurrentInstance { get;  set; }
    public IWebDriver Driver { get; private set; }
    private BrowserType currentBrowserType;
    private string browser;

    private Browser()
    {
      InitializeParams();
      Driver = BrowserFactory.GetDriver(currentBrowserType, ImplicitWait);
      Log.Info("Browser was created.");
    }

    public static Browser Instance
    {
      get
      {
        if (CurrentInstance != null)
        {
          return CurrentInstance;
        }
        CurrentInstance = new Browser();
        return CurrentInstance;
      }
    }

    private void InitializeParams()
    {
      ImplicitWait = Convert.ToInt32(Configuration.GetConfigurationVariable("ImplicitWait"));
      Log.Info("Implisit wait set to {0} seconds.", ImplicitWait);
      TimeoutForElement = Convert.ToDouble(Configuration.GetConfigurationVariable("ElementTimeout"));
      Log.Info("Timeout for element set to {0} seconds.", TimeoutForElement);
      browser = Configuration.GetConfigurationVariable("Browser");
      Enum.TryParse(browser, out currentBrowserType);
      Log.Info("Browser {0} is launched.", browser);
    }

    private static readonly Logger Log = new Logger(MethodBase.GetCurrentMethod().DeclaringType);

    public void WindowMaximize()
    {
      Driver.Manage().Window.Maximize();
      Log.Info("Window is maximized.");
    }

    public void SetImplicitWait(double timeOut)
    {
      Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOut);
      Log.Info("Set implicit wait to {0}.", timeOut);
    }

    public void NavigateTo(string url)
    {
      Driver.Navigate().GoToUrl(url);
      Log.Info("Navigate to {0}.", url);
    }

    public string Title => Driver.Title;
    public string Url => Driver.Url;

    public void Refresh()
    {
      Driver.Navigate().Refresh();
      Log.Info("Refresh the page.");
    }

    public void GoBack()
    {
      Driver.Navigate().Back();
      Log.Info("Moving back.");
    }

    public void GoForward()
    {
      Driver.Navigate().Forward();
      Log.Info("Moving forward.");
    }

    public void SwitchToFrame(By frame)
    {
      Driver.SwitchTo().Frame(Driver.FindElement(frame));
      Log.Info("Switch to new frame");
    }

    public void SwitchToDefaultFrame()
    {
      Driver.SwitchTo().DefaultContent();
      Log.Info("Switch to default frame.");
    }

    public string CurrentWindow => Driver.CurrentWindowHandle;


    public void Quit()
    {
      Driver.Quit();
      CurrentInstance = null;
      Driver = null;
      browser = null;
      Log.Info("Close browser.");
    }
  }
}