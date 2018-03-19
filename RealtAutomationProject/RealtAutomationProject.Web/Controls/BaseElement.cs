using System.Reflection;
using OpenQA.Selenium;
using RealtAutomationProject.Shared;
using RealtAutomationProject.Shared.Core;
using RealtAutomationProject.Web.Interfaces;

namespace RealtAutomationProject.Web.Controls
{
  public abstract class BaseElement : IState
  {
    private IWebElement innerElement;

    protected By locator;
    protected Logger logger = new Logger(MethodBase.GetCurrentMethod().DeclaringType);

    public IWebElement InnerElement
    {
      get
      {
        if ( innerElement == null )
        {
          innerElement = Browser.Instance.FindElement(locator);
        }
        return innerElement;
      }
    }
    
    public bool IsEnabled => InnerElement.Enabled;

    public bool IsDisplayed => InnerElement.Displayed;

    public BaseElement(By locator)
    {
      this.locator = locator;
      logger.Info("Creating {0} element", GetType().Name);
    }

    public BaseElement(IWebElement element)
    {
      innerElement = element;
    }

  }
}
