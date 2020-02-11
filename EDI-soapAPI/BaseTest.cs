using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using SharedAPIFramework;
using AventStack.ExtentReports;
using System.Security.Principal;
using System.Security.AccessControl;
using EDI_soapAPI;

namespace EDI_soapAPI
{
    public class BaseTest : SharedAPIFramework.BaseTest
    {
        public Writer Writer { get; private set; }
        
        public SharedAPIFramework.Assert Assert { get; private set; }
        public RandomHelper Random { get; private set; }
		public Random rand { get; private set; }
        public CustomerForPLSSvc CustomerSvc { get; private set; }

        public LoadRestSvc loadRest { get; private set; }

        public Http HttpMethods { get; private set; }

        public static ExtentTest SubTest { get; private set; }

        private string path;

        private bool _testFinished;

        public static void SetFolderPermission(string folderPath)
        {
            var directoryInfo = new DirectoryInfo(folderPath);
            var directorySecurity = directoryInfo.GetAccessControl();
            var currentUserIdentity = WindowsIdentity.GetCurrent();
            var fileSystemRule = new FileSystemAccessRule(currentUserIdentity.Name,
                                                          FileSystemRights.FullControl,
                                                          InheritanceFlags.ObjectInherit |
                                                          InheritanceFlags.ContainerInherit,
                                                          PropagationFlags.None,
                                                          AccessControlType.Allow);

            directorySecurity.AddAccessRule(fileSystemRule);
            directoryInfo.SetAccessControl(directorySecurity);
        }

        private ExtentTestManager extentTestManager { get; set; }

        [OneTimeSetUp]
        public void SetupOneTime()
        {
            path = Path.Combine(Path.GetDirectoryName(new Uri(typeof(BaseTest).Assembly.CodeBase).LocalPath), "ExtentReports");
            //var path = Path.Combine(Path.GetDirectoryName(new Uri(typeof(BaseTest).Assembly.CodeBase).LocalPath), TestContext.CurrentContext.Test.FullName, DateTime.Now.ToString("MM_dd_yyyy_HH.mm.ss_tt"));
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
                Directory.CreateDirectory(path);
                SetFolderPermission(path);
            }


            ExtentTestManager.CreateParentTest(GetType().Name);

            Random = new RandomHelper();
            Writer = new Writer(path);
            Assert = new SharedAPIFramework.Assert();
			rand = new Random();
            HttpMethods = new Http(Writer, Random);
        }

        [SetUp]
        public void Setup()
        {
            SubTest = ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name, TestContext.CurrentContext.Test.Properties.Get("Description").ToString());
            _testFinished = false;
        }

        public void InitializeService(AuthResponse authDetails)
        {
            var helper = new RandomHelper();
            IntializeServices(Writer, helper, authDetails);
        }

        public void IntializeServices(Writer writer, RandomHelper random, AuthResponse authDetails)
        {
            CustomerSvc = new CustomerForPLSSvc(new Dictionary<string, string>() { { "Authorization", "Bearer " + authDetails.access_token.ToString() } }, random, writer);
            loadRest = new LoadRestSvc(new Dictionary<string, string>() { { "Authorization", "Bearer " + authDetails.access_token.ToString() } }, random, writer);
        }


        [TearDown]
        public void TearDown()
        {
            if (!_testFinished)
            {
                try
                {
                    var status = TestContext.CurrentContext.Result.Outcome.Status;
                    var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);
                    Status logstatus;

                    switch (status)
                    {
                        case TestStatus.Failed:
                            logstatus = Status.Fail;
                            break;
                        case TestStatus.Inconclusive:
                            logstatus = Status.Warning;
                            break;
                        case TestStatus.Skipped:
                            logstatus = Status.Skip;
                            break;
                        default:
                            logstatus = Status.Pass;
                            break;
                    }

                    ExtentTestManager.GetTest().Log(logstatus, "Test ended with status: " + logstatus + stacktrace);
                }
                catch { }
            }
        }

        [OneTimeTearDown]
        public void FinalTearDown()
        {
            //Writer.Dispose();
            ExtentManager.Instance.Flush();
        }

        public DateTime RoundToNearest(DateTime time, TimeSpan span)
        {
            return new DateTime(((time.Ticks + span.Ticks - 1) / span.Ticks) * span.Ticks);
        }
    }
}
