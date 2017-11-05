using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace TACReportTest
{
    [TestClass]
    public class TacTest
    {
        [TestMethod]
        public static void Main()
        {
            //ajustar o dia de hoje e ontem
            var today = DateTime.Today;
            var yesterday = today.AddDays(-1);

            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://login:password@sitename.com";

            //verifica se o popup de manutenção está presente
            var popup = driver.FindElement(By.CssSelector("body > div.bootstrap-dialog > div > div > div.footer > div > div > button"));
            VerificaPopup(popup);
            
            //fazer login
            driver.FindElement(By.Id("userNameBox")).SendKeys("username");
            driver.FindElement(By.Id("psswdBox")).SendKeys("password");
            driver.FindElement(By.Id("login")).Click();

            //verifica se o popup de manutenção está presente
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));        
            popup = driver.FindElement(By.CssSelector(".bootstrap-footer-buttons > button:nth-child(1)"));
            VerificaPopup(popup);

            //clicar no menu Reports
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("Menu")));
            driver.FindElement(By.Id("Menu")).Click();
            
            //filtrar por nome e data
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("filterButton")));

            //limpando e filtrando por label
            var buildLabel = driver.FindElement(By.CssSelector("#buildLabel > input:nth-child(2)"));
            buildLabel.Clear();
            buildLabel.SendKeys("nome");

            //colcoando a data de inicio
            var dateFrom = driver.FindElement(By.CssSelector("#dateFrom > input:nth-child(2)"));
            dateFrom.Clear();
            dateFrom.SendKeys(yesterday.ToString().Substring(0,10));

            //colocando a data final
            var dateTo = driver.FindElement(By.CssSelector("#dateTo > input:nth-child(2)"));
            dateTo.Clear();
            dateTo.SendKeys(today.ToString().Substring(0,10));
            
            //filtrando
            driver.FindElement(By.Id("filterButton")).Click();

            //expandir a seleção
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#table > tbody:nth-child(2) > tr:nth-child(1) > td:nth-child(1) > button:nth-child(1)")));
            driver.FindElement(By.CssSelector("#table > tbody:nth-child(2) > tr:nth-child(1) > td:nth-child(1) > button:nth-child(1)")).Click();

            //driver.Quit();
        }

        private static void VerificaPopup(IWebElement popup)
        {
            if (popup.Displayed)
            {
                popup.Click();
            }
        }
    }
}
