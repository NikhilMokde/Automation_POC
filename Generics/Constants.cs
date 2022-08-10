////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: Constants.cs
//Description : Collects all the project constants defined in framework
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Configuration;

namespace MFGAutomation.Generics
{
    /// <summary>
    /// Collects all the project constants defined in framework
    /// </summary>
    public class Constants : CommonProperties
    {
        #region[Folderpath]
        public static string ReportPath = $"{ProjectPath}{ConfigurationManager.AppSettings["ReportPath"]}";
        public static string TestDataXMLPath = $"{ProjectPath}{ConfigurationManager.AppSettings["TestDataXMLPath"]}";
        public static string TestDataExcelpath = $"{ProjectPath}{ConfigurationManager.AppSettings["ExcelFolderPath"]}";
        public static string LoginDatapath = $"{ProjectPath}{ConfigurationManager.AppSettings["LoginPath"]}";
        public static string ConfigXMLFile = $"{ProjectPath}{ConfigurationManager.AppSettings["ConfigurationFile"]}";
        public static string Logo = String.Concat(ProjectPath, ConfigurationManager.AppSettings["Logo"]);
        public static string FailedTests = $"{ProjectPath}{ConfigurationManager.AppSettings["FailedTestsFolder"]}";
        public static string LogFolder = $"{ProjectPath}{ConfigurationManager.AppSettings["LogFolder"]}";
        #endregion[Folderpath]

        #region[TestdataFile]
        public static string LoginRegTestDataFile = $"{TestDataExcelpath}{"ExcelLoginRegDetailsTestData.xlsx"}";
        public static string testDataPath = $"{Constants.TestDataExcelpath}{"TestData"}";
        public static string imagePath = $"{Constants.TestDataExcelpath}{"logo2.png"}";
        #endregion[TestdataFile]

        #region[ExcelPath]
        public static string RegExcelPath = $"{TestDataExcelpath}{"LoginRegDetails.xlsx"}";
        #endregion[ExcelPath]

        #region[ExcelConstants - column name]

