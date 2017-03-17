﻿//--------------------------------------------------------------
//
// Browser Efficiency Test
// Copyright(c) Microsoft Corporation
// All rights reserved.
//
// MIT License
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files(the ""Software""),
// to deal in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and / or sell copies
// of the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions :
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE AUTHORS
// OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF
// OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
//--------------------------------------------------------------

using OpenQA.Selenium.Remote;
using OpenQA.Selenium;

namespace BrowserEfficiencyTest
{
    internal class HistoryWWI : Scenario
    {
        public HistoryWWI()
        {
            Name = "HistoryWWI";
            DefaultDuration = 90;
        }

        public override void Run(RemoteWebDriver driver, string browser, CredentialManager credentialManager, ResponsivenessTimer timer)
        {
            driver.Navigate().GoToUrl("http://www.history.com/topics");
            driver.WaitForPageLoad();
            driver.Wait(5);

            driver.ClickElement(driver.FindElementByClassName("global-header")
                .FindElement(By.XPath("//*[@href='/topics']")));
            driver.WaitForPageLoad();
            driver.Wait(5);

            driver.ScrollPage(6);

            driver.ClickElement(driver.FindElementById("topicsAccordion")
                .FindElement(By.XPath("//*[contains(text(), 'World War II')]")));

            driver.Wait(3);

            driver.ClickElement(driver.FindElement(By.XPath("//*[contains(text(), 'American Women in World War II')]")));
            driver.WaitForPageLoad();
            driver.Wait(3);

            driver.ScrollPage(3);
        }
    }
}