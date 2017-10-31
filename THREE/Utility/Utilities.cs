using System;
using System.Collections.Generic;

namespace ThreeLib
{
    internal class Utilities
    {
        internal static IEnumerable<object> OptimizeFloats(IEnumerable<float> floats)
        {
            var numbers = new List<object>();
            foreach (float f in floats)
            {
                if (Math.Abs(f - Math.Floor(f)) <= float.Epsilon)
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
    }
}
