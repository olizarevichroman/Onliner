using OpenQA.Selenium;
using RealtAutomationProject.Web.Interfaces;
using RealtAutomationProject.Web.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtAutomationProject.Web.Controls
{
    public class HtmlButton : BaseElement ,IClickable
                                                            
    {
        public HtmlButton(By locator) : base(locator)
        {

        }

        public void Click()
        {
            InnerElement.Click();
        }
    }
}
