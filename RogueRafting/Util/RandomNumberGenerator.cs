using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueRafting.Util
{
    internal abstract class RandomNumberGenerator
    {
        private static Random random = new Random();

        public static int getInt()
        {
            return random.Next();
        }

        public static int getInt(int min, int max)
        {
            return random.Next(min, max);
        }

        public static float getFloat(int range)
        {
            return (float)random.NextDouble() * range;
        }

        public static float getFloat(float min, float max)
        {
            return (float)(min + random.NextDouble() * (max));
        }

        public static long getLong()
        {
            return random.Next() * random.Next();
        }
    }
}
