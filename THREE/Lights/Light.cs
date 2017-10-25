using Newtonsoft.Json;

namespace IrisLib
{
    /// <summary>
    /// Base interface for light objects.
    /// </summary>
    public interface ILight : IElement { }

    /// <summary>
    /// Base object for Light objects. Analogous to: https://github.com/mrdoob/three.js/blob/dev/src/lights/Light.js
    /// </summary>
    public class Light : Object3D, ILight
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

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Light()
        {
            Type = "Light";
        }
    }
}
