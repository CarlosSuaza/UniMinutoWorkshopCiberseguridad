using System;
using System.Text;
using System.Numerics;

namespace Security.Base58.Encode
{
    public class Base58Encode
    {
        private const string Alphabet = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";

        public static string CodificarBase58(string plaintext)
        {
            byte[] datosBytes = Encoding.UTF8.GetBytes(plaintext);
            BigInteger intData = new BigInteger(datosBytes.Reverse().ToArray()); // Convertir a BigInteger

            var result = new StringBuilder();
            while (intData > 0)
            {
                int remainder = (int)(intData % 58);
                intData /= 58;
                result.Insert(0, Alphabet[remainder]);
            }

            // Agregar prefijos '1' para cada byte 0 al inicio
            foreach (byte b in datosBytes)
            {
                if (b == 0)
                    result.Insert(0, '1');
                else
                    break;
            } 
            
            return result.ToString();           
        }
    }
}