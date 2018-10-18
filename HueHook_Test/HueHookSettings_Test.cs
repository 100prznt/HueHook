using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rca.HueHook;

namespace Rca.HueHook_Test
{
    [TestClass]
    public class HueHookSettings_Test
    {
        [TestMethod]
        public void WriteSettingsToXml()
        {
            var testObject = GenDummySettings();

            testObject.ToFile("HueHookSettings_Test_WriteSettingsToXml.xml");
        }

        [TestMethod]
        public void ReadSettingsFromXml()
        {
            var dummy = GenDummySettings();

            dummy.ToFile("HueHookSettings_Test_ReadSettingsFromXml.xml");

            var testObject = HueHookSettings.FromFile("HueHookSettings_Test_ReadSettingsFromXml.xml");

            Assert.AreEqual(dummy.BridgeIp, testObject.BridgeIp);
            Assert.AreEqual(dummy.BridgeUsername, testObject.BridgeUsername);
            Assert.AreEqual(dummy.LocalServerIp, testObject.LocalServerIp);
            Assert.AreEqual(dummy.LocalServerPort, testObject.LocalServerPort);
            Assert.AreEqual(dummy.WhiteList.IpAddresses.Length, testObject.WhiteList.IpAddresses.Length);
            Assert.AreEqual(dummy.WhiteList.IpAddresses[0], testObject.WhiteList.IpAddresses[0]);
            Assert.AreEqual(dummy.WhiteList.Disabled, testObject.WhiteList.Disabled);
            Assert.AreEqual(dummy.LogPath, testObject.LogPath);
        }

        HueHookSettings GenDummySettings()
        {
            return new HueHookSettings()
            {
                BridgeIp = IPAddress.Parse("192.168.0.100"),
                BridgeUsername = "Bridge-Username-123",
                LocalServerIp = IPAddress.Parse("192.168.0.1"),
                LocalServerPort = 8008,
                WhiteList = new IpWhiteList()
                {
                    IpAddresses = new IPAddress[4]
                    {
                        IPAddress.Parse("192.168.0.101"),
                        IPAddress.Parse("192.168.0.102"),
                        IPAddress.Parse("192.168.0.103"),
                        IPAddress.Parse("192.168.0.104")
                    },
                    Disabled = true
                },
                LogPath = "C:\\temp\\LogPath"
            };
        }
    }
}
