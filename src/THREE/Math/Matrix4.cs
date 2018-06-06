using System.Collections.Generic;
using THREE.Utility;

namespace THREE.Math
{
    /// <summary>
    /// A class representing a 4x4 matrix.
    /// Analogous to: https://threejs.org/docs/index.html#api/math/Matrix4
    /// JS Source: https://github.com/mrdoob/three.js/blob/master/src/math/Matrix4.js
    /// </summary>
    public class Matrix4
    {
        /// <summary>
        /// A column-major list of matrix values. 
        /// </summary>
        public float[] Elements { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Matrix4()
        {
            Elements = new float[16];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Matrix4 Identity()
        {
            return new Matrix4()
            {
                Elements = new float[16] { 1, 0, 0, 0,
                                           0, 1, 0, 0,
                                           0, 0, 1, 0,
                                           0, 0, 0, 1 }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        public void SetPosition(Vector3 vector)
        {
            Elements[12] = vector.X;
            Elements[13] = vector.Y;
            Elements[14] = vector.Z;
        }
        public Vector3 GetPosition()
        {
            return new Vector3(Elements[12], Elements[13], Elements[14]);
        }
        public void MakeRotationFromQuaternion(Quaternion q)
        {
            var te = Elements;

            var x = q.X; var y = q.Y; var z = q.Z; var w = q.W;
            var x2 = x + x; var y2 = y + y; var z2 = z + z;
            var xx = x * x2; var xy = x * y2; var xz = x * z2;
            var yy = y * y2; var yz = y * z2; var zz = z * z2;
            var wx = w * x2; var wy = w * y2; var wz = w * z2;

            te[0] = 1 - (yy + zz);
            te[4] = xy - wz;
            te[8] = xz + wy;

            te[1] = xy + wz;
            te[5] = 1 - (xx + zz);
            te[9] = yz - wx;

            te[2] = xz - wy;
            te[6] = yz + wx;
            te[10] = 1 - (xx + yy);

            // last column
            te[3] = 0;
            te[7] = 0;
            te[11] = 0;

            // bottom row
            te[12] = 0;
            te[13] = 0;
            te[14] = 0;
            te[15] = 1;

        }
        public void Scale(Vector3 v)
        {
            var te = Elements;
            var x = v.X; var y = v.Y; var z = v.Z;

            te[0] *= x; te[4] *= y; te[8] *= z;
            te[1] *= x; te[5] *= y; te[9] *= z;
            te[2] *= x; te[6] *= y; te[10] *= z;
            te[3] *= x; te[7] *= y; te[11] *= z;
        }
        public void Compose(Vector3 position, Quaternion quaternion, Vector3 scale)
        {
            MakeRotationFromQuaternion(quaternion);
            Scale(scale);
            SetPosition(position);
        }

        public void LookAt(Vector3 eye, Vector3 target, Vector3 up)
        {
            var x = new Vector3();
            var y = new Vector3();
            var z = new Vector3();

            var te = this.Elements;

            z.SubVectors(eye, target);

            if (z.LengthSq() == 0)
            {

                // eye and target are in the same position

                z.Z = 1;

            }

            z.Normalize();
            x.CrossVectors(up, z);

            te[0] = x.X; te[4] = y.X; te[8] = z.X;
            te[1] = x.Y; te[5] = y.Y; te[9] = z.Y;
            te[2] = x.Z; te[6] = y.Z; te[10] = z.Z;

        }

        public float[] ToArray() { return Elements; }
        internal IEnumerable<object> ToObjectList() { return Utilities.OptimizeFloats(Elements); }
    }
}
