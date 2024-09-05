using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtpManager2.Models
{
    /// <summary>
    /// Define the KeyModifiers enum to specify the key modifiers that are available for the Registerand Unregister hotkey methods
    /// </summary>
    [Flags]
    public enum KeyModifiers
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        Windows = 8
    }
}
