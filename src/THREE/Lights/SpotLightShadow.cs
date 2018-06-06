using THREE.Cameras;

namespace THREE.Lights
{
    /// <summary>
    /// 
    /// Analogous to: https://github.com/mrdoob/three.js/blob/master/src/lights/SpotLightShadow.js
    /// Original Source: https://github.com/mrdoob/three.js/blob/master/src/lights/SpotLightShadow.js
    /// </summary>
    public class SpotLightShadow : LightShadow
    {
        /// <summary>
        /// 
        /// </summary>
        public new PerspectiveCamera Camera { get; set; }
    }
}
