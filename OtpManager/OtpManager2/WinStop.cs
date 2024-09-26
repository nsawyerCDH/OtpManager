using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace OtpManager2
{
    public partial class WinStop : Form
    {
        public WinStop()
        {
            InitializeComponent();

            // Set up the MaskedTextBox
            winStopMaskedTextbox.Mask = "00:00 AA"; // Format: hh:mm AM/PM
            winStopMaskedTextbox.ValidatingType = typeof(System.DateTime);
        }

        private void scheduleButton_Click(object sender, EventArgs e)
        {
            //Parse the time from the masked text box, into a DateTime object
            string timeInput = winStopMaskedTextbox.Text;
            DateTime parsedDateTime;

            //Parse the last 2 characters as AM/PM
            string amPm = timeInput.Substring(6, 2).ToUpper();

            if (amPm != "AM" && amPm != "PM")
            {
                MessageBox.Show("Invalid time format. Please use hh:mm AM/PM.");
                return;
            }

            //Try Parse the hours and minutes
            if (int.TryParse(timeInput.Substring(0, 2), out int hours) && int.TryParse(timeInput.Substring(3, 2), out int minutes))
            {
                //If PM, add 12 hours to the hours
                if (amPm == "PM")
                {
                    hours += 12;
                }

                // Combine the current date with the parsed time
                parsedDateTime = DateTime.Today.Date.AddHours(hours).AddMinutes(minutes);
            }
            else
            {
                MessageBox.Show("Invalid time format. Please use hh:mm AM/PM.");
                return;
            }

            //Check if the time is in the past
            if (parsedDateTime < DateTime.Now)
            {
                MessageBox.Show("The time you entered is in the past. Please enter a time in the future.");
                return;
            }

            //Calculate the time until the scheduled shutdown
            TimeSpan timeUntilShutdown = parsedDateTime - DateTime.Now;

            // Start a new command line process
            var cmdProcess = new Process();
            cmdProcess.StartInfo.FileName = "cmd.exe";
            cmdProcess.StartInfo.UseShellExecute = false;
            cmdProcess.StartInfo.CreateNoWindow = false;
            cmdProcess.Start();

            System.Threading.Thread.Sleep(1000);
            Application.DoEvents();
            System.Threading.Thread.Sleep(1000);

            //Send cmd to cancel any previously scheduled shutdowns
            Startup.TypeStr("shutdown -a");
            System.Threading.Thread.Sleep(100);
            SendKeys.SendWait("{ENTER}");

            System.Threading.Thread.Sleep(1000);

            //Send cmd to shutdown at the specified time
            Startup.TypeStr($"shutdown -s -t {Math.Round(timeUntilShutdown.TotalSeconds, 0)}");
            System.Threading.Thread.Sleep(100);
            SendKeys.SendWait("{ENTER}");
            System.Threading.Thread.Sleep(1000);

            //Close the command line process
            cmdProcess.Kill();
            cmdProcess.Dispose();

            //Close the WinStop form
            this.Close();
        }
    }
}
