using System;
using System.Text;

namespace Security.Binario.Encode
{
    public class BinarioEncode
    {
        public static string CodificarBinario(string plaintext)
        {
            StringBuilder binaryResult = new StringBuilder();
            foreach (char c in plaintext)
            {
                string binaryChar = Convert.ToString(c, 2).PadLeft(8, '0'); // 8 bits por carácter
                binaryResult.Append(binaryChar + " ");
            }
            return binaryResult.ToString().Trim();
        }
    }
}