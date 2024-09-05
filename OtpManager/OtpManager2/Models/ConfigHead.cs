using System.Collections.Generic;

namespace OtpManager2.Models
{
    public class ConfigHead
    {
        /// <summary>
        /// The Name of the application that the configuration file is for
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Version of the application that the configuration file is for
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// The Configuration file password.  Required to edit the configuration file via the front-end UI
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The number of Milliseconds to wait before typing the first character
        /// </summary>
        public int TypeBeforeDelayMs { get; set; }

        /// <summary>
        /// The number of Milliseconds to wait between typing each character
        /// </summary>
        public int TypeCharDelayMs { get; set; }

        /// <summary>
        /// The list of configuration items
        /// </summary>
        public List<ConfigItem> Items { get; set; }
    }
}
