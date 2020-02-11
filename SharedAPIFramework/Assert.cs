using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SharedAPIFramework
{
    public class Assert
    {
        private Writer _writer;
        public bool AssertionsFailed { get;  set; }

        // public Assert(Driver driver)
        //public Assert(Writer writer)
        //{
        //    _writer = writer;
        //    AssertionsFailed = false;
        //}

        public Assert()
        {
            //_writer = writer;
            AssertionsFailed = false;
        }
        private void TryAndLog(Action assertion, string message)
        {
            try
            {

                assertion.Invoke();
                ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Pass, message);

            }
            catch
            {
                //_writer.WriteLine(message + " Script has failed." + TestContext.CurrentContext.Test.Name);
                ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Error, message + " Script has failed." + TestContext.CurrentContext.Test.Name);
                AssertionsFailed = true;

            }
        }
        public void Fail(string message)
        {
            TryAndLog(() => NUnit.Framework.Assert.Fail(), message);

        }
        public void AreEqual(object expected, object actual, string message = "")
        {
            TryAndLog(() => NUnit.Framework.Assert.AreEqual(expected, actual), "Expected = '" + expected + "'; Actual = '" + actual + "; " + message);
        }
        public void IsTrue(bool condition, string message)
        {
            TryAndLog(() => NUnit.Framework.Assert.IsTrue(condition), message);
        }
        public void IsFalse(bool condition, string message)
        {
            TryAndLog(() => NUnit.Framework.Assert.IsFalse(condition), message);
        }
        public void Pass(string message)
        {
            IsTrue(true, message);
        }
        public void NotNull(object anObject, string message)
        {
            TryAndLog(() => NUnit.Framework.Assert.NotNull(anObject), message);
        }
        public void Greater(int arg1, int arg2, string message)
        {
            TryAndLog(() => NUnit.Framework.Assert.Greater(arg1, arg2), message);

        }
        public void log(string message)
        {
            ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Info, message);
        }
    }
}
