﻿using System.Text.Json.Serialization;

namespace OtpManager2.Models
{
    public class ConfigItem
    {
        /// <summary>
        /// The name of the configuration item
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Id of the hotkey when registered in windows
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// The Modifier Key (Alt, Ctrl, Shift, Win, etc) for the hotkey
        /// </summary>
        public int modifier { get; set; }

        /// <summary>
        /// The Key (A, B, C, 1, 2, 3, F1, F2, F3, etc) for the hotkey
        /// </summary>
        public int key { get; set; }

        /// <summary>
        /// The value of the configuration item, encrypted using the Cryptography class
        /// </summary>
        [JsonPropertyName("value")]
        public string encryptedValue { get; set; }

        /// <summary>
        /// The (decrypted plainText) value of the configuration item
        /// </summary>
        [JsonIgnore]
        public string value
        {
            get => Cryptography.Decrypt(encryptedValue);
            set => encryptedValue = Cryptography.Encrypt(value);
        }

        /// <summary>
        /// Flag to determine if the configuration item is an OTP (One-Time Password) or a regular string
        /// </summary>
        public bool isOTP { get; set; }
    }
}
