using THREE.Cameras;

namespace THREE.Lights
{
    /// <summary>
    /// Analogous to: https://threejs.org/docs/index.html#api/lights/shadows/DirectionalLightShadow
    /// Original Source: https://github.com/mrdoob/three.js/blob/master/src/lights/DirectionalLightShadow.js
    /// </summary>
    public class DirectionalLightShadow : LightShadow
    {
        /// <summary>
        /// 
        /// </summary>
        public new OrthographicCamera Camera { get; set; }
    }
}
