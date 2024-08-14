
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightTests.Pages;  // Import the namespace where the page object is located
using System.Threading.Tasks;

namespace PlaywrightTests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class ExampleTest : PageTest
    {
        private MiaAcademyPage _miaAcademyPage;

        [SetUp]
        public void Setup()
        {
            _miaAcademyPage = new MiaAcademyPage(Page);
        }

        [Test]
        public async Task ExploreMiaWebsite()
        {
            await _miaAcademyPage.NavigateToHomePageAsync();

            // Validate home page title
            Assert.AreEqual("Miacademy - Engaging Online Curriculum", await _miaAcademyPage.GetPageTitleAsync());

            await _miaAcademyPage.AssertMottoVisibleAsync();
            await _miaAcademyPage.NavigateToMiaPrepOnlineHighSchoolAsync();

            // Validate high school page title
            Assert.AreEqual("MiaPrep Online High School - MiaPrep", await _miaAcademyPage.GetHighSchoolPageTitleAsync());

            await _miaAcademyPage.ClickMenuItemAsync("menu-item-4357");
            await _miaAcademyPage.AssertHeadingVisibleAsync();

            await _miaAcademyPage.FillParentInformationAsync(
                "amex", "merry", "amex@mail.com", "23456789", 
                "amexs2", "merry2", "addmex@mail.com", "23456489");

            await _miaAcademyPage.FillAdditionalInformationAsync("01-Sep-2024");
            await _miaAcademyPage.AssertHeadingVisibleAsync();

            await Page.PauseAsync();
        }
    }
}