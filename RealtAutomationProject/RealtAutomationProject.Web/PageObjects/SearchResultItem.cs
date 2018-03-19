using OpenQA.Selenium;
using RealtAutomationProject.Web.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtAutomationProject.Web.PageObjects
{
  public class SearchResultItem : BasePage
  {
    private Link titleLink;

    public Link TitleLink
    {
      get
      {
        if (titleLink == null)
        {
          titleLink = new Link(Container.FindElement(By.XPath("//a[@class='product__title-link']")));
        }
        return titleLink;
      }
    }

    public SearchResultItem(By locator) : base(locator)
    {

    }

    public SearchResultItem(IWebElement container) : base(container)
    {

    }

  }
}
