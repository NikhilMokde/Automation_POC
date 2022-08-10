////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName:   Helper.cs
//Description : Refers to all key events defined for the framework
////////////////////////////////////////////////////////////////////////////////////////////////////////


using MFGAutomation.Generics;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;


namespace MFG_Automation.Generics
{
    /// <summary>
    /// Contains common selenium commands which can be used during script development 
    /// </summary>
    class Helper : CommonProperties
    {
        #region[Variables]
        // Initialize Variable
       
        public static IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
        #endregion[Variables]

        /// <summary>
        /// Enter text using this method
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        public static void InputText(IWebElement element, string text)
        {
            try
            {
                element.Clear();
                AddDelay(1000);
                element.SendKeys(text);
                Logs.Info($"{text} entered in input field");
            }
            catch (Exception ElementNotVisible)
            {
                Logs.Error($"Unable to click on element {ElementNotVisible}");
                throw ElementNotVisible;
            }

        }

        /// <summary>
        /// Clicks an element
        /// </summary>
        /// <param name="element"></param>
        public static void ClickElement(IWebElement element)
        {
            try
            {
                element.Click();
            }
            catch (Exception ElementNotVisible)
            {
                Logs.Error($"Unable to click on element {ElementNotVisible}");
                throw ElementNotVisible;
            }
        }

        /// <summary>
        /// Double clicks the element
        /// </summary>
        /// <param name="element"></param>
        public static void DoubleClick(IWebElement element)
        {
            try
            {
                Actions actions = new Actions(Driver);
                actions.DoubleClick(element).Perform();
            }
            catch (Exception ElementNotVisible)
            {
                Logs.Error($"Unable to double click on element {ElementNotVisible}");
                throw ElementNotVisible;
            }
        }

        /// <summary>
        /// Scrolls till the element is visible and then clicks on it
        /// </summary>
        /// <param name="element"></param>
        public static void ScrollAndClick(IWebElement element)
        {
            try
            {
                js.ExecuteScript("arguments[0].scrollIntoView();", CommonActions.ElementWait(element, 25));
                element.Click();
            }
            catch(Exception ex)
            {
                Logs.Error($"Unable to Scroll And Click {ex}");
                throw ex;
            }           
        }

        /// <summary>
        ///Click on element using Java script
        /// </summary>
        /// <param name="element"></param>
        public static void JavaScriptClick(IWebElement element)
        {
            try
            {
                js.ExecuteScript("arguments[0].click();", element);
            }
            catch (Exception e)
            {
                Logs.Error($"Unable to click on element using Java script {e}");
                throw e;
            }
        }

        /// <summary>
        /// This method append month, day, hours, minutes, seconds and milliseconds at end of string (MMddhhmmssff)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string AppendDateTimeSeconds(string data)
        {
            try
            {
                var lastIndexValue = Convert.ToInt64(data.Substring(data.Length - 12, 12));
                string value = data.Substring(0, data.Length - 12);

                if (lastIndexValue.GetType() == typeof(Int64))
                {
                    return $"{value}{CommonActions.GetCurrentDateToAppend()}";
                }
            }
            catch (Exception ex)
            {
                Logs.Error($"Unable to click on element using java sript {ex}");
                throw ex;
            }
            return $"{data}{CommonActions.GetCurrentDateToAppend()}";
        }

