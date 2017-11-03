using Newtonsoft.Json;

namespace THREE
{
    /// <summary>
    /// 
    /// </summary>
    public class Quaternion
    {
        float[] XYZW;

        /// <summary>
        /// The x value of the Quaternion.
        /// </summary>
        [JsonProperty("x")]
        public float X { get { return XYZW[0]; } set { XYZW[0] = value; } }

        /// <summary>
        /// The y value of the Quaternion.
        /// </summary>
        [JsonProperty("y")]
        public float Y { get { return XYZW[1]; } set { XYZW[1] = value; } }

        /// <summary>
        /// The z value of the Quaternion.
        /// </summary>
        [JsonProperty("z")]
        public float Z { get { return XYZW[2]; } set { XYZW[2] = value; } }

        /// <summary>
        /// The z value of the Quaternion.
        /// </summary>
        [JsonProperty("w")]
        public float W { get { return XYZW[3]; } set { XYZW[3] = value; } }

        public Quaternion()
        {
            XYZW = new float[4];
            X = 0;
            Y = 0;
            Z = 0;
            W = 0;
        }
    }
}
