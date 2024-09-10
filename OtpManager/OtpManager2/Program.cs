using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtpManager2
{
    public static class Program
    {
        /// <summary>
        /// Mutex to ensure the app is a singleton (only one instance running)
        /// </summary>
        public static Mutex mutex { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //Build the mutex name using the application name
            Program.mutex = new Mutex(true, Application.ProductName, out bool createdNew);

            //If the mutex already exists, another instance of the application is already running and we will not start a second
            if (!createdNew)
            {
                MessageBox.Show($"Another instance of {Application.ProductName} is already running.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Startup(args));
        }
    }
}
