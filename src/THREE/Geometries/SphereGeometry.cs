using Newtonsoft.Json;
using System;
using THREE;

namespace THREE
{
    /// <summary>
    /// A class for generating sphere geometries.
    /// Analagous to: https://threejs.org/docs/index.html#api/geometries/SphereGeometry
    /// JS Source: https://github.com/mrdoob/three.js/blob/master/src/geometries/SphereGeometry.js
    /// </summary>
    public class SphereGeometry : Geometry, IEquatable<SphereGeometry>
    {
        /// <summary>
        /// Sphere radius.
        /// </summary>
        [JsonProperty("radius")]
        public float Radius { get; set; }

        /// <summary>
        ///  Number of horizontal segments. Minimum value is 3.
        /// </summary>
        [JsonProperty("widthSegments")]
        public int WidthSegments { get; set; }

        /// <summary>
        /// Number of vertical segments. Minimum value is 2.
        /// </summary>
        [JsonProperty("heightSegments")]
        public int HeightSegments { get; set; }

        /// <summary>
        /// Specify horizontal starting angle (in radians).
        /// </summary>
        [JsonProperty("phiStart")]
        public float PhiStart { get; set; }

        /// <summary>
        /// Specify horizontal sweep angle size (in radians).
        /// </summary>
        [JsonProperty("phiLength")]
        public float PhiLength { get; set; }

        /// <summary>
        /// Specify horizontal sweep angle size (in radians).
        /// </summary>
        [JsonProperty("thetaStart")]
        public float ThetaStart { get; set; }

        /// <summary>
        /// Specify vertical sweep angle size (in radians).
        /// </summary>
        [JsonProperty("thetaLength")]
        public float ThetaLength { get; set; }

        /// <summary>
        /// Check if this is equal to another geometry of this type.
        /// </summary>
        /// <param name="other">Other geometry.</param>
        /// <returns>True if the geometries contain the same property values. False if otherwise.</returns>
        public bool Equals(SphereGeometry other)
        {
            if (other == null) return false;
            else
                return Radius.Equals(other.Radius) &&
                        WidthSegments.Equals(other.WidthSegments) &&
                        HeightSegments.Equals(other.HeightSegments) &&
                        PhiStart.Equals(other.PhiStart) &&
                        PhiLength.Equals(other.PhiLength) &&
                        ThetaStart.Equals(other.ThetaStart) &&
                        ThetaLength.Equals(other.ThetaLength);
        }
    }
}
