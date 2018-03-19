using OpenQA.Selenium;
using RealtAutomationProject.Shared.Core;
using RealtAutomationProject.Web.Controls;
using RealtAutomationProject.Web.PageObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RealtAutomationProject.Web.PageElements
{
  public class SearchFrame: BasePage
  {
    private Frame mainFrame;
    private TextBox searchField;
    public ReadOnlyCollection<SearchResultItem> SearchResults
    {
      get
      {
        return GetSearchResults();
      }
    }

    private ReadOnlyCollection<SearchResultItem> GetSearchResults()
    {
      List<SearchResultItem> results = new List<SearchResultItem>();
      foreach (var element in MainFrame.InnerElement.FindElements(By.ClassName("product__title-link")))
      {
        results.Add(new SearchResultItem(element));
      }
      return new ReadOnlyCollection<SearchResultItem>(results);
    }

    public TextBox SearchField
    {
      get
      {
        if (searchField == null)
        {
          searchField = new TextBox(By.ClassName("search__input"));
        }
        return searchField;
      }
    }

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
