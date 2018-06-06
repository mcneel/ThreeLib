namespace THREE.Math
{
    public class Euler
    {
        float[] XYZ;

        /// <summary>
        /// The x value of the Euler.
        /// </summary>
        public float X { get { return XYZ[0]; } set { XYZ[0] = value; } }

        /// <summary>
        /// The y value of the Euler.
        /// </summary>
        public float Y { get { return XYZ[1]; } set { XYZ[1] = value; } }

        /// <summary>
        /// The z value of the Euler.
        /// </summary>
        public float Z { get { return XYZ[2]; } set { XYZ[2] = value; } }

        public RotationOrders Order { get; set; }

        public Euler()
        {
            XYZ = new float[3];
            X = 0;
            Y = 0;
            Z = 0;
            Order = RotationOrders.XYZ;
        }

        public enum RotationOrders: int
        {
            XYZ = 0,
            YZX = 1,
            ZXY = 2,
            XZY = 3,
            YXZ = 4,
            ZYX = 5
        }
    }

    
}
