namespace THREE.Lights
{
    /// <summary>
    /// A light that gets emitted from a single point in all directions. A common use case for this is to replicate the light emitted from a bare lightbulb.
    /// Analogous to: https://threejs.org/docs/index.html#api/lights/PointLight
    /// Original Source: https://github.com/mrdoob/three.js/blob/master/src/lights/PointLight.js
    /// </summary>
    public class PointLight: Light
    {
        /// <summary>
        /// Light distance.
        /// </summary>
        public float Distance { get; set; }

        /// <summary>
        /// Light decay.
        /// </summary>
        public float Decay { get; set; }

    }
}
