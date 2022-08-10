////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: ConfigReader.cs
//Description : Refers to the functions to read config file details
////////////////////////////////////////////////////////////////////////////////////////////////////////

using MFG_Automation.Generics;
using MFGAutomation.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace MFGAutomation.Configurations
{
    /// <summary>
    /// Reads XML file to map configuration data with variables
    /// </summary>
    /// <param name="testDataFile"></param>
    /// <param name="module"></param>
    public class ConfigReader : CommonProperties
    {
        public static void Readxml(string testDataFile, string module)
        {
            try
            {
                XDocument doc = XDocument.Load(testDataFile);
                var query = doc.Descendants(module).Elements()
                    .ToDictionary(x => x.Attribute("key").Value,
                        x => x.Value);

                foreach (KeyValuePair<string, string> pair in query)
                {
                    #region[EnvironmentSetUp]
                    if (module == "EnvironmentSetUp")
                    {
                        string value = pair.Value;
                        string key = pair.Key;
                        if (key == "TestURL")
                        {
                            TestURL = value;
                        }
                        else if (key == "Browser")
                        {
                            Browser = value;
                        }
                    }
                    #endregion[EnvironmentSetUp]

                    #region[EnvironmentSetUpVision]
                    if (module == "EnvironmentSetUpVision")
                    {
                        string value = pair.Value;
                        string key = pair.Key;
                        if (key == "VisionURL")
                        {
                            VisionURL = value;
                        }
                        else if (key == "Browser")
                        {
                            Browser = value;
                        }
                    }
                    #endregion[EnvironmentSetUpVision]

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

                    #region[VisionData]
                    if (module == "VisionData")
                    {
                        string value = pair.Value;
                        string key = pair.Key;
                        if (key == "VisionUserName")
                        {
                            VisionUserName = value;
                        }
                        else if (key == "VisionPassword")
                        {
                            VisionPassword = value;
                        }
                    }
                    #endregion[VisionData]    
                    else
                    {
                        Console.WriteLine("No key is matched");
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.Error($"Unable to read con-fig file {ex}");
                throw;
            }
        }
    }
}
