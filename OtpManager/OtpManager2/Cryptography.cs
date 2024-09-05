using System;
using System.Security.Cryptography;
using System.Text;

namespace OtpManager2
{
    public static class Cryptography
    {
        /// <summary>
        /// Encrypt a string using the Windows Data Protection API (DPAPI).
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Encrypt(string plainText)
        {
            if (plainText == null || plainText.Length == 0)
                return "";

            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = ProtectedData.Protect(plainBytes, null, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(encryptedBytes);
        }

        /// <summary>
        /// Decrypt a string using the Windows Data Protection API (DPAPI).
        /// </summary>
        /// <param name="encryptedText"></param>
        /// <returns></returns>
        public static string Decrypt(string encryptedText)
        {
            if (encryptedText == null || encryptedText.Length == 0)
                return "";

            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            byte[] plainBytes = ProtectedData.Unprotect(encryptedBytes, null, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(plainBytes);
        }
    }
}

/**
 * Below is encryption and decryption methods that use AES encryption.  This is not used in the current version of the program.
 */
///// <summary>
///// The Cryptography key.  Used in Encrypt and Decrypt methods.
///// </summary>
//public static string CryptoKey { get; private set; }

///// <summary>
///// The Cryptography Initialization Vector (IV).  Used in Encrypt and Decrypt methods.
///// </summary>
//public static string CryptoIV { get; private set; }

///// <summary>
///// Encrypt the plain text using the CryptoKey and CryptoIV properties.
///// </summary>
///// <param name="plainText"></param>
///// <returns></returns>
//public static string Encrypt(string plainText)
//    => Encrypt(plainText, CryptoKey, CryptoIV);

///// <summary>
///// Encrypt the plain text using the given CryptoKey and CryptoIV.
///// </summary>
///// <param name="plainText"></param>
///// <param name="CryptoKey"></param>
///// <param name="CryptoIV"></param>
///// <returns></returns>
//public static string Encrypt(string plainText, string CryptoKey, string CryptoIV)
//{
//    ICryptoTransform ct;
//    MemoryStream ms;
//    CryptoStream cs;
//    byte[] byt;

//    using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
//    {
//        aes.Key = Encoding.UTF8.GetBytes(CryptoKey);
//        aes.IV = Encoding.UTF8.GetBytes(CryptoIV);
//        ct = aes.CreateEncryptor(aes.Key, aes.IV);
//    }

//    byt = Encoding.UTF8.GetBytes(plainText);
//    ms = new MemoryStream();
//    cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
//    cs.Write(byt, 0, byt.Length);
//    cs.Close();

//    return Convert.ToBase64String(ms.ToArray());
//}

///// <summary>
///// Decrypt the encrypted text using the CryptoKey and CryptoIV properties.
///// </summary>
///// <param name="encryptedText"></param>
///// <returns></returns>
//public static string Decrypt(string encryptedText)
//   => Decrypt(encryptedText, CryptoKey, CryptoIV);

///// <summary>
///// Decrypt the encrypted text using the given CryptoKey and CryptoIV.
///// </summary>
///// <param name="encryptedText"></param>
///// <param name="CryptoKey"></param>
///// <param name="CryptoIV"></param>
///// <returns></returns>
//public static string Decrypt(string encryptedText, string CryptoKey, string CryptoIV)
//{
//    ICryptoTransform ct;
//    MemoryStream ms;
//    CryptoStream cs;
//    byte[] byt;

//    using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
//    {
//        aes.Key = Encoding.UTF8.GetBytes(CryptoKey);
//        aes.IV = Encoding.UTF8.GetBytes(CryptoIV);
//        ct = aes.CreateDecryptor(aes.Key, aes.IV);
//    }

//    byt = Convert.FromBase64String(encryptedText);
//    ms = new MemoryStream();
//    cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
//    cs.Write(byt, 0, byt.Length);
//    cs.Close();

//    return Encoding.UTF8.GetString(ms.ToArray());
//}
