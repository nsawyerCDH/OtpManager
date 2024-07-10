using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtpManager.Models
{
    public class ConfigItem
    {
        public string argId { get; set; }
        public string value { get; set; }
        public bool isOTP { get; set; }
    }
}
