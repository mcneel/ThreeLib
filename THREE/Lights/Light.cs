using Newtonsoft.Json;

namespace ThreeLib
{
    /// <summary>
    /// Base interface for light objects.
    /// </summary>
    public interface ILight : IElement { }

    /// <summary>
    /// Abstract base class for lights - all other light types inherit the properties and methods described here.
    /// Analogous to: https://threejs.org/docs/index.html#api/lights/Light
    /// Original source: https://github.com/mrdoob/three.js/blob/master/src/lights/Light.js
    /// </summary>
    public abstract class Light : Object3D, ILight
    {
        /// <summary>
        /// Light color.
        /// </summary>
        [JsonProperty("color")]
        public int Color { get; set; }

        /// <summary>
        /// Light intensity.
        /// </summary>
        [JsonProperty("intensity")]
        public float Intensity { get; set; }

    }
}
