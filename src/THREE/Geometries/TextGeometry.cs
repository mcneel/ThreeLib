using System;
using THREE.Core;

namespace THREE.Geometries
{
    /// <summary>
    /// A class for generating text geometries.
    /// Analagous to: https://threejs.org/docs/index.html#api/en/geometries/TextBufferGeometry
    /// JS Source: https://github.com/mrdoob/three.js/blob/master/src/geometries/TextGeometry.js
    /// </summary>
    public class TextBufferGeometry : Geometry, IEquatable<TextBufferGeometry>
    {
        /// <summary>
        /// An instance of THREE.Font.
        /// </summary>
        public Font Font { get; set; }

        /// <summary>
        /// Size of the text. Default is 100.
        /// </summary>
        public float Size { get; set; }

        /// <summary>
        /// Thickness to extrude text. Default is 50.
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// Number of points on the curves. Default is 12.
        /// </summary>
        public int CurveSegments { get; set; }

        /// <summary>
        /// Turn on bevel. Default is False.
        /// </summary>
        public bool BevelEnabled { get; set; }

        /// <summary>
        /// How deep into text bevel goes. Default is 10.
        /// </summary>
        public float BevelThickness { get; set; }

        /// <summary>
        /// How far from text outline is bevel. Default is 8.
        /// </summary>
        public float BevelSize { get; set; }

        /// <summary>
        /// Number of bevel segments. Default is 3.
        /// </summary>
        public int BevelSegments { get; set; }

        bool IEquatable<TextBufferGeometry>.Equals(TextBufferGeometry other)
        {
            throw new NotImplementedException();
        }
    }

}