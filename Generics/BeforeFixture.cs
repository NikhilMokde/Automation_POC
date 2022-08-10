/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: BeforeFixture.cs
//Description : Execute command or code which needs to execute before start test plan TestFixture execution and after it 
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using MFGAutomation.Generics;
using NUnit.Framework;
using System;
namespace MFG_Atomation.TestPlan
{
    /// <summary>
    /// Execute command or code which needs to execute before start test plan TestFixture execution and after it 
    /// </summary>
    [SetUpFixture]
    class BeforeFixture : CommonProperties
    {
        [OneTimeSetUp]
        public void StartReport()
        {
            Console.WriteLine("Execution started");
        }
        [OneTimeTearDown]
        public void LogReport()
        {
            Extent.Flush();
        }
    }
}
