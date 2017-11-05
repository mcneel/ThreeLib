using Newtonsoft.Json;
using System;

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

        public void SetFromEuler(Euler euler)
        {
            var x = euler.X; var y = euler.Y; var z = euler.Z; var order = euler.Order;

            // http://www.mathworks.com/matlabcentral/fileexchange/
            // 	20696-function-to-convert-between-dcm-euler-angles-quaternions-and-euler-vectors/
            //	content/SpinCalc.m

            var c1 = (float)Math.Cos(x / 2);
            var c2 = (float)Math.Cos(y / 2);
            var c3 = (float)Math.Cos(z / 2);

            var s1 = (float)Math.Sin(x / 2);
            var s2 = (float)Math.Sin(y / 2);
            var s3 = (float)Math.Sin(z / 2);

            if (order == Euler.RotationOrders.XYZ)
            {

                X = s1 * c2 * c3 + c1 * s2 * s3;
                Y = c1 * s2 * c3 - s1 * c2 * s3;
                Z = c1 * c2 * s3 + s1 * s2 * c3;
                W = c1 * c2 * c3 - s1 * s2 * s3;

            }
            else if (order == Euler.RotationOrders.YXZ)
            {

                X = s1 * c2 * c3 + c1 * s2 * s3;
                Y = c1 * s2 * c3 - s1 * c2 * s3;
                Z = c1 * c2 * s3 - s1 * s2 * c3;
                W = c1 * c2 * c3 + s1 * s2 * s3;

            }
            else if (order == Euler.RotationOrders.ZXY)
            {

                X = s1 * c2 * c3 - c1 * s2 * s3;
                Y = c1 * s2 * c3 + s1 * c2 * s3;
                Z = c1 * c2 * s3 + s1 * s2 * c3;
                W = c1 * c2 * c3 - s1 * s2 * s3;

            }
            else if (order == Euler.RotationOrders.ZYX)
            {

                X = s1 * c2 * c3 - c1 * s2 * s3;
                Y = c1 * s2 * c3 + s1 * c2 * s3;
                Z = c1 * c2 * s3 - s1 * s2 * c3;
                W = c1 * c2 * c3 + s1 * s2 * s3;

            }
            else if (order == Euler.RotationOrders.YZX)
            {

                X = s1 * c2 * c3 + c1 * s2 * s3;
                Y = c1 * s2 * c3 + s1 * c2 * s3;
                Z = c1 * c2 * s3 - s1 * s2 * c3;
                W = c1 * c2 * c3 - s1 * s2 * s3;

            }
            else if (order == Euler.RotationOrders.XZY)
            {

                X = s1 * c2 * c3 - c1 * s2 * s3;
                Y = c1 * s2 * c3 - s1 * c2 * s3;
                Z = c1 * c2 * s3 + s1 * s2 * c3;
                W = c1 * c2 * c3 + s1 * s2 * s3;

            }

            //if (update !== false) this.onChangeCallback();

            //return this;
        }
    }
}
