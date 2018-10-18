using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rca.HueHookService;

namespace Rca.HueHookService_Test
{
    [TestClass]
    public class InherentLogger_Test
    {
        [TestMethod]
        public void GetDefaultLogPath()
        {
            var logPath = InherentLogger.LogPath;

            Assert.IsFalse(string.IsNullOrWhiteSpace(logPath));

            InherentLogger.WriteErrorLog("InherentLogger_Test");
        }

        [TestMethod]
        public void SetLogPath()
        {
            InherentLogger.LogPath = "C:\\temp\\HueHook_Test";

            InherentLogger.WriteErrorLog("InherentLogger_Test");
        }
    }
}
