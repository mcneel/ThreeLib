using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace THREE.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="floats"></param>
        /// <returns></returns>
        public static IEnumerable<object> OptimizeFloats(IEnumerable<float> floats)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static object[] Flatten(IEnumerable<object> source)
        {
            Func<IEnumerable<object>, IEnumerable<object>> flatten = null;
            flatten = s => s.SelectMany(x => x is Array ? flatten(((IEnumerable)x).Cast<object>()) : Enumerable.Repeat(x, 1));

            return flatten(source).ToArray();
        }

    }
}
