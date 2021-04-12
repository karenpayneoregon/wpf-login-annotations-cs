using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnnotationUnitTest
{
    [TestClass]
    public class UnitTest2
    {
        public TestContext TestContext { get; set; }
        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                Console.WriteLine($"{TestContext.TestName} Failed");
                
            }
        }

        [TestMethod]
        public void TestMethod1()
        {

            TryTest(() => { Assert.IsFalse(true); });

        }

        private void WriteException(Exception exception)
        {
            TestContext.WriteLine(exception.StackTrace);
            // You can also add it to the TestContext and have access to it from TestCleanup
            TestContext.Properties.Add("StackTrace", exception.StackTrace);
            // Or...
            TestContext.Properties.Add("Exception", exception);

            
        }
        private void TryTest(Action action)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                WriteException(e);
                throw;
            }
        }
    }

}
