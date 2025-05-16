using System;
using System.Text;

namespace Security.Base64.Decode
{
    public class Base64Decode
    {
        public static string DecodificarBase64(string encodedtext)
        {
            byte[] datosBytes = Convert.FromBase64String(encodedtext);
            string plaintext = Encoding.UTF8.GetString(datosBytes);
            return plaintext;
        }
    }
}