using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;
using System.Windows.Forms;

namespace Test_App.Android.Pages
{
    class AndroidNavigatePage
    {
        TextBox textBox;
        AndroidDriver<IWebElement> driver;
        public AndroidNavigatePage(AndroidDriver<IWebElement> dri, TextBox textBox)
        {
            PageFactory.InitElements(dri, this);
            this.textBox = textBox;
            this.driver = dri;
        }

        [FindsBy(How = How.XPath, Using = "//android.support.v7.widget.RecyclerView/android.support.v7.widget.LinearLayoutCompat[1]/android.widget.CheckedTextView")]
        private IWebElement my_profile;

        [FindsBy(How = How.XPath, Using = "//android.support.v7.widget.RecyclerView/android.support.v7.widget.LinearLayoutCompat[2]/android.widget.CheckedTextView")]
        private IWebElement my_tickets;

        [FindsBy(How = How.XPath, Using = "//android.support.v7.widget.RecyclerView/android.support.v7.widget.LinearLayoutCompat[3]/android.widget.CheckedTextView")]
        private IWebElement my_finance;

        [FindsBy(How = How.XPath, Using = "//android.support.v7.widget.RecyclerView/android.support.v7.widget.LinearLayoutCompat[4]/android.widget.CheckedTextView")]
        private IWebElement terms;

        [FindsBy(How = How.XPath, Using = "//android.support.v7.widget.RecyclerView/android.support.v7.widget.LinearLayoutCompat[5]/android.widget.CheckedTextView")]
        private IWebElement support;



        public AndroidLoginPage ProfileClick()
        {
            textBox.AppendText("Step To -> " + my_profile.Text + "\r\n");
            my_profile.Click();
            return new AndroidLoginPage(driver);
        }
        public void TicketsClick()
        {
            textBox.AppendText("Step To -> " + my_tickets.Text + "\r\n");
            my_tickets.Click();
        }
        public void FinanceClick()
        {
            textBox.AppendText("Step To -> " + my_finance.Text + "\r\n");
            my_finance.Click();
        }
        public void TermsClick()
        {
            textBox.AppendText("Step To -> " + terms.Text + "\r\n");
            terms.Click();
        }
        public void SupportClick()
        {
            textBox.AppendText("Step To -> " + support.Text + "\r\n");
            support.Click();
        }
    }
}