        public static string ExcelEmail = "Email";
        public static string ExcelPassword = "Password";
        public static string ExcelFirstName = "First Name";
        public static string ExcelLastName = "Last Name";
        public static string ExcelCompanyName = "Company Name";
        public static string ExcelPhoneNumber = "Phone Number";
        public static string ExcelCountry = "Country";
        public static string ExcelPostalCode = "Postal Code";
        public static string ExcelDomain = "Domain";
        public static string ExcelRFQName = "RFQ Name";
        public static string ExcelFirstQuantity = "First Quantity";
        public static string ExcelDescription = "Description";
        public static string ExcelPricePerUnit = "Price Per Unit";
        public static string ExcelInviteMessage = "Invite Message";
        public static string ExcelMaufacturerName = "ManufacturerName";
        public static string ExcelUpdateCompanyName = "CompanyName";
        public static string ExcelUpdatePhoneNumber = "CompanyPhone";
        public static string ExcelUpdateCompanyDescription = "CompanyDescription";
        public static string ExcelDermoCompType = "DermoCompanyTye";
        public static string ExcelDermoEmpCount = "DermoEmployeeCount";
        public static string ExcelDermoFirstLang = "DermoFirstLanguage";
        public static string ExcelUpdateDunsNumber = "DunsNumber";
        public static string ExcelUpdateCageCode = "CageCode";
        public static string ExcelUpdateFirstName = "FirstName";
        public static string ExcelUpdateLastName = "LastName";
        public static string ExcelTitle = "Title";
        public static string ExcelUpdatePersonalEmail = "Email";
        public static string ExcelUpdateGetInTouchAdd1 = "GetInTouchAddress1";
        public static string ExcelUpdateGetInTouchAdd2 = "GetInTouchAddress2";
        public static string ExcelUpdateGetInTouchCity = "GetInTouchCity";
        public static string ExcelUpdateGetInTouchState = "GetInTouchstate";
        public static string ExcelUpdateGetInTouchCountry = "GetInTouchCountry";
        public static string ExcelUpdateGetInTouchPostalCode = "GetInTouchPostalCode";
        public static string ExcelUpdateGetInTouchWebsite = "GetInTouchWebsiteTextBox";
        public static string ExcelUpdateGetInTouchPhone = "GetInTouchPhone";
        public static string ExcelUpdateGetInTouchTwitter = "GetInTouchTwitterTextBox";
        public static string ExcelUpdateGetInTouchFacebook = "GetInTouchFacebookUrlTextBox";
        public static string ExcelUpdteGetInTouchLinkedinURL = "GetInTouchLinkedinUrlTextBox";
        public static string ExcelUpdateCompanyAddress1 = "CompanyAddress1";
        public static string ExcelUpdateCompanyAddress2 = "CompanyAddress2";
        public static string ExcelUpdateCompanyCity = "CompanyCity";
        public static string ExcelUpdateCompanyZipCode = "CompanyZip";
        public static string ExcelUpdateMailingCountry = "MailingCountry";
        public static string ExcelUpdateMailingState = "MailingState";
        public static string ExcelUpdateShipingCompanyName = "ShipingCompanyName";
        public static string ExcelUpdateShipingAddress1 = "ShipingCompanyAddress1";
        public static string ExcelUpdateShipingAddress2 = "ShipingCompanyAddress2";
        public static string ExcelUpdateShipingCity = "ShipingCity";
        public static string ExcelUpdateShippingContry = "ShippingCountry";
        public static string ExcelUpdateShippingState = "ShippingState";
        public static string ExcelUpdateShipingZipCode = "ShipingZipCode";
        public static string ExcelUpdateShippingCountry = "ShippingCountry";
        public static string ExcelspecialInstruction = "specialInstruction";
        public static string ExcelUnit = "unit";
        public static string ExcelPartName = "Partnames";
        public static string ExcelPartNumber = "Partnumber";
        public static string ExcelNumberOfParts = "NumberOfParts";
        public static string ExcelNumberOfQuantity = "Quantity";
        public static string CompanyName = "Comapnay";
        public static string ExcelAddress = "Address";
        public static string ExcelCity = "City";
        public static string ExcelQuantity = "Quantity";
        public static string ExcelCost = "ExcelCost";
        public static string ExcelEmailSubject = "EmailSubject";
        public static string ExcelEmailBody = "ExcelEmailBody";
        public static string ExcelProcess = "Process";
        public static string ExcelPayForShipping = "PayForShipping";
        public static string ExcelDownLeadTime = "DownLeadTime";
        public static string ExcelNumberOfDay = "NumberOfDay";
        public static string ExcelInvalidQUoateRefrence = "InvalidQUoateRefrenc";
        public static string ExcelExpectedMessage = "ValidationMessage";
        public static string ExcelInvalidPhoneNo = "InvalidPhoneNo";
        public static string ExcelValidEmail = "email";
        public static string ExcelUrlEmail = "Url";
        public static string ExcelFeeType = "FeeType";
        public static string ExcelActionType = "ActionType";
        public static string ExcelActionTypeNo = "NumberOfAction";
        public static string ExcelFreeType = "FeeTypes";
        public static string ExcelNumberOfFreeTypeDropdown = "NunberOfFeeType";
        public static string ExcelFreeLabel = "FreeTypeLabel";
        public static string ExcelUnitCost = "UnitCost";
        public static string ExcelEmailDescription = "EmailDescription";
        public static string ExcelPurchaseOrderNumber = "PurchaseOrderNumber";
        public static string ExcelPaymentTerm = "PaymentTerm";
        public static string ExcelPartQuantity = "PartQuantity";
        public static string ExcelTotalAmountOfCost = "TotalAmountCost";
        public static string ExcelNumberOfProcess = "NumberOfProcess";
        public static string ExcelNameOfProcess = "NameOfProcess";
        public static string ExcelNumberOfMaterial = "NumberOfMaterial";
        public static string ExcelNameOfMaterial = "NameOfMaterial";
        public static string ExcelNumberOfPostProcess = "NumberOfPostProcess";
        public static string ExcelNameOfPostProcess = "NameOfPostProcess";
        public static string ExcelNumberLocation = "NumberOfLocation";
        public static string ExcelNameOfLocation = "NameOfLocation";
        public static string ExcelFilterName = "FilterName";
        public static string ExcelProximity = "Proximity";
        public static string ExcelBuyerLocation = "BuyerLocation";
        public static string ExcelTitleSubject = "TitleSubject";
        public static string ExcelMailSubject = "MailSubject";
        public static string ExcelMessage = "Message";
        public static string ExcelSubject = "subject";
        public static string ExcelUserName = "UserName";
        public static string ExcelConformPassword = "ConformPassword";
        public static string ExcelNewPassword = "NewPassword";
        public static string ExcelConformEmail = "ConformEmail";
        public static string ExcelUserType = "UserType";
        public static string ExcelTechnique = "Technique";
        public static string ExcelIndustryFocous = "IndustryFocus";
        public static string ExcelTolerance = "Tolerance";
        public static string ExcelUpdateFullName = "updatedName";
        public static string CommonPassword = "Automation123@";
        public static string PageName = "PageName";
        public static string ExcelPurpose = "Purpose";
        public static string ExcelLevelOfNDA = "NDALevel";
        public static string ExcelMethodOfCommuncation = "MethodOfCommunication";
        public static string ExcelClassName = "className";
        public static string ExcelNDAStandard = "NDAStandard";
        public static string ExcelLiveQuoteProbability = "LiveQuoteProbability";
        public static string ExcelLiveQuoteStatus = "LiveQuoteStatus";
        public static string ExcelCustomCosts = "CustomCosts";
        public static string ExcelStartingInvoiceNumber = "StartingInvoiceNumber";
        public static string ExcelState = "State";
        #endregion[ExcelConstants - column name]

