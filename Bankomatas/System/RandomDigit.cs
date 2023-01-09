using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomatas.System
{
    public static class RandomDigit
    {
        public static int GetRandom()
        {
            Random random = new Random();
            return random.Next(10);
        }
    }
}
