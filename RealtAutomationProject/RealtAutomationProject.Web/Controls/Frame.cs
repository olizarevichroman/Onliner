using OpenQA.Selenium;
using RealtAutomationProject.Shared.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtAutomationProject.Web.Controls
{
  public class Frame : BaseElement
  {
    public Frame(By locator) : base(locator)
    {
            
    }

    public Frame(IWebElement element) : base(element)
    {

    }

  }
}
