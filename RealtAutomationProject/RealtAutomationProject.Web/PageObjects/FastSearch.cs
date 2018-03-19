using RealtAutomationProject.Web.Controls;
using OpenQA.Selenium;
using RealtAutomationProject.Web.PageObjects;
using RealtAutomationProject.Shared;
using System.Reflection;

namespace RealtAutomationProject.Web.PageElements
{
  public class FastSearch : BasePage
  {
    private TextBox searchField;

    public TextBox SearchField
    {
      get
      {
        if (searchField == null)
        {
          searchField = new TextBox(locator);
        }
        return searchField;
      }
    }

    public FastSearch(By locator) : base(locator)
    {
    }

    public string Text => SearchField.Text;

    public bool IsEmpty => SearchField.Text == string.Empty;

    public SearchFrame SetText(string text)
    {
      if ( text == string.Empty || text == null )
      {
        logger.Debug("Search frame cannot be created, cause text is empty");
        return null;
      }
      SearchField.SetText(text);
      return new SearchFrame(By.Id("search-page"));
    }
    
    public void Clear()
    {
      SearchField.ClearText();
    }
  }
}
