using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RealtAutomationProject.Shared.Core;
using RealtAutomationProject.Web.Controls;
using OpenQA.Selenium;

namespace RealtAutomationProject.Web.Tests
{
  [TestFixture]
  public class PhotoPageTests
  {
    private Browser browser;

    [SetUp]
    public void SetUp()
    {
      browser = Browser.Instance;
      Browser.WindowMaximize();
      Browser.NavigateTo("https://realt.by/sale/flats/");
      
    }

    [Test]
    public void Test_IsAllImagesAttached()
    {
      BoxOfElements box = new BoxOfElements(By.XPath("//div[@class=\"tx-uedb\"]"));
      IJavaScriptExecutor ex = (IJavaScriptExecutor)Browser.Driver;
      IWebElement downloadBox = Browser.Driver.FindElement(By.XPath("//h1"));
      ex.ExecuteScript("arguments[0].scrollIntoView(true);", downloadBox);
      IReadOnlyCollection<IWebElement> apartments = box.FindElements(By.XPath("//div[@class='bd-item ']"));
      foreach ( var apartment in apartments)
      {
        apartment.FindElement(By.XPath("//img[@class=\"lazy\"]"));
      }

    }









    [TearDown]
    public void TearDown()
    {
      Browser.Quit();
    }

  }
}
