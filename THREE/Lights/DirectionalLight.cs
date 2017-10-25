using Newtonsoft.Json;

namespace IrisLib
{
    /// <summary>
    /// A light that gets emitted in a specific direction.
    /// Analogous to: https://threejs.org/docs/index.html#api/lights/DirectionalLight
    /// Original Source: https://github.com/mrdoob/three.js/blob/master/src/lights/DirectionalLight.js
    /// </summary>
    public class DirectionalLight : Light
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("shadow")]
        public DirectionalLightShadow Shadow { get; set; }

        /// <summary>
        /// The Spotlight points from its position to target.position.
        /// </summary>
        [JsonProperty("target")]
        public Object3D Target { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DirectionalLight()
        {
            Type = "DirectionalLight";
        }
    }
}
