using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace server.Steps;

[Binding]
public class LoginSteps
{
    private readonly IPage _page;

    public LoginSteps(ScenarioContext context)
    {
        _page = context["page"] as IPage;
    }

    [Given(@"I am on the  homepage")]
    public async Task GivenIAmOnTheLoginHomepage()
    {
        await _page.GotoAsync("http://localhost:5173");
    }


    [When(@"I click the login link")]
    public async Task WhenIClickTheLoginLink()
    {
        await _page.ClickAsync("text=Login");
    }


    [Then("I should see the Login Popup")]
    public async Task ThenIShouldSeeTheLoginForm()
    {
        await _page.WaitForSelectorAsync("form >> text=Login");
    }

    [Then(@"I enter ""(.*)"" into the login email field")]
    public async Task ThenIEnterIntoTheLoginEmailField(string email)
    {
        await _page.FillAsync("input[name='email']", email);
    }


    [Then(@"I enter ""(.*)"" as the password")]
    public async Task ThenIEnterAsThePassword(string password)
    {
        await _page.FillAsync("input[name='password']", password);
    }

    [When(@"I click the ""(.*)"" button on the login page")]
    public async Task WhenIClickTheButtonOnTheLoginPage(string buttonText)
    {
        await _page.ClickAsync($"button:has-text('{buttonText}')");
    }


    [Then("I Should see the worksite")]
    public async Task ThenIShouldSeeTheWorksite()
    {
        var isVisible = await _page.Locator("button:has-text('Logout')").IsVisibleAsync();
        
    }
}