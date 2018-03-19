using NUnit.Framework;
using RealtAutomationProject.Shared;
using RealtAutomationProject.Shared.Core;
using TechTalk.SpecFlow;

namespace RealtAutomationProject.Web.Tests.Pages
{
  public class BaseTest
  {
    protected static Browser browser;

    [BeforeScenario]
    public void TestInitialize()
    {
      browser = Browser.Instance;
      browser.WindowMaximize();
      browser.NavigateTo(Configuration.GetConfigurationVariable("BaseUrl"));
    }

    [AfterScenario]
    public void TestCleanup()
    {
      Browser.Instance.Quit();
    }
  }
}