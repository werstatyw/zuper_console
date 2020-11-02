using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using NUnit.Framework;

namespace BrowserStackAppiumSingleTest
{
    class MainClass
    {
        readonly static string userName = "alexg78";
        readonly static string accessKey = "somekey";



        public static void Main(string[] args)
        {
            AppiumOptions caps = new AppiumOptions();
            caps.AddAdditionalCapability("browserstack.user", userName);
            caps.AddAdditionalCapability("browserstack.key", accessKey);
            caps.AddAdditionalCapability("device", "Samsung Galaxy S10e");
            caps.AddAdditionalCapability("os_version", "9.0");
            caps.AddAdditionalCapability("project", "My First Project");
            caps.AddAdditionalCapability("build", "My First Build");
            caps.AddAdditionalCapability("name", "Bstack-[C#] Sample Test");
            caps.AddAdditionalCapability("app", "bs://ae2ce961fcec8d8c04b9d84b93848b100eab5b41");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                ExpectedConditions.ElementToBeClickable(MobileBy.Id("com.getzuper.debug:id/input_email"))
            );
            searchElement.Click();

            searchElement.SendKeys("isaid.zx@gmail.com");

            AndroidElement confirmButton = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                ExpectedConditions.ElementToBeClickable(MobileBy.Id("com.getzuper.debug:id/bt_confirm")));
            confirmButton.Click();
            System.Threading.Thread.Sleep(30);

            driver.Quit();
        }
    }
}