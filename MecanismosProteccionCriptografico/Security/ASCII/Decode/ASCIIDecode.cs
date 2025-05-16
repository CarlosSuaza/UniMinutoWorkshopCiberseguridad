using System;
using System.Text;

namespace Security.ASCII.Decode
{
    public class ASCIIDecode
    {
        public static string DecodificarASCII(string encryptedText)
        {
            StringBuilder decryptedResult = new StringBuilder();
            foreach (char c in encryptedText)
            {
                int decryptedChar = c - 5; // Invertir la transformación fija (resta constante)
                decryptedResult.Append((char)decryptedChar); // Convertir de vuelta a carácter
            }
            return decryptedResult.ToString();
        }
    }
}