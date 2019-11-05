using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Autodesk.Revit.DB;


namespace ApiViet.Helpers
{
    /// <summary>
    ///     Inspired by the source on github
    ///     https://github.com/KennanChan/RevitFileUtility
    /// </summary>
    internal static class FileUtils
    {
        /// <summary>
        /// Returns the scale of a document assuming a meter as the base unit.  So meters should be 1.0, feet should be 0.3048 and so on.
        /// </summary>
        /// <param name="doc">Revit document to get the scale</param>
        /// <returns>Scale of the units compared to meters.</returns>
        public static double RevitScaleToMeters(Document doc)
        {
            double scale = 1.0;

            Units units = doc.GetUnits();
            FormatOptions fo = units.GetFormatOptions(UnitType.UT_Length);
            DisplayUnitType dut = fo.DisplayUnits;
            switch (dut)
            {
                case DisplayUnitType.DUT_CENTIMETERS:
                    scale = 0.01;
                    break;
                case DisplayUnitType.DUT_DECIMAL_FEET:
                    scale = 0.3048;
                    break;
                case DisplayUnitType.DUT_DECIMAL_INCHES:
                    scale = 0.0254;
                    break;
                case DisplayUnitType.DUT_DECIMETERS:
                    scale = 0.1;
                    break;
                case DisplayUnitType.DUT_FEET_FRACTIONAL_INCHES:
                    scale = 0.3048;
                    break;
                case DisplayUnitType.DUT_FRACTIONAL_INCHES:
                    scale = 0.0254;
                    break;
                case DisplayUnitType.DUT_MILLIMETERS:
                    scale = 0.001;
                    break;
                case DisplayUnitType.DUT_METERS:
                    scale = 1.0;
                    break;
                case DisplayUnitType.DUT_METERS_CENTIMETERS:
                    scale = 1.0;
                    break;
                default:
                    scale = 1.0;
                    break;
            }

            return scale;
        }

        /// <summary>
        /// Log usage of in-house commands to a CSV file
        /// </summary>
        /// <param name="commandName">Name of the command used</param>
        /// <param name="appVersion">Revit version</param>
        /// <param name="userName">User who used the command</param>
        public static void WriteToHome(string commandName, string appVersion, string userName)
        {
            try
            {
                // Check to see if the log file exists
                string logPath = GetPath("RevitCommon/paths/log-path");
                if (string.IsNullOrEmpty(logPath))
                    return;

                // Get the current year so app usage is organized into different files by year
                string year = DateTime.Now.Year.ToString();

                // Path to where the log is stored
                string userLogFilePath = logPath.Replace("[YEAR]", year);

                // If the file already exists, just append a new line to the end of the file.
                if (File.Exists(userLogFilePath))
                {
                    using (StreamWriter sw = File.AppendText(userLogFilePath))
                    {
                        sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "," + userName + "," + commandName + "," + appVersion);
                    }
                }
                // If the file doesn't exist but the directory does, create the file and add the one line to it.
                else if (new FileInfo(userLogFilePath).Directory.Exists)
                {
                    string[] newData = { "DATE & TIME, USERNAME, PLUGIN NAME, APPLICATION", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "," + userName + "," + commandName + "," + appVersion };
                    File.WriteAllLines(userLogFilePath, newData);
                }
                // else it probably is being run outside of network or the file is busy.
            }
            catch { } // FileUtils failed, but as it doesn't affect the user we'll ignore
        }

