using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectModel.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace ExampleTestProject.Source.BaseTests
{
    public class BaseTest
    {
        //Driver Çağırma
        public static IWebDriver driver;
        //Ayarlar
        [SetUp]
        public void SetUp()
        {
            //Test oluşturma
            ExtentReporting.CreateTest(TestContext.CurrentContext.Test.MethodName);
            //Driver başlatma
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            //Sekme büyütme
            driver.Manage().Window.Maximize();
           // _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        //Test Bittiğinde
        [TearDown]
        public void Cleanup()
        {
            EndTest();
            ExtentReporting.EndReporting();
            driver.Quit();
        }
        //Ekran görüntüsü alma
        public string GetScreenshot()
        {
            var file = ((ITakesScreenshot)driver).GetScreenshot();
            var img = file.AsBase64EncodedString;
            return img;
        }
        //Test sonlandırma durum ile mesaj bilgisi
        private void EndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            //Test fail veya pass olma durumlarında mesajları raporda gösterme
            switch (testStatus)
            {
                case TestStatus.Failed:
                    ExtentReporting.LogFail($"Test has failed {message}"); break;
                case TestStatus.Skipped:
                    ExtentReporting.LogInfo($"Test has skipped {message}"); break;
                default:
                    break;
            }
            //Test bittiğinde ekran görüntüsü al
            ExtentReporting.LogScreenShot("Ending Test", GetScreenshot());
        }
    }
}
