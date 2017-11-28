using THREE.Core;

namespace THREE.Lights
{
    /// <summary>
    /// his light gets emitted from a single point in one direction, along a cone that increases in size the further from the light it gets.
    /// Analogous to: https://threejs.org/docs/index.html#api/lights/SpotLight
    /// Original Source: https://github.com/mrdoob/three.js/blob/master/src/lights/SpotLight.js
    /// </summary>
    public class SpotLight : Light
    {
        /// <summary>
        /// Maximum extent of the spotlight, in radians, from its direction. Should be no more than Math.PI/2. The default is Math.PI/3. 
        /// </summary>
        public float Angle { get; set; }

        /// <summary>
        /// If non-zero, light will attenuate linearly from maximum intensity at the light's position down to zero at this distance from the light.
        /// </summary>
        public float Distance { get; set; }

        /// <summary>
        /// The amount the light dims along the distance of the light.
        /// </summary>
        public float Decay { get; set; }

        /// <summary>
        /// Percent of the spotlight cone that is attenuated due to penumbra. Takes values between zero and 1.
        /// </summary>
        public float Penumbra { get; set; }

        /// <summary>
        /// The light's power.
        /// </summary>
        public float Power { get; set; }

        /// <summary>
        /// The Spotlight points from its position to target.position.
        /// </summary>
        public Object3D Target { get; set; }

        /// <summary>
        /// Spotlight shadow object.
        /// </summary>
        public SpotLightShadow Shadow { get; set; }

    }
}