        #region[TestCaes]

        #region[LoginReg]
        public static string LoginBuyer = "LoginBuyer";
        public static string LoginManufacturer = "LoginManufacturer";
        public static string RegNewBuyer = "RegNewBuyer";
        public static string RegNewManufacturer = "RegNewManufacturer";
        public static string ForgotPassword_M2_1613 = "Forgotpassword";
        #endregion[LoginReg]

        #region[M2-1664]
        public static string RFQLifeCycleM2_1664 = "RFQLifeCycle";
        #endregion[M2-1664]  

        #region[M2-1739]
        public static string CreateRFQFrom2ndLevelMDAM2_1739 = "CreateRFQFrom2ndLevelNDA";
        #endregion[M2-1739]

        #region[M2-1798]
        public static string TransferRFQM2_1798 = "TransferRFQ";
        #endregion[M2-1798]

        #region[M2-1767]
        public static string BuyerProfileUpdateM2_1767 = "BuyerProfileUpdate";
        #endregion[M2-1767

        #region[M2-2510]
        public static string M2_2510 = "CreateRFQ";
        #endregion[M2-2510]

        #region[M2-2763]

        public static string M2_2763_CreateRFQAwardAndDeclin = "CreateRFQAwardAndDecline";

        #endregion[M2-2763]

        #region[M2-2774]
        public static string M22774_QMSUpdationAndCreation = "QMSUpdationAndCreation";
        #endregion[M2-2774]

        #region[M2-2797]
        public static string M22797_InvoiceCreation = "InvoiceCreation";
        #endregion[M2-2797]

        #region[M2-2857]
        public static string M22857_CreateSaveSearch = "CreateSaveSearch";
        public static string M22857_SaveSearchEmailService = "CreateSaveSearch";
        #endregion[M2-2857]

        #region[M2-2292]
        public static string M22922_Messaging = "Messaging";
        #endregion[M2-2292] 

        #region[M2-2965]
        public static string M22965_LeadStreamExternalMsg = "LeadStreamExternalMsg";
        public static string M22965_LeadStreamInternalMsg = "LeadStreamInternalMsg";
        #endregion[M2-2965]

        #region[M2-3025]
        public static string M2_3025_TransferRFQ = "TransferRFQ";
        #endregion[M2-3025]

