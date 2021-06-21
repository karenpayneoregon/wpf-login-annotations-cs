using System;
using System.Diagnostics;
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
            Debug.WriteLine(TestContext.CurrentTestOutcome == UnitTestOutcome.Failed ? 
                $"{TestContext.TestName} Failed" :
                "No because of ExpectedException");
        }

        /// <summary>
        /// Shows how to record an exception to the test
        /// output window
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AssertFailedException), 
            "Expected AssertFailedException")]
        public void CauseException()
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
        
        /// <summary>
        /// Caller <see cref="CauseException"/> will cause an exception
        /// which will write exception details to the output window
        /// via <see cref="WriteException"/> method.
        /// </summary>
        /// <param name="action"></param>
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
