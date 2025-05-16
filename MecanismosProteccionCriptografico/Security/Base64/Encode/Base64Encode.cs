using System;
using System.Text;

namespace Security.Base64.Encode
{
    public class Base64Encode
    {
        public static string CodificarBase64(string plaintext)
        {
            byte[] datosBytes = Encoding.UTF8.GetBytes(plaintext);
            string encodedtext = Convert.ToBase64String(datosBytes);
            return encodedtext;
        }
    }
}