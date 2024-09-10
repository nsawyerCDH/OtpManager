using OtpManager2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace OtpManager2
{
    public static class ConfigReader
    {
        public static string defaultConfigDir => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string defaultConfigName => $"{Application.ProductName}_config.json";
        public static string defaultConfigPath => Path.Combine(defaultConfigDir, defaultConfigName);

        public static string configPath = defaultConfigPath;

        public static bool isDefaultPath => configPath == defaultConfigPath;

        public static ConfigHead Read(string configPath, bool createIfNotExists = true)
        {
            //Check if the file exists
            if (createIfNotExists && !File.Exists(configPath))
                Write(configPath, CreateSample(configPath));

            //Read the JSON from the file
            string jsonStr = File.ReadAllText(configPath);

            //Deserialize the JSON to a ConfigHead object
            return JsonSerializer.Deserialize<ConfigHead>(jsonStr);
        }

        public static ConfigHead CreateSample(string configPath)
        {
            //Get the current assembly version
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            //Get the current assembly name
            string name = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

            //Create a new ConfigHead object with the current version and a single example item
            ConfigHead configHead = new ConfigHead()
            {
                Name = name,
                Version = version,
                TypeBeforeDelayMs = 300,
                TypeCharDelayMs = 30,
                Items = new List<ConfigItem>()
                {
                    new ConfigItem()
                    {
                        id = 1,
                        name = "Example",
                        modifier = (int)KeyModifiers.Control,
                        key = (int)Keys.D1,
                        value = "Hello, World!",
                        valueType = ConfigItem.ValueTypes.plainText
                    }
                }
            };

            return configHead;
        }

        public static bool Write(string configPath, ConfigHead configHead)
        {
            //Update the version number in the ConfigHead object
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            configHead.Version = version;

            //Serialize the object to JSON, including formatting
            string json = JsonSerializer.Serialize(configHead, new JsonSerializerOptions() { WriteIndented = true });

            //Write the JSON to the file
            File.WriteAllText(configPath, json);

            return true;
        }
    }
}
