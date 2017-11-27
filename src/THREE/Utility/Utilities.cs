using System;
using System.Collections.Generic;

namespace THREE.Utility
{
    internal static class Utilities
    {
        internal static IEnumerable<object> OptimizeFloats(IEnumerable<float> floats)
        {
            var numbers = new List<object>();
            foreach (float f in floats)
            {
                if (System.Math.Abs(f - System.Math.Floor(f)) <= float.Epsilon)
                {
                    numbers.Add(Convert.ToInt16(f));
                }
                else
                {
                    numbers.Add(f);
                }
            }
            return numbers;
        }

        /// <summary>
        /// Encode a float to an int.
        /// </summary>
        /// <param name="x">The float to encode.</param>
        /// <returns>An encoded float.</returns>
        public static int EncodeFloat(float x)
        {
            var sum = (x >= 0 ? 0.0 : -1.0);
            return (int)((x * 127.5) + sum);
        }

    }
}
