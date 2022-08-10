using MFG_Automation.Generics;
using MFGAutomation.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace MFG_Automation.TestData
{
    class LoginReader : CommonProperties
    { 
        /// <summary>
        /// Read XML file.
        /// </summary>
        /// <param name="loginData"></param>
        /// <param name="module"></param>
        public static void Readxml(string loginData, string module)
        {
            try
            {
                XDocument doc = XDocument.Load(loginData);
                var query = doc.Descendants(module).Elements()
                    .ToDictionary(x => x.Attribute("key").Value,
                        x => x.Value);

                foreach (KeyValuePair<string, string> pair in query)
                {
                    #region[BuyerData]
                    if (module == "BuyerData")
                    {
                        string value = pair.Value;
                        string key = pair.Key;
                        if (key == "BuyerUserName")
                        {
                            BuyerUserName = value;
                        }
                        else if (key == "BuyerPassword")
                        {
                            BuyerPassword = value;
                        }
                    }
                    #endregion[BuyerData]

                    #region[ManufacturerData]
                    if (module == "ManufacturerData")
                    {
                        string value = pair.Value;
                        string key = pair.Key;
                        if (key == "ManufacturerUserName")
                        {
                            ManufacturerUserName = value;
                        }
                        else if (key == "ManufacturerPassword")
                        {
                            ManufacturerPassword = value;
                        }
                    }
                    #endregion[ManufacturerData]
                    else
                    {
                        Console.WriteLine("No key is matched");
                    }
                }   
            }
            catch (Exception ex)
            {
                Logs.Error($"Unable to read LoginInfo file {ex}");
                throw;
            }
        }
    }
}
