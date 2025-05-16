using System;
using System.Text;

namespace Security.Binario.Decode
{
    public class BinarioDecode
    {
        public static string DecodificarBinario(string binaryText)
        {
            string[] binaryChars = binaryText.Split(' ');
            StringBuilder textResult = new StringBuilder();

            foreach (string binaryChar in binaryChars)
            {
                int asciiCode = Convert.ToInt32(binaryChar, 2); // Convertir de binario a entero
                char character = (char)asciiCode;              // Convertir de entero a carácter
                textResult.Append(character);
            }
            return textResult.ToString();
        }
    }
}