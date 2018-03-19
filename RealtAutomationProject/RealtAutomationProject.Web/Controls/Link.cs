using OpenQA.Selenium;
using RealtAutomationProject.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtAutomationProject.Web.Controls
{
  public class Link : BaseElement, ITextReadable
  {
    public Link(By locator) : base(locator)
    {

    }

    public Link(IWebElement element) : base(element)
    {

    }

    public string Text
    {
      get
      {
        return InnerElement.Text;
      }
    }
  }
}
