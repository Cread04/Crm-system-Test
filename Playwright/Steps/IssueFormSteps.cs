using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

[Binding]
public class IssueFormSteps
{
    private readonly IPage _page;

    public IssueFormSteps(ScenarioContext context)
    {
        _page = context["page"] as IPage;
    }

    [Given("I am on the homepage")]
    public async Task GivenIAmOnTheHomepage()
    {
        await _page.GotoAsync("http://localhost:5173");
    }

    [When(@"I click on ""(.*)""")]
    public async Task WhenIClickOn(string companyName)
    {
        await _page.ClickAsync($"text={companyName}");
        await _page.Locator("text=Demo AB").ClickAsync(new() { Timeout = 30000 });
    }

    [Then("I should see the issue form")]
    public async Task ThenIShouldSeeTheIssueForm()
    {
        await _page.WaitForSelectorAsync("form");
    }

    [Then(@"I enter ""(.*)"" as the email")]
    public async Task ThenIEnterAsTheEmail(string email)
    {
        await _page.FillAsync("input[name='email']", email);
    }

    [Then(@"I enter ""(.*)"" as the title")]
    public async Task ThenIEnterAsTheTitle(string title)
    {
        await _page.FillAsync("input[name='title']", title);
    }

    [Then(@"I select ""(.*)"" from the subject dropdown")]
    public async Task ThenISelectFromTheSubjectDropdown(string subject)
    {
        
        await _page.WaitForSelectorAsync("select", new() { State = WaitForSelectorState.Visible });
    
        
        await _page.SelectOptionAsync("select", new[] { new SelectOptionValue { Label = subject } });
    
        Console.WriteLine($"Selected subject: {subject}");
    }
   
    [Then(@"I enter ""(.*)"" as the Message")]
    public async Task ThenIEnterAsTheMessage(string message)
    {
        
        await _page.FillAsync("textarea[name='message']", message);
    }


    [When(@"I click the ""(.*)"" button")]
    public async Task WhenIClickTheButton(string buttonText)
    {
        await _page.ClickAsync($"text={buttonText}");
    }

    [Then("Im done")]
    public async Task ThenImdone()
    {
        await _page.Context.Browser.CloseAsync();
    }
}