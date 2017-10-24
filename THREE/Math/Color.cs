using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisLib
{
    /// <summary>
    /// 
    /// </summary>
    public class Color
    {
        /// <summary>
        /// Red channel, 0-256.
        /// </summary>
        public byte R { get; set; }

        /// <summary>
        /// Green channel, 0-256.
        /// </summary>
        public byte G { get; set; }

        /// <summary>
        /// Blue channel, 0-256.
        /// </summary>
        public byte B { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>An int representation of three byte channels.</returns>
        public static int ToInt(byte r, byte g, byte b)
        {
            return r * 256 * 256 + g * 256 + b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>An int representation of the color.</returns>
        public int ToInt()
        {
            return R * 256 * 256 + G * 256 + B;
        }
    }
}
