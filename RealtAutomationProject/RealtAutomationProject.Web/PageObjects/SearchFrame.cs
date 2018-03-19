using OpenQA.Selenium;
using RealtAutomationProject.Shared.Core;
using RealtAutomationProject.Web.Controls;
using RealtAutomationProject.Web.PageObjects;

namespace RealtAutomationProject.Web.PageElements
{
  public class SearchFrame: BasePage
  {
    private Frame mainFrame;

    private Frame MainFrame
    {
      get
      {
        if (mainFrame == null)
        {
          mainFrame = new Frame(By.Id("search-page"));
        }
        return mainFrame;
      }
    }
    private HtmlButton closeButton;

    private HtmlButton CloseButton
    {
      get
      {
        if (closeButton == null)
        {
          closeButton = new HtmlButton(By.XPath("//*[@class='search__close']"));
        }
        return closeButton;
      }
    }

    public SearchFrame(By locator) : base(locator)
    {
      Browser.Instance.SwitchToFrame(By.ClassName("modal-iframe"));
    }

    public void Close()
    {
      if (!IsDisplayed) return;
      CloseButton.Click();
      Browser.Instance.SwitchToDefaultFrame();
    }
  }
}
