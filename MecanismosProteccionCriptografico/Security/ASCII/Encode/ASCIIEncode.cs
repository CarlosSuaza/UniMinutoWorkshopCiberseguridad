using System;
using System.Text;

namespace Security.ASCII.Encode
{
    public class ASCIIEncode
    {
        public static string CodificarASCII(string plaintext)
        {
            StringBuilder encryptedResult = new StringBuilder();
            foreach (char c in plaintext)
            {
                int encryptedChar = c + 5; // Transformación fija (suma constante)
                encryptedResult.Append((char)encryptedChar); // Convertir de vuelta a carácter
            }
            return encryptedResult.ToString();
        }
    }
}