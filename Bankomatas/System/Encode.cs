using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomatas.System
{
    public static class Encode
    {
        private static char[] Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public static string EncodeToString(string pin)
        {
            string encodedString = "";
            char[] pinChars = pin.ToCharArray();
            for(var i = 0; i < pinChars.Length; i++)
            {
                int index = (int.Parse(pinChars[i].ToString()) + i) * (i + 1);
                encodedString += Alphabet[index];
            }
            return encodedString;
        }

        public static string DecodedToString(string pinEncoded)
        {
            string decodedString = "";
            char[] pinEncodedChars = pinEncoded.ToCharArray();
            for(var i = 0; i < pinEncodedChars.Length; i++ )
            {
                int index = Array.IndexOf(Alphabet, pinEncodedChars[i]);
                decodedString += ((index / (i + 1)) - i).ToString();
            }
            return decodedString;
        }
    }
}
