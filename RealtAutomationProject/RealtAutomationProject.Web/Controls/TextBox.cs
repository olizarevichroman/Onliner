using OpenQA.Selenium;
using RealtAutomationProject.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtAutomationProject.Web.Controls
{
    public class TextBox : BaseElement, ITextReadable, ITextWriteable
    {
        public TextBox(By locator) : base(locator)
        {

        }

        public void ClearText()
        {
            InnerElement.Clear();
        }

        public string Text => InnerElement.Text;
     

        public void SetText(string text)
        {
            InnerElement.SendKeys(text);
        }
    }
}
