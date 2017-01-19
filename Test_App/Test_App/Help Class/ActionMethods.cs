using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Test_App
{
    static class ActionMethods
    {
        public static void Hover(IWebDriver driver, IWebElement obj)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(obj).Perform();
        }
        public static void ScrollPage(IWebDriver driver, int numb)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0, " + numb.ToString() + ");");
        }
        public static void SwitchToWindow(IWebDriver driver, string windowName)
        {
            driver.SwitchTo().Window(windowName);
        }
        public static void ClosePage(IWebDriver driver)
        {
            driver.Close();
        }
        public static void GoBack(IWebDriver driver)
        {
            driver.Navigate().Back();
        }
        public static void GoToMainPage(IWebDriver driver)
        {
            driver.Url = "http://test-karabas.com/";
        }
    }
}
