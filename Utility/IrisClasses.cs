using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;

namespace IrisLib
{

    /// <summary>
    /// Basic file metadata
    /// </summary>
    /// <remarks>
    /// This is used by scene and camera objects to define which format they are written in. 
    /// </remarks>
    public class IrisMetadata 
    {
        [JsonProperty("version")]
        public double Version { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("generator")]
        public string Generator { get; set; }
    }

    /// <summary>
    /// General utility class for user data.
    /// </summary>
    public class IrisUserData
    {
        public List<Dictionary<string, object>> UserData { get; set; }
    }

    //Data

    /// <summary>
    /// Some common data.
    /// </summary>
    public class IrisData 
    {
        public static float[] Matrix = { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 };
    }

    //Methods

    /// <summary>
    /// Utility methods.
    /// </summary>
    public class IrisMethods 
    {
        /// <summary>
        /// Convert a System.Drawing.Color to int.
        /// </summary>
        /// <param name="c">The color to convert.</param>
        /// <returns>An int representation of the color.</returns>
        public static int ColorToRGB(Color c)
        {
            return c.R * 256 * 256 + c.G * 256 + c.B;
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
