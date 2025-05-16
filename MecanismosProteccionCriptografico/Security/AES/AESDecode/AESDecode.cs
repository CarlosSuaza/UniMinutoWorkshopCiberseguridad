using System;
using System.Text;
using System.Security.Cryptography;

namespace Security.AES.Decode
{
    public class AESDecode
    {
        public static string DecodificarAES(string cipherText, string key)
        {
            // convertir Mensaje de Entrada y Llave a Bytes
            byte[] clave = Encoding.UTF8.GetBytes(key); 
            byte[] textoCifradoBytes = Convert.FromBase64String(cipherText);  

            // Usar la Libreria de Criptografia
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                // Asignar los atributos de cifrado correspondientes al metodo de cifrado
                aes.Key = clave;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.IV = Encoding.UTF8.GetBytes(key.Substring(0,16));

                // Instanciar el metodo de decifrado a usar       
                ICryptoTransform decifrador = aes.CreateDecryptor();

                // Usar el metodo y darle tratamiento a los bloques de datos
                byte[] textoDecifradoBytes = decifrador.TransformFinalBlock(textoCifradoBytes, 0, textoCifradoBytes.Length);

                // Formatear la informacion en el formato requerido por el proceso
                string textoDecifrado = Encoding.UTF8.GetString(textoDecifradoBytes);

                // Salida de la informacio decifrada
                return textoDecifrado;             
            }      
        }
    }
}