using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test_App
{
    class CheckMethods
    {
        private TextBox textbox;
        public CheckMethods(TextBox textbox)
        {
            this.textbox = textbox;
        }
        public void IsTextPresent(IWebElement ch, string text)
        {
            StringBuilder verificationErrors = new StringBuilder();
            try
            {
                Assert.AreEqual(text, ch.Text);
                textbox.AppendText(ch.Text + "  -  Тест Пройден Успешно\r\n");
            }
            catch (AssertionException x)
            {
                textbox.AppendText(verificationErrors.Append(x.Message).ToString());
            }
        }
    }
}
