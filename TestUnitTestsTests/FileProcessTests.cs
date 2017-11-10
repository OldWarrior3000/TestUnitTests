using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TestUnitTests;

namespace TestUnitTestsTests
{
    [TestClass]
    public class FileProcessTests
    {
        public TestContext TestContext { get; set; }
        private const string FILENAME_BAD = @"C:\bad.bad";
        private const string FILENAME_GOOD = @"C:\Windows\System32\cmd.exe";
        private string CreatedFileName = string.Empty;

        [TestInitialize]
        public void TestInitialize()
        {
            TestContext.WriteLine("Initializing ...");
            if ( TestContext.TestName.StartsWith("FileName_CheckCreatedFile"))
            {
                TestContext.WriteLine("Executing {0}", "FileName_CheckCreatedFile");
                CreatedFileName = Path.GetTempFileName();
                TestContext.WriteLine("File name: {0}", CreatedFileName);
                File.AppendAllText(CreatedFileName, "Test ...");
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            TestContext.WriteLine("Cleaning ...");
            if (TestContext.TestName.StartsWith("FileName_CheckCreatedFile"))
            {
                new FileInfo(CreatedFileName).TryDelete();
            }
        }

        [TestMethod]
        [Owner("OldWarrior")]
        [TestCategory("Basic")]
        public void FileNameExists_Bad()
        {
            TestContext.WriteLine("Executing FileNameExists_bad");

            FileProcess fileProcess = new FileProcess();
            Assert.IsFalse(fileProcess.FileExists(FILENAME_BAD));
        }

        [TestMethod]
        [Owner("OldWarrior")]
        [TestCategory("Basic")]
        public void FileName_Good()
        {
            FileProcess fileProcess = new FileProcess();
            Assert.IsTrue(fileProcess.FileExists(FILENAME_GOOD));
        }

        [TestMethod]
        [Owner("OldWarrior")]
        [TestCategory("Advanced")]
        public void FileName_CheckSizeBiggerThan1KB()
        {
            FileProcess fileProcess = new FileProcess();
            Assert.IsTrue(fileProcess.GetFileInfo(FILENAME_GOOD).Length > 1024);
        }


        [TestMethod]
        [Owner("OldWarrior")]
        [TestCategory("Advanced")]
        public void FileName_CheckCreatedFile()
        {
            FileProcess fileProcess = new FileProcess();
            Assert.IsTrue(fileProcess.GetFileInfo(FILENAME_GOOD).Length > 1024);
        }
    }
}
