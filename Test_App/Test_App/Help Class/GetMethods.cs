using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Test_App
{
    static class GetMethods
    {
        public static string GetElementText(IWebElement element)
        {
            string result = "";
            string tag = element.TagName.ToLower();

            switch (tag)
            {
                case "input":
                    result = element.GetAttribute("value");
                    break;
                case "select":
                    result = new SelectElement(element).SelectedOption.Text;
                    break;
                default:
                    result = element.Text;
                    break;
            }
            return result;
        }
        public static int GetElementNumb(IWebElement element)
        {
            string text = element.Text;
            string arr = "0123456789";
            string tmp = "";
            int res = 0;
            for (int i = 0; i < text.Count(); i++)
            {
                if(text[i] == '.')
                {
                    break;
                }
                for (int j = 0; j < arr.Count(); j++)
                {
                    if (text[i] == arr[j])
                    {
                        tmp = tmp + text[i];
                    }
                }
            }
            res = int.Parse(tmp);
            return res;
        }
        public static string GetCurrentWindowHandle(IWebDriver driver)
        {
            var currentWindowHandle = driver.CurrentWindowHandle;
            return currentWindowHandle;
        }
        public static ReadOnlyCollection<string> GetWindowHandles(IWebDriver driver)
        {
            var windows = driver.WindowHandles;
            return windows;
        }
    }
}
