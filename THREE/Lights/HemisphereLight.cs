using Newtonsoft.Json;

namespace IrisLib
{
    /// <summary>
    /// A light source positioned directly above the scene, with color fading from the sky color to the ground color.
    /// This light cannot be used to cast shadows.
    /// Analogous to: https://threejs.org/docs/index.html#api/lights/HemisphereLight
    /// Original Source: https://github.com/mrdoob/three.js/blob/master/src/lights/HemisphereLight.js
    /// </summary>
    public class HemisphereLight : Light
    {
        /// <summary>
        /// Color of the ground.
        /// </summary>
        [JsonProperty("groundColor")]
        public int GroundColor { get; set; }

        /// <summary>
        /// Color of the sky.
        /// </summary>
        [JsonProperty("skyColor")]
        public int SkyColor { get; set; }

    }
}