        #region[M2-3024]
        public static string M2_3024_BlacklistingBuyerToSupplier = "BlacklistingBuyerToSupp";
        public static string M2_3024_BlacklistingSupplierToBuyer = "BlacklistingSuppToBuyer";
        #endregion[M2-3024]

        #region[M2-1748]
        public static string RFQLifeCycleDisMan_M2_1748 = "RFQLifeCycleDisManufacturer";
        #endregion[M2-1748]

        #region[M2-3055]
        public static string M2_3055_BuyerResetPasswordThroughVision = "BuyerResetPasswordVisio";
        public static string M2_3055_SupplierResetPasswordThroughVision = "SuppResetPasswordVision";
        public static string M2_3055_BuyerForgotPassword = "BuyerForgotPassword";
        public static string M2_3055_SupplierForgotPassword = "SupplierForgotPassword";
        #endregion[M2-3055]

        #region[M2-3054]
        public static string M2_3054_BuyerResetPasswordThroughSettingTab = "BuyerResetPasswordSetti";
        public static string M2_3054_SupplierResetPasswordThroughSettingTab = "SupplierResetPasswordSetting";
        public static string M2_3054_BuyerResetEmail = "BuyerResetEmail";
        public static string M2_3054_SupplierResetEmail = "SupplierResetEmail";
        #endregion[M2-3054]

        #region[M2-3081]
        public static string M2_3081_CloneRFQThroughSubmitRFQCloneButton = "CloneRFQThroughSubmitRFQButton";
        public static string M2_3081_CloneRFQThroughUpperMenuCloneButton = "CloneRFQThroughUpperMenuCloneBu";
        public static string M2_3081_CloneRFQThroughMyRFQCloneButton = "CloneRFQThroughMyRFQCloneButton";
        #endregion[M2-3081]

        #region[M2-3191]
        public static string M2_3191_SupplierProfileUpdate = "SupplierProfileUpdate";
        #endregion[M2-3191]

        #region[M2-3190]
        public static string M2_3190_BuyerProfileUpdate = "BuyerProfileUpdate";
        #endregion[M2-3190]

        #region[M2-3215]
        public static string M2_3215_DashboardFunctionality = "DashboardFunctionality";
        public static string M2_3215_DashboardWithBottomFunctionality = "DashboardWithBottomFunctionalit";
        #endregion[M2-3215]

        #region[M2-3294]
        public static string M2_3294_SupplierUserRating = "SupplierUserRating";
        public static string M2_3294_BuyerUserRating = "BuyerUserRating";
        #endregion[M2-3294]

        #region[M2-3295]
        public static string M2_3295_OpenRFQ = "OpenRFQ";
        #endregion[M2-3295]

        #region["M2-3312"]
        public static string M2_3312_SwitchAccount = "SwitchAccount";
        #endregion["M2-3312"]

        #region[M2-3333]
        public static string M2_3333_BuyerSetting = "BuyerSetting";
        public static string M2_3333_SupplierSetting = "SupplierSetting";
        #endregion[M2-3333]

        #region[M2-3344]
        public static string M2_3344_ThreadMessages = "ThreadMessages";
        public static string M2_3344_DiscoverManufacturerMessaging = "DiscoverManufacturerMessaging";
        public static string M2_3344_ContactListMessaging = "ContactListMessaging";
        public static string M2_3344_ManufacturerViewsMessaging = "ManufacturerViewsMessaging";
        public static string M2_3344_MFGContactsMessaging = "MFGContactsMessaging";
        public static string M2_3344_QuoateTabMessaging = "QuoateTabMessaging";
        #endregion[M2-3344]

        #region[M2-3394]
        public static string M2_3394_ActionTrackerSupplierTab = "ActionTrackerSupplierTab";
        #endregion[M2-3394]]

        #region[001]
        public static string RetriveDataFromDatabase = "RetriveDataFromDatabase";
        #endregion[002]

        #region[002]
        public static string InsertDataFromDatabase = "InsertDataFromDatabase";
        #endregion[002]

        #endregion[TestCaes]
    }
}
