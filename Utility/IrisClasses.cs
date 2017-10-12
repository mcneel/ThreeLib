using Newtonsoft.Json;
using System.Collections.Generic;

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
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("version")]
        public double Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("generator")]
        public string Generator { get; set; }
    }

    /// <summary>
    /// General utility class for user data.
    /// </summary>
    public class IrisUserData
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Dictionary<string, object>> UserData { get; set; }
    }

    //Data

    /// <summary>
    /// Some common data.
    /// </summary>
    public class IrisData 
    {
        /// <summary>
        /// Basic matrix as a float[].
        /// </summary>
        public static float[] Matrix = { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 };
    }

    //Methods

    /// <summary>
    /// Utility methods.
    /// </summary>
    public class IrisMethods 
    {

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
