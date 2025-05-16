using System;
using System.Text;
using System.Security.Cryptography;

namespace Security.AES.Encode
{
    public class AESEncode
    {
        public static string CodificarAES(string plainText, string key)
        {
            // convertir Mensaje de Entrada y Llave a Bytes
            byte[] clave = Encoding.UTF8.GetBytes(key); 
            byte[] textoBytes = Encoding.UTF8.GetBytes(plainText);  

            // Usar la Libreria de Criptografia
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                // Asignar los atributos de cifrado correspondientes al metodo de cifrado
                aes.Key = clave;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.IV = Encoding.UTF8.GetBytes(key.Substring(0,16));

                // Instanciar el metodo de cifrado a usar
                ICryptoTransform cifrador = aes.CreateEncryptor();

                // Usar el metodo y darle tratamiento a los bloques de datos
                byte[] textoCifradoBytes = cifrador.TransformFinalBlock(textoBytes, 0, textoBytes.Length);

                // Formatear la informacion en el formato requerido por el proceso
                string textoCifrado = Convert.ToBase64String(textoCifradoBytes);

                // Salida de la informacio cifrada
                return textoCifrado;                
            }
        }
    }
}