        /// <summary>
        /// Helper method for reading the RevitCommon.config file. This takes an XML Node path and returns
        /// the first path that satisfies it. It's intended for the RevitCommon/paths section of the file
        /// and will attempt to build a valid file path.
        /// </summary>
        /// <param name="xmlNodePath"></param>
        /// <returns></returns>
        public static string GetPath(string xmlNodePath)
        {
            string path = string.Empty;
            var directoryInfo = new FileInfo(typeof(FileUtils).Assembly.Location).Directory;
            if (directoryInfo == null)
                return null;

            var configPath = directoryInfo.FullName + "\\RevitCommon.config";
            if (!File.Exists(configPath))
                return null;

            var configStr = File.ReadAllText(configPath);
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.LoadXml(configStr);
                XmlNode node = xDoc.SelectSingleNode(xmlNodePath);
                path = node.InnerText;

                // Check to see if the path is a directory
                if (!Directory.Exists(path))
                {
                    // Check to see if it's a number
                    if (!double.TryParse(path, out double numCheck))
                    {
                        // Check to see if it is instead a file
                        var fileDir = new FileInfo(path).Directory;
                        if ((fileDir != null && !Directory.Exists(fileDir.FullName)) || fileDir == null)
                            return null;
                    }
                }
            }
            catch
            {
                return null;
            }

            return path;
        }

        /// <summary>
        /// This method will attempt to get plugin data from the RevitCommon.config file. This is for the plugins I've made that are
        /// released publicly via github (basically what I created at LMN Architects). This way I can have them default to the HKS tab
        /// for deploying locally, and anyone else that downloads them can set them to their own Tab/Panel locations on the Ribbon.
        /// </summary>
        /// <param name="pluginName"></param>
        /// <param name="helpPath"></param>
        /// <param name="tabName"></param>
        /// <param name="panelName"></param>
        /// <returns></returns>
        public static bool GetPluginSettings(string pluginName, out string helpPath, out string tabName, out string panelName)
        {
            helpPath = null;
            tabName = null;
            panelName = null;
            string configPath = new FileInfo(typeof(FileUtils).Assembly.Location).Directory.FullName + "\\RevitCommon.config";
            if (!File.Exists(configPath))
            {
                return false;
            }

            // Load the XmlDocument that contains the settings
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(configPath);
            }
            catch
            {
                return false;
            }

            // Look for plugin nodes
            XmlNodeList nodes = xDoc.SelectNodes("RevitCommon/plugin");
            XmlNode pNode = null;
            foreach (XmlNode n in nodes)
            {
                if (n.Attributes != null && n.Attributes["name"].Value == pluginName)
                {
                    pNode = n;
                    break;
                }
            }

            if (pNode == null)
                return false;

            XmlNode helpNode = pNode.SelectSingleNode("help-path");
            XmlNode tabNode = pNode.SelectSingleNode("tab-name");
            XmlNode panelNode = pNode.SelectSingleNode("panel-name");

            if (helpNode != null)
            {
                if (File.Exists(helpNode.InnerText) || (Uri.TryCreate(helpNode.InnerText, UriKind.Absolute, out Uri uriResult) &&
                    (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps)))
                    helpPath = helpNode.InnerText;
                else
                {
                    var combPath = Path.Combine(Path.GetDirectoryName(typeof(FileUtils).Assembly.Location), helpNode.InnerText);
                    var uriPath = Path.GetFullPath((new Uri(combPath)).LocalPath);
                    if (!string.IsNullOrWhiteSpace(uriPath))
                        helpPath = uriPath;
                }
            }

            if (tabNode != null)
                tabName = tabNode.InnerText;
            if (panelNode != null)
                panelName = panelNode.InnerText;

            return true;
        }

        public static bool GetPluginSettings(string pluginName, out Dictionary<string, string> settings)
        {
            settings = new Dictionary<string, string>();
            string configPath = new FileInfo(typeof(FileUtils).Assembly.Location).Directory.FullName + "\\RevitCommon.config";
            if (!File.Exists(configPath))
            {
                return false;
            }

            // Load the XmlDocument that contains the settings
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(configPath);
            }
            catch
            {
                return false;
            }

            // Look for plugin nodes
            XmlNodeList nodes = xDoc.SelectNodes("RevitCommon/plugin[@name='" + pluginName + "']");
            if (nodes.Count < 1)
                return false;

            XmlNode pNode = nodes[0];
            if (pNode == null)
                return false;

            foreach (XmlNode node in pNode.ChildNodes)
            {
                if (!settings.ContainsKey(node.LocalName))
                    settings.Add(node.LocalName, node.InnerText);
                else
                    settings[node.LocalName] = node.InnerText;
            }

            return true;
        }
    }
}
