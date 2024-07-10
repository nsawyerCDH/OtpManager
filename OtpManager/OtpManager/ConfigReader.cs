using OtpManager.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace OtpManager
{
    public static class ConfigReader
    {
        public static string defaultConfigDir => Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static string defaultConfigName => "config.json";

        public static string configPath = Path.Combine(defaultConfigDir, defaultConfigName);

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
            ConfigHead configHead = new ConfigHead
            {
                Name = name,
                Version = version,
                Items = new List<ConfigItem>()
                {
                    new ConfigItem()
                    {
                        argId = "1",
                        value = "Hello, World!",
                        isOTP = false
                    }
                }
            };

            return configHead;
        }

        public static bool Write(string configPath, ConfigHead configHead)
        {
            //Serialize the object to JSON, including formatting
            string json = JsonSerializer.Serialize(configHead, new JsonSerializerOptions() { WriteIndented = true });

            //Write the JSON to the file
            File.WriteAllText(configPath, json);

            return true;
        }
    }
}
