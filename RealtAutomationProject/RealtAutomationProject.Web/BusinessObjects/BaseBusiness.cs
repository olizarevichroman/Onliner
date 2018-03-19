using OpenQA.Selenium;
using RealtAutomationProject.Shared.Core;
using RealtAutomationProject.Web.PageElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtAutomationProject.Web.BusinessObjects
{
  public class BaseBusiness
  {
    private FastSearch fastSearch;

    public string Title { get; private set; } = Browser.Instance.Title;
    public string Url { get; private set; } = Browser.Instance.Url;

    public FastSearch FastSearch
    {
      get
      {
        if (fastSearch == null)
        {
          fastSearch = new FastSearch(By.ClassName("fast-search__input"));
        }
        return fastSearch;
      }
    }
  }
}
