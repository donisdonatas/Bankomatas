using System;

namespace Bankomatas.System
{
    public static class RandomDigit
    {
        private static readonly Random random = new Random();
        public static int GetRandom()
        {
            return random.Next(10);
        }
    }
}
