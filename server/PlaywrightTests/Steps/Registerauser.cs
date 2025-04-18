using Microsoft.Playwright;
using TechTalk.SpecFlow;


namespace server.Steps;

[Binding]
public class Registeracompany
{
    private readonly IPage _page;

    public Registeracompany(ScenarioContext context)
    {
        _page = context["page"] as IPage;
    }

    [Given(@"i am on the homepage")]
    public async Task GivenIAmOnTheHomepage()
    {
        await _page.GotoAsync("http://localhost:5173");
    }

    [When(@"i click on register")]
    public async Task WhenIClickOnRegister()
    {
        await _page.ClickAsync("text=Register"); 
    }

    [Then(@"i should see the register form")]
    public async Task ThenIShouldSeeTheRegisterForm()
    {
        await _page.WaitForSelectorAsync("form"); 
    }

    [Then(@"i enter ""(.*)"" as the email")]
    public async Task ThenIEnterAsTheEmail(string email)
    {
        await _page.FillAsync("input[name='email']", email);
    }

    [Then(@"i enter ""(.*)"" as the password")]
    public async Task ThenIEnterAsThePassword(string password)
    {
        await _page.FillAsync("input[name='password']", password);
    }

    [Then(@"i enter ""(.*)"" as the username")]
    public async Task ThenIEnterAsTheUsername(string username)
    {
        await _page.FillAsync("input[name='username']", username);
    }

    [Then(@"i enter ""(.*)"" as the company name")]
    public async Task ThenIEnterAsTheCompanyName(string company)
    {
        await _page.FillAsync("input[name='company']", company);
    }

    [When(@"i click the Skapakonto button")]
    public async Task WhenIClickTheSkapakontoButton()
    {
        await _page.ClickAsync("text=Skapa konto"); // Adjust selector if needed
    }
}