using Base32;
using OtpSharp;
using System;
using System.Windows.Forms;

namespace OtpManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: OtpManager.exe <arg1>");
                return;
            }

            string argId = args[0].Trim().ToLower();

            if (args.Length > 1)
                ConfigReader.configPath = args[1].Trim().ToLower();            

            //Read from the AppConfig file
            var config = ConfigReader.Read(ConfigReader.configPath);

            //Sleep for 100 ms
            System.Threading.Thread.Sleep(100);

            //Loop through the config items to find the matching argId to the given argument
            foreach (var configItem in config.Items)
            {
                if (configItem.argId.Trim().ToLower() == argId)
                {
                    if (configItem.isOTP)
                        TypeStr(GetOtp(configItem.value));

                    else
                        TypeStr(configItem.value);

                    //Exit the loop
                    break;
                }
            }

            //Sleep for 100 ms before closing
            System.Threading.Thread.Sleep(100);
        }

        static string GetOtp(string base32Secret)
        {
            // Decode the base32 secret and create a TOTP object
            var bytes = Base32Encoder.Decode(base32Secret);
            var totp = new Totp(bytes);

            // Generate the OTP and return
            return totp.ComputeTotp();
        }

        static void TypeStr(string value)
        {
            foreach (char c in value)
            {
#if DEBUG
                //write the character to the console.  Only works in debug mode
                Console.Write(c);
#else
                //type the character.  Only works in release mode
                SendKeys.SendWait(c.ToString());
#endif
                //sleep for 30 ms
                System.Threading.Thread.Sleep(30);
            }
        }
    }
}
