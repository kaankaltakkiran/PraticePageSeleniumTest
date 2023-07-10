using ExampleTestProject.Source.BaseTests;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticePageSeleniumTest.Source.Pages
{
    public class PraticeTestPages:BaseTest
    {
        //Elementler
        [FindsBy(How =How.Id,Using = "bmwradio")]
        private IWebElement _radioBtn;
        [FindsBy(How = How.Id, Using = "bmwcheck")]
        private IWebElement _checkBoxBtn;
        [FindsBy(How = How.Id, Using = "openwindow")]
        private IWebElement _clickopenwindow;
        [FindsBy(How = How.Id, Using = "opentab")]
        private IWebElement _clickopentab;
        [FindsBy(How = How.Id, Using = "carselect")]
        private IWebElement _selectelement;

        public PraticeTestPages() {
            PageFactory.InitElements(driver, this);
        }
        //Görevler
        public void clickRadioBtn()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _radioBtn.Click();
        }
        public void clickCheckBoxBtn()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _checkBoxBtn.Click();
        }
        public void clickNewPage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _clickopenwindow.Click();
        }
        public void clickSwitchPage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _clickopentab.Click();
        }
        public void selectDropDownListValue()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            SelectElement select = new SelectElement(_selectelement);
            select.SelectByValue("honda");
        }
    }
}
