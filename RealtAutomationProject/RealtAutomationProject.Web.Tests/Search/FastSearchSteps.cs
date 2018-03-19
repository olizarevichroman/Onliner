using NUnit.Framework;
using RealtAutomationProject.Web.BusinessObjects;
using RealtAutomationProject.Web.PageElements;
using RealtAutomationProject.Web.Tests.Pages;
using TechTalk.SpecFlow;
using System;

namespace RealtAutomationProject.Web.Tests.Search
{
  [Binding]
  public class FastSearchSteps : BaseTest
  {
    private HomePage homePage;
    private SearchFrame searchFrame;

    [Given(@"I am on main page")]
    public void GivenIAmOnMainPage()
    {
      homePage = new HomePage();
      Assert.AreEqual(homePage.Title, "Onliner.by");
    }
        
    [Given(@"fast search field is available")]
    public void GivenFastSearchFieldIsAvailable()
    {
      Assert.IsTrue(homePage.FastSearch.IsEnabled);
    }
        
    [Given(@"fast search field is empty")]
    public void GivenFastSearchFieldIsEmpty()
    {
      Assert.AreEqual(homePage.FastSearch.Text, string.Empty);
    }
        
    [When(@"i send text (.*) in search field")]
    public void WhenISendTextInSearchField(string mark)
    {
        searchFrame = homePage.FastSearch.SetText(mark);
    }
        
    [Then(@"search frame is displayed")]
    public void ThenSearchFrameIsDisplayed()
    {
      Assert.IsTrue(searchFrame.IsDisplayed);
    }
        
    [Then(@"the first 10 devises is (.*)")]
    public void ThenThe10FirstDevisesIsIPhone(string mark)
    {
      foreach(var result in searchFrame.SearchResults)
      {
        Assert.IsTrue(result.TitleLink.Text.Contains(mark));
      }
    }
  }
}
