using System;
using System.Text;
using System.Security.Cryptography;

namespace Security.DES.Decode
{
    public class DESDecode
    {
        public DESDecode(){}

        public static string DecodificarDES(string cipherText, string key)
        {
            byte[] clave = Encoding.UTF8.GetBytes(key); // Clave de 8 bytes para DES
            byte[] textoCifradoBytes = Convert.FromBase64String(cipherText);

            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = clave;
                des.IV = clave;
                des.Mode = CipherMode.CBC;

                ICryptoTransform descifrador = des.CreateDecryptor();

                byte[] textoDescifradoBytes = descifrador.TransformFinalBlock(textoCifradoBytes, 0, textoCifradoBytes.Length);

                string textoDescifrado = Encoding.UTF8.GetString(textoDescifradoBytes);
                return textoDescifrado;
            }            
        }
    }
}