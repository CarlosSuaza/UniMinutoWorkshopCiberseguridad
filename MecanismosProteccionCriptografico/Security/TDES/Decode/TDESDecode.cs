using System;
using System.Text;
using System.Security.Cryptography;

namespace Security.TDES.Decode
{
    public class TDESDecode
    {
        public static string DecodificarTDES(string cipherText, string key)
        {
            byte[] clave = Encoding.UTF8.GetBytes(key); 
            byte[] textoCifradoBytes = Convert.FromBase64String(cipherText);  

            using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
            {
                tdes.Key = clave;
                tdes.IV = Encoding.UTF8.GetBytes(key.Substring(0,8));
                tdes.Mode = CipherMode.CBC; // Usamos ECB (simple, pero menos seguro)
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform decifrador = tdes.CreateDecryptor();

                byte[] textoDecifradoBytes = decifrador.TransformFinalBlock(textoCifradoBytes, 0, textoCifradoBytes.Length);

                string textoDecifrado = Encoding.UTF8.GetString(textoDecifradoBytes);
                return textoDecifrado;
            }            
        }
    }
}