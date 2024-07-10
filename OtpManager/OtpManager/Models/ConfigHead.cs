using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtpManager.Models
{
    public class ConfigHead
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public List<ConfigItem> Items { get; set; }
    }
}
