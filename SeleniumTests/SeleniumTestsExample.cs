using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    public class SeleniumTestsExample
    {
        IWebDriver? driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("C:\\Users\\athes\\Desktop\\chromedriver");
        }

        [Test]
        public void OrderProcessTest()
        {
            driver.Url = "https://www.saucedemo.com";

            // TODO: Place your test code here

            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();

            driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();
            driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light")).Click();

            driver.FindElement(By.Id("shopping_cart_container")).Click();

            Assert.AreEqual("Sauce Labs Backpack",driver.FindElement(By.Id("item_4_title_link")).Text);
            Assert.AreEqual("Sauce Labs Bike Light", driver.FindElement(By.Id("item_0_title_link")).Text);

            driver.FindElement(By.Id("checkout")).Click();

            driver.FindElement(By.Id("first-name")).SendKeys("John");
            driver.FindElement(By.Id("last-name")).SendKeys("Doe");
            driver.FindElement(By.Id("postal-code")).SendKeys("11222");

            driver.FindElement(By.Id("continue")).Click();

            string summary_info = driver.FindElement(By.ClassName("summary_info")).Text;

            Assert.True(summary_info.Contains("Free Pony Express Delivery!"));

            // compute the total price
            Assert.True(summary_info.Contains("$43.18"));

            driver.FindElement(By.Id("finish")).Click();

            Assert.True(driver.FindElement(By.Id("checkout_complete_container")).Text.Contains("Thank you for your order!"));
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }

}