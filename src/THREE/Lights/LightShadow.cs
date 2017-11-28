using THREE.Cameras;

namespace THREE.Lights
{
    /// <summary>
    /// 
    /// Analogous to: https://threejs.org/docs/index.html#api/lights/shadows/LightShadow
    /// Original Source: https://github.com/mrdoob/three.js/blob/master/src/lights/LightShadow.js
    /// </summary>
    public class LightShadow
    {
        /// <summary>
        /// The light's view of the world.
        /// </summary>
        public Camera Camera { get; set; }

        /// <summary>
        /// Shadow map bias, how much to add or subtract from the normalized depth when deciding whether a surface is in shadow.
        /// </summary>
        public float Bias { get; set; }

        /// <summary>
        /// Setting this to values greater than 1 will blur the edges of the shadow.
        /// </summary>
        public float Radius { get; set; }


    }
}
