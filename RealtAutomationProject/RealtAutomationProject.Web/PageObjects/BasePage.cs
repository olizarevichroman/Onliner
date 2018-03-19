using OpenQA.Selenium;
using RealtAutomationProject.Shared;
using RealtAutomationProject.Shared.Core;
using RealtAutomationProject.Web.Interfaces;
using System.Reflection;

namespace RealtAutomationProject.Web.PageObjects
{
  public abstract class BasePage : IState
  {
    protected By locator;
    protected Logger logger = new Logger(MethodBase.GetCurrentMethod().DeclaringType);
    protected IWebElement container;
    public IWebElement Container
    {
      get
      {
        if (container == null)
        {
          container = Browser.Instance.FindElement(locator);
        }
        return container;
      }
    }
    

    public BasePage(By locator)
    {
      this.locator = locator;
    }

    public bool IsDisplayed
    {
      get
      {
        try
        {
          return Container.Displayed;
        }
        catch (StaleElementReferenceException)
        {
          return false;
        }
      }
    }

    public bool IsEnabled
    {
      get
      {
        try
        {
          return Container.Enabled;
        }
        catch (StaleElementReferenceException)
        {
          return false;
        }
      }
    }
  }
}
