using ExampleTestProject.Source.BaseTests;
using OpenQA.Selenium;
using PageObjectModel.Reports;
using PraticePageSeleniumTest.Source.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticePageSeleniumTest.Tests
{
    public class PraticePageTest:BaseTest
    {
        [Test]
        //Radio Button Test
        public void selectRadioBtnTest()
        {
            //Rapor için bilgi aşaması
            ExtentReporting.LogInfo("Starting test ");
            driver.Navigate().GoToUrl("https://www.letskodeit.com/practice");
            PraticeTestPages praticeTestPages = new PraticeTestPages();
            praticeTestPages.clickRadioBtn();
            //Element
            IWebElement element = driver.FindElement(By.Id("bmwradio"));
            //Element Değeri
            string actualtext = driver.FindElement(By.Id("bmwradio")).GetAttribute("value");
            //Assert.AreEqual("bmw", actualtext);
            Assert.IsTrue(element.Selected);
            ExtentReporting.LogInfo($"Selected:  {actualtext} click ");
            ExtentReporting.LogPass("Test Başarılı");
        }
        [Test]
        //CheckBox Test
        public void selectCheckboxTest()
        {
            //Rapor için bilgi aşaması
            ExtentReporting.LogInfo("Starting test ");
            driver.Navigate().GoToUrl("https://www.letskodeit.com/practice");
            PraticeTestPages praticeTestPages = new PraticeTestPages();
            praticeTestPages.clickCheckBoxBtn();
            //Element
            IWebElement element = driver.FindElement(By.Id("bmwcheck"));
            //Element Değeri
            string actualtext = driver.FindElement(By.Id("bmwcheck")).GetAttribute("value");
            //Assert.AreEqual("bmw", actualtext);
            Assert.IsTrue(element.Selected);
            ExtentReporting.LogInfo($"Selected:  {actualtext} click ");
            ExtentReporting.LogPass("Test Başarılı");
        }
        [Test]
        //New Window Test
        public void clickNewWindowTest()
        {
            //Rapor için bilgi aşaması
            ExtentReporting.LogInfo("Starting test ");
            driver.Navigate().GoToUrl("https://www.letskodeit.com/practice");
            PraticeTestPages praticeTestPages = new PraticeTestPages();
            praticeTestPages.clickNewPage();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Assert.AreEqual("https://www.letskodeit.com/courses", driver.Url);
            ExtentReporting.LogPass("Test Başarılı");
        }
        [Test]
        //New Tab Window Test
        public void clickSwitchWindowTest()
        {
            //Rapor için bilgi aşaması
            ExtentReporting.LogInfo("Starting test ");
            driver.Navigate().GoToUrl("https://www.letskodeit.com/practice");
            PraticeTestPages praticeTestPages = new PraticeTestPages();
            praticeTestPages.clickSwitchPage();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Assert.AreEqual("https://www.letskodeit.com/courses", driver.Url);
            ExtentReporting.LogPass("Test Başarılı");
        }
        [Test]
        //Select Item DropDownList 
        public void selectDropDownList()
        {
            //Rapor için bilgi aşaması
            ExtentReporting.LogInfo("Starting test ");
            driver.Navigate().GoToUrl("https://www.letskodeit.com/practice");
            PraticeTestPages praticeTestPages = new PraticeTestPages();
            praticeTestPages.selectDropDownListValue();
            Assert.AreEqual("honda", "honda");
            ExtentReporting.LogPass("Test Başarılı");
        }
        [Test]
        //Read Text Value
        public void readTableText()
        {
            //Rapor için bilgi aşaması
            ExtentReporting.LogInfo("Starting test ");
            driver.Navigate().GoToUrl("https://www.letskodeit.com/practice");
            //Okunan Değer
            string actualtext = driver.FindElement(By.CssSelector("tr:nth-of-type(2) > .course-name")).Text;
            Assert.AreEqual("Selenium WebDriver With Java", actualtext,"Aynı Değeler Sağlanamadı");
            ExtentReporting.LogInfo("Test Successful");
        }
    }
}
