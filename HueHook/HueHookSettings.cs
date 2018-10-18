﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Rca.HueHook
{
    [Serializable]
    public class HueHookSettings
    {
        #region Properties
        [XmlIgnore]
        public IPAddress BridgeIp { get; set; }

        [XmlElement(nameof(BridgeIp))]
        public string BridgeIpString
        {
            get
            {
                return BridgeIp.ToString();
            }
            set
            {
                BridgeIp = IPAddress.Parse(value);
            }
        }

        public string BridgeUsername { get; set; }

        [XmlIgnore]
        public IPAddress LocalServerIp { get; set; }

        [XmlElement(nameof(LocalServerIp))]
        public string LocalServerIpString
        {
            get
            {
                return LocalServerIp.ToString();
            }
            set
            {
                LocalServerIp = IPAddress.Parse(value);
            }
        }

        public int LocalServerPort { get; set; } //Default-Port (8008 HTTP-Alternativ)

        /// <summary>
        /// Whitelist
        /// </summary>
        public IpWhiteList WhiteList { get; set; }

        /// <summary>
        /// Path to the logging files
        /// </summary>
        public string LogPath { get; set; }

        #endregion Properties

        #region Constructor
        public HueHookSettings()
        {
            WhiteList = new IpWhiteList();
        }
        #endregion Constructor

        #region Services
        /// <summary>
        /// Load <seealso cref="HueHookSettings"/> from the default AppData path.
        /// </summary>
        /// <returns><seealso cref="HueHookSettings"/> object</returns>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="FileLoadException"></exception>
        public static HueHookSettings Load()
        {
            return FromFile(GetDefaultSettingsPath());
        }

        /// <summary>
        /// Load <seealso cref="HueHookSettings"/> from a file.
        /// </summary>
        /// <param name="path">Path to the settings file</param>
        /// <returns><seealso cref="HueHookSettings"/> object</returns>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="FileLoadException"></exception>
        public static HueHookSettings FromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Settings file (" + path + ") not found!");

            var settings = new HueHookSettings();
            try
            {
                using (var fs = new FileStream(path, FileMode.Open))
                {
                    var xs = new XmlSerializer(typeof(HueHookSettings));
                    settings = (HueHookSettings)xs.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                throw new FileLoadException("Can not load settings file (" + path + "), wrong format!", ex);
            }

            return settings;
        }

        /// <summary>
        /// Load <seealso cref="HueHookSettings"/> from a file, if the file not exists, returns new <seealso cref="HueHookSettings"/>-object
        /// </summary>
        /// <param name="path">Path to the settings file</param>
        /// <returns><seealso cref="HueHookSettings"/> object</returns>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="FileLoadException"></exception>
        public static HueHookSettings FromFileOrCreate(string path)
        {
            if (File.Exists(path))
                return FromFile(path);
            else
                return new HueHookSettings();
        }

        /// <summary>
        /// Write settings to file
        /// </summary>
        /// <param name="path">Path to the settings file</param>
        /// <exception cref="ArgumentException"></exception>
        public void ToFile(string path)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    var dirPath = Path.GetDirectoryName(path);
                    if (!string.IsNullOrWhiteSpace(dirPath))
                        Directory.CreateDirectory(dirPath);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Can not create settings directory (" + path + ")!", ex);
            }

            try
            {
                using (var fs = new FileStream(path, FileMode.Create))
                {
                    var xs = new XmlSerializer(typeof(HueHookSettings));
                    xs.Serialize(fs, this);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Can not write settings file (" + path + ")!", ex);
            }
        }

        public static string GetDefaultSettingsPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HueHook", "Settings.xml");
        }
        #endregion Services
    }
}
