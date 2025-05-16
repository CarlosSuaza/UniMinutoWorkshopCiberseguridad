using System;
using System.Text;
using System.Numerics;

namespace Security.Base58.Decode
{
    public class Base58Decode
    {
        private const string Alphabet = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";

        public static string DecodificarBase58(string encodedtext)
        {
            BigInteger intData = 0;

            foreach (char c in encodedtext)
            {
                int digit = Alphabet.IndexOf(c);
                if (digit < 0) throw new FormatException($"Carácter inválido en Base58: {c}");
                intData = intData * 58 + digit;
            }   

            // Convertir BigInteger a bytes
            byte[] bytes = intData.ToByteArray(isUnsigned: true, isBigEndian: true);   

            // Eliminar posibles ceros iniciales agregados por BigInteger
            int leadingZeros = encodedtext.TakeWhile(c => c == '1').Count();
            byte[] result = new byte[leadingZeros + bytes.Length];
            bytes.CopyTo(result, leadingZeros);   

            string plaintext = Encoding.UTF8.GetString(result);
            return plaintext;
        }
    }
}