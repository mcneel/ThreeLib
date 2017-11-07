namespace THREE.Math
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
        /// Construct a color from r,g,b bytes.
        /// </summary>
        /// <param name="r">Red channel.</param>
        /// <param name="g">Green channel.</param>
        /// <param name="b">Blue channel.</param>
        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        /// <summary>
        /// Convert color to 8-bit integer.
        /// </summary>
        /// <returns>An int representation of three byte channels.</returns>
        public static int ToInt(byte r, byte g, byte b)
        {
            return r * 256 * 256 + g * 256 + b;
        }

        /// <summary>
        /// Convert this color to 8-bit integer.
        /// </summary>
        /// <returns>An int representation of the color.</returns>
        public int ToInt()
        {
            return R * 256 * 256 + G * 256 + B;
        }
    }
}
