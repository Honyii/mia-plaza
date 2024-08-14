using Microsoft.Playwright;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;

namespace PlaywrightTests.Pages
{
    public class MiaAcademyPage
    {
        private readonly IPage _page;

        public MiaAcademyPage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateToHomePageAsync()
        {
            await _page.GotoAsync("https://miacademy.co/#/");
        }

        public async Task<string> GetPageTitleAsync()
        {
            return await _page.TitleAsync();
        }

        public async Task AssertMottoVisibleAsync()
        {
            await Assertions.Expect(_page.Locator(".mia-motto")).ToBeVisibleAsync();
        }

        public async Task NavigateToMiaPrepOnlineHighSchoolAsync()
        {
            await _page.Locator("a[href='https://miaprep.com/online-school/']").ClickAsync();
        }

        public async Task<string> GetHighSchoolPageTitleAsync()
        {
            return await _page.TitleAsync();
        }

        public async Task ClickMenuItemAsync(string menuItemId)
        {
            await _page.Locator($"li[id='{menuItemId}'] a").ClickAsync();
            await _page.Locator("td[onclick='goTo(2);']").First.ClickAsync();
        }

        public async Task FillParentInformationAsync(string firstName1, string lastName1, string parent1Email, string parent1Phone,
                                                    string firstName2, string lastName2, string parent2Email, string parent2Phone)
        {
            await _page.Locator("input[name='Name']").Nth(0).FillAsync(firstName1);
            await _page.Locator("input[name='Name']").Nth(1).FillAsync(lastName1);
            await _page.Locator("input[name='Email']").FillAsync(parent1Email);
            await _page.Locator("input[name='PhoneNumber']").FillAsync(parent1Phone);

            await _page.GetByLabel("Would you like to add information for a second parent/guardian?")
                       .SelectOptionAsync("Yes");
            await _page.Locator("input[name='Name1']").Nth(0).FillAsync(firstName2);
            await _page.Locator("input[name='Name1']").Nth(1).FillAsync(lastName2);
            await _page.Locator("input[name='Email1']").FillAsync(parent2Email);
            await _page.Locator("input[name='PhoneNumber1']").FillAsync(parent2Phone);
        }

        public async Task FillAdditionalInformationAsync(string date)
        {
            await _page.Locator("label[for='Checkbox_1']").ClickAsync();
            await _page.Locator("label[for='Checkbox_2']").ClickAsync();
            await _page.Locator("input[name='Date']").FillAsync(date);
            await _page.Locator("button[elname='next']").Nth(1).ClickAsync();
        }

        public async Task AssertHeadingVisibleAsync()
        {
            await Assertions.Expect(_page.Locator("h2[role='heading']")).ToBeVisibleAsync();
        }
    }
}