using System;
using System.Text;
using System.Security.Cryptography;

namespace Security.TDES.Encode
{
    public class TDESEncode
    {
        public static string CodificarTDES(string plainText, string key)
        {
            byte[] clave = Encoding.UTF8.GetBytes(key); 
            byte[] textoBytes = Encoding.UTF8.GetBytes(plainText);   

            using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
            {
                tdes.Key = clave;
                tdes.IV = Encoding.UTF8.GetBytes(key.Substring(0,8));
                tdes.Mode = CipherMode.CBC; // Usamos ECB (simple, pero menos seguro)
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cifrador = tdes.CreateEncryptor();

                byte[] textoCifradoBytes = cifrador.TransformFinalBlock(textoBytes, 0, textoBytes.Length);

                string textoCifrado = Convert.ToBase64String(textoCifradoBytes);
                return textoCifrado;
            }                     
        }
    }
}