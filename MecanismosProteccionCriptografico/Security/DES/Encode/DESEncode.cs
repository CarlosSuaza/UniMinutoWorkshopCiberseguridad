using System;
using System.Text;
using System.Security.Cryptography;

namespace Security.DES.Encode
{
    public class DESEncode
    {
        public DESEncode(){}

        public static string CodificarDES(string plainText, string key)
        {
            byte[] clave = Encoding.UTF8.GetBytes(key); // Clave de 8 bytes para DES
            byte[] textoBytes = Encoding.UTF8.GetBytes(plainText);

            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = clave;
                des.IV = clave;
                des.Mode = CipherMode.CBC;

                ICryptoTransform cifrador = des.CreateEncryptor();

                byte[] textoCifradoBytes = cifrador.TransformFinalBlock(textoBytes, 0, textoBytes.Length);

                string textoCifrado = Convert.ToBase64String(textoCifradoBytes);
                return textoCifrado;
            }            
        }
    }
}