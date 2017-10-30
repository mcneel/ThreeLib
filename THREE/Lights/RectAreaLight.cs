using Newtonsoft.Json;

namespace ThreeLib
{
    /// <summary>
    /// This light gets emitted uniformly across the face a rectangular plane. This can be used to simulate things like bright windows or strip lighting.
    /// Analogous to: https://threejs.org/docs/index.html#api/lights/RectAreaLight
    /// Original Source: https://github.com/mrdoob/three.js/blob/master/src/lights/RectAreaLight.js
    /// </summary>
    public class RectAreaLight : Light
    {

        /// <summary>
        /// Height of the light.
        /// </summary>
        [JsonProperty("height")]
        public float Height { get; set; }

        /// <summary>
        /// Width of the light.
        /// </summary>
        [JsonProperty("width")]
        public float Width { get; set; }

    }
}