        /// <summary>
        /// Shifts control to the previous window
        /// </summary>
        public static void ControlToPreviousWindow()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.First());
            Helper.AddDelay(500);
        }

        /// <summary>
        /// Shifts control to the next window
        /// </summary>
        public static void ControlToNextWindow()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            Helper.AddDelay(500);
        }

        /// <summary>
        /// retrieve text from Ui
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetText(IWebElement element)
        {
            try
            {
                string ElementText = element.Text;
                return ElementText;
            }
            catch (Exception ex)
            {
                Logs.Error($"failed to get text from the element {ex}");
                throw ex;
            }
        }

        /// <summary>
        /// Uploads file (browses file) using AutoIt
        /// </summary>
        /// <param name="element">after clicking on this element windows popup box opens</param>
        /// <param name="filepath">the path of the file to be uploaded</param>
        //public static void UploadFile(IWebElement element, string filepath)
        //{
        //    try
        //    {
        //        ClickElement(element);
        //        AutoItX3 autoIt = new AutoItX3();
        //        autoIt.WinActivate("Open");
        //        Helper.AddDelay(3000);
        //        autoIt.Send(@filepath);
        //        Helper.AddDelay(2000);
        //        autoIt.Send("{ENTER}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.Error($"failed to upload file {ex}");
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// Verify element is displayed or not
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsElementDisplayed(IWebElement element)
        {
            try
            {
                if (element.Displayed)
                {
                    Logs.Info("The element " + element + " was found on the page.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logs.Fail("The element " + element + " was not found on the page.");
                throw ex;
            }
            return false;
        }

        /// <summary>
        /// This method will select the value from the drop down menu.
        /// </summary>
        /// <param name="element">Drop down element</param>
        /// <param name="value">Value to select</param>
        public static void ElementSelectFromDropDown(IWebElement element, string value)
        {
            try
            {
                SelectElement sel = new SelectElement(element);
                AddDelay(1000);
                sel.SelectByText(value);
                Logs.Info(value + "is selected From Dropdown");
            }
            catch (Exception ex)
            {
                Logs.Fail("Unable to select the " + value + " value from the " + element + " drop down.");
                throw ex;
            }
        }

        /// <summary>
        /// This method will select the value from the drop down menu.
        /// </summary>
        /// <param name="element">Drop down element</param>
        /// <param name="value">Value to select</param>
        public static void ElementSelectFromDropDownByValue(IWebElement element, string value)
        {
            try
            {
                SelectElement sel = new SelectElement(element);
                AddDelay(1000);
                sel.SelectByValue(value);
            }
            catch (Exception ex)
            {
                Logs.Fail("Unable to select the " + value + " value from the " + element + " drop down.");
                throw ex;
            }
        }

        /// <summary>
        /// this method Scroll Page to particular element
        /// </summary>
        /// <param name="element"></param>
        public static void ScrolltillElement(IWebElement element)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                js.ExecuteScript("arguments[0].scrollIntoView();", CommonActions.ElementWait(element, 25));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add Delay
        /// </summary>
        /// <param name="time"></param>
        public static void AddDelay(int time)
        {
            Thread.Sleep(time);
        }


        /// <summary>
        /// entre date in date picker
        /// </summary>
        /// <param name="expDate"></param>
        /// <param name="expMonth"></param>
        /// <param name="expYear"></param>
        public void EnterDate(int expDate, int expMonth, int expYear)
        {
           

            string CurrentMonth;
            string CurrentYear;
            bool dateNotFound;

            IList<string> MonthList = new List<string>();
            MonthList.Add("January");
            MonthList.Add("February");
            MonthList.Add("March");
            MonthList.Add("April");
            MonthList.Add("May");
            MonthList.Add("June");
            MonthList.Add("July");
            MonthList.Add("August");
            MonthList.Add("September");
            MonthList.Add("October");
            MonthList.Add("November");
            MonthList.Add("December");
            dateNotFound = true;

            try
            {
                //This loop will be executed continuously till dateNotFound Is true.
                while (dateNotFound)
                {
                    //Retrieve current selected month name from date picker popup.
                    AddDelay(2000);
                   
                    Logs.Info("Retrieved current selected month name from date picker popup");

                    //Retrieve current selected year name from date picker popup.
                    AddDelay(2000);
                    
                    Logs.Info("Retrieved current selected year name from date picker popup");

                    //If current selected month and year are same as expected month and year then go Inside this condition.
                    
                    //If current selected month and year are less than expected month and year then go Inside this condition.
                    
                }
                AddDelay(1000);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        /// <summary>
        /// Select date from Date Picker
        /// </summary>
        /// <param name="date"></param>
        public void selectDate(int date)
        {
            List<IWebElement> noOfColumns;
          

            //Loop will rotate till expected date not found.
           
        }
       
        /// <summary>
        /// Verify Validation Message
        /// </summary>
        /// <param name="ActualMessage"></param>
        /// <param name="ExpectedMessage"></param>
        public static void VerifyValidationMessage(String ActualMessage, string ExpectedMessage)
        {
            try
            {
                Assert.AreEqual(ActualMessage, ExpectedMessage);
                Logs.Info("Validation Message is present as Expected " + ExpectedMessage);
            }
            catch (Exception ex)
            {
                Logs.Fail("Validation Message is not present as Expected " + ExpectedMessage);
                throw ex;
            }
        }

        /// <summary>
        /// Page Scroll Up
        /// </summary>
        /// <param name="element"></param>
        public static void PageUp()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("scroll(0,-500)");
        }

        /// <summary>
        /// Method to Open new tab
        /// </summary>
        public static void OpenNewTab()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.open();");
            ControlToNextWindow();
            AddDelay(2000);
        }

        /// <summary>
        /// Switch To New Frame
        /// </summary>
        public static void SwitchToNewFrame(string FrameName)
        {
            Driver.SwitchTo().Frame(FrameName);
            AddDelay(1000);
        }

        /// <summary>
        /// Switch To Parent Frame
        /// </summary>
        public static void SwitchToParentFrame()
        {
            Driver.SwitchTo().DefaultContent();
            AddDelay(1000);
        }
        
        /// <summary>
        /// Reload Page
        /// </summary>
        public static void ReloadPage()
        {
            js.ExecuteScript("location.reload(true)");
        }
        
        /// <summary>
        /// Entre days in date picker
        /// </summary>
        /// <param name="i"></param>
        public void EntreDateInDatePicker(int days)
        {
            // select Delivery Date
            string DeliveryDate = DateTime.Now.AddDays(days).ToString("MM/dd/yyyy");
            string[] DeliveryDates = DeliveryDate.Split('/');
            int[] convertedItems = Array.ConvertAll<string, int>(DeliveryDates, int.Parse);
            EnterDate(convertedItems[1], convertedItems[0], convertedItems[2]);
            Logs.Info("'Delivery Date' has been selected");
        }


        /// <summary>
        /// Verify Message through contains Method
        /// </summary>
        /// <param name="actualMessage"></param>
        /// <param name="exepctedMessage"></param>
        public static void VerifyMessage(string actualMessage, string exepctedMessage)
        {
            if (actualMessage.Contains(exepctedMessage))
            {
                Logs.Info("Message is Display as expected:" + actualMessage);
            }
            else
            {
                Assert.Fail("Message is not present expected:" + exepctedMessage);
            }
        }

        

        /// <summary>
        /// clear text using this method
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        public static void ClearText(IWebElement element)
        {
            try
            {
                element.Clear();
                AddDelay(1000);
            }
            catch (Exception ElementNotVisible)
            {
                Logs.Error($"Unable to click on element {ElementNotVisible}");
                throw ElementNotVisible;
            }
        }

        /// <summary>
        /// Applies implicit wait over the driver instance
        /// </summary>
        /// <param name="driver"></param>
        public static void ImplicitWait(int i)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(i);
        }

        /// <summary>
        /// Get Value From Text Box Using JavaScript
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static object GetValueFromTextBoxUsingJavaScript(string id)
        {
            object actualValue = ((IJavaScriptExecutor)Driver).ExecuteScript("return document.getElementById('" + id + "').value");
            return actualValue;
        }

        /// <summary>
        /// Get Value From Dropdown
        /// </summary>
        /// <param name="ele"></param>
        /// <returns></returns>
        public static string GetValueFromDropdown(IWebElement ele)
        {
            string defalutOption = "";
            try
            {
                SelectElement sel = new SelectElement(ele);
                IWebElement selectedFirstOption = sel.SelectedOption;
                defalutOption = selectedFirstOption.Text;
            }
            catch (Exception ex)
            {
                Logs.Error($"Unable to get element {ex}");
                throw ex;
            }
            return defalutOption;
        }
        
        /// <summary>
        /// WaitForPageLoad
        /// </summary>
        public static void WaitForPageLoad()
        {
            string pageLoadStatus;
            do
            {
                pageLoadStatus = (String)js.ExecuteScript("return document.readyState");

            }
            while (!pageLoadStatus.Equals("complete"));
            Logs.Info("Page is loaded successfully");
        }
       
        /// <summary>
        /// Entre Text Using Java Script
        /// </summary>
        /// <param name="element">provide element</param>
        /// <param name="value">provide value</param>
        public static void EntreTextUsingJavaScript(IWebElement element, string value)
        {
            js.ExecuteScript("arguments[0].value=" + value + ";", element);
        }

        /// <summary>
        /// Scroll Down
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void ScrollDown(int width = 0, int height = 600)
        {
            try
            {
                ((IJavaScriptExecutor)Driver).ExecuteScript("window.scroll(" + height + " ," + width + " );");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

 