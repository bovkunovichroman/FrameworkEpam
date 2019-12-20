using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Model;
using GitHubAutomation.Service;
using GitHubAutomation.Driver;

namespace GitHubAutomation.Pages
{
    public class MyTicketsPage
    {
        private IWebDriver driver;

        public MyTicketsPage(IWebDriver webDriver)
        {
            this.driver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }
        [FindsBy(How = How.ClassName, Using = "nav-item active js-accordion-item icon-buyer")]
        private IWebElement buyerData;

        [FindsBy(How = How.ClassName, Using = "btn save_userdata save_userdata__nomargin")]
        private IWebElement saveChangesButton;

        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement nameSpace;

        [FindsBy(How = How.ClassName, Using = "btn js-popup-btn")]
        private IWebElement continueButtonOnAlertPopup;

        [FindsBy(How = How.ClassName, Using = "nav-item  js-accordion-item icon-passenger")]
        private IWebElement passengerData;   
        
        [FindsBy(How = How.ClassName, Using = "add_passenger js-add-passenger")]
        private IWebElement addNewPassengerButton;

        [FindsBy(How = How.Id, Using = "passenger_last_name")]
        private IWebElement passengerLastNameInput;

        [FindsBy(How = How.Id, Using = "passenger_first_name")]
        private IWebElement passengerFirstNameInput;

        [FindsBy(How = How.Id, Using = "passenger_gender_M")]
        private IWebElement passengerGenderInput;

        [FindsBy(How = How.Id, Using = "passenger_birth_day")]
        private IWebElement passengerBirthDayInput;

        [FindsBy(How = How.Id, Using = "passenger_birth_month")]
        private IWebElement passengerBirthMonthInput;

        [FindsBy(How = How.Id, Using = "passenger_birth_year")]
        private IWebElement passengerBirthYearInput; 

        [FindsBy(How = How.Id, Using = "passenger_docnum")]
        private IWebElement passengerDocNUmInput;

        [FindsBy(How = How.Id, Using = "passenger_doc_expire_date_month")]
        private IWebElement passengeDocExpireDataMonthInput;

        [FindsBy(How = How.Id, Using = "passenger_doc_expire_date_day")]
        private IWebElement passengerDocExpireDateDayInput;

        [FindsBy(How = How.Id, Using = "passenger_doc_expire_date_year")]
        private IWebElement passengerDocExpireDateYearInput; 
        
        [FindsBy(How = How.ClassName, Using = "btn js-submit")]
        private IWebElement addPassengerButton;

        [FindsBy(How = How.ClassName, Using = "nav-item active js-accordion-item icon-options")]
        private IWebElement settingsSpace;

        [FindsBy(How = How.ClassName, Using = "btn save_userdata save_userdata__nomargin")]
        private IWebElement resaveButton;
         
        [FindsBy(How = How.ClassName, Using = "btn js-popup-btn")]
        private IWebElement continueButton;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement passwordInput;

        [FindsBy(How = How.Id, Using = "password_confirm")]
        private IWebElement passwordConfirmUnput;


        public MyTicketsPage ClickPassengerData()
        {
            passengerData.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(addNewPassengerButton));
            return this;
        }

        public MyTicketsPage FillAllValuesInLabels(PassengerData passengerData)
        {
            addNewPassengerButton.Click();
            passengerLastNameInput.SendKeys(passengerData.LastName);
            passengerFirstNameInput.SendKeys(passengerData.FirstName);
            passengerGenderInput.Click();
            passengerBirthDayInput.SendKeys(passengerData.BirthDay);
            passengerBirthMonthInput.SendKeys(passengerData.BirthMonth);
            passengerBirthYearInput.SendKeys(passengerData.BirthYear);
            passengerDocNUmInput.SendKeys(passengerData.DocNum);
            passengerDocExpireDateDayInput.SendKeys(passengerData.DocDay);
            passengerDocExpireDateYearInput.SendKeys(passengerData.DocYear);
            passengerBirthMonthInput.SendKeys(passengerData.DocMonth);
            addPassengerButton.Click();
            return this;
        }

        public MyTicketsPage FillAllValuesInLabelsWithoutFirstName(PassengerData passengerData)
        {
            passengerLastNameInput.SendKeys(passengerData.LastName); 
            passengerGenderInput.Click();
            passengerBirthDayInput.SendKeys(passengerData.BirthDay);
            passengerBirthMonthInput.SendKeys(passengerData.BirthMonth);
            passengerBirthYearInput.SendKeys(passengerData.BirthYear);
            passengerDocNUmInput.SendKeys(passengerData.DocNum);
            passengerDocExpireDateDayInput.SendKeys(passengerData.DocDay);
            passengerDocExpireDateYearInput.SendKeys(passengerData.DocYear);
            passengerBirthMonthInput.SendKeys(passengerData.DocMonth);
            addPassengerButton.Click();
            return this;
        }

        public MyTicketsPage ClickToResaveBuyerData()
        {
            buyerData.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
          .Until(ExpectedConditions.ElementToBeClickable(resaveButton));
            resaveButton.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
          .Until(ExpectedConditions.ElementToBeClickable(continueButton));
            continueButton.Click();
            return this;
        }

        public MyTicketsPage ChangePassword(ChangePasssword passwordRe)
        {
            settingsSpace.Click();
            passwordInput.SendKeys(passwordRe.NewPassword);
            passwordConfirmUnput.SendKeys(passwordRe.RepeatNewPassword);
            resaveButton.Click();         
            return this;
        }

    
    





    }
}
