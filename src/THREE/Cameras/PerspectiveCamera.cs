using Newtonsoft.Json;

namespace THREE.Cameras
{
    /// <summary>
    /// Camera that uses perspective projection.
    /// This projection mode is designed to mimic the way the human eye sees.It is the most common projection mode used for rendering a 3D scene.
    /// Analogous to : https://threejs.org/docs/index.html#api/cameras/PerspectiveCamera
    /// JS Source: https://github.com/mrdoob/three.js/blob/master/src/cameras/PerspectiveCamera.js
    /// </summary>
    public class PerspectiveCamera : Camera
    {
        /// <summary>
        /// Camera frustum aspect ratio, usually the canvas width / canvas height.
        /// </summary>
        [JsonProperty("aspect")]
        public float Aspect { get; set; }

        /// <summary>
        /// Camera frustum far plane. 
        /// The valid range is between the current value of the near plane and infinity.
        /// </summary>
        [JsonProperty("far")]
        public float Far { get; set; }

        /// <summary>
        /// Film size used for the larger axis. Default is 35 (millimeters). This parameter does not influence the projection matrix unless .filmOffset is set to a nonzero value.
        /// </summary>
        [JsonProperty("filmGauge")]
        public float FilmGauge { get; set; }

        /// <summary>
        /// Horizontal off-center offset in the same unit as FilmGauge.
        /// </summary>
        [JsonProperty("filmOffset")]
        public float FilmOffset { get; set; }

        /// <summary>
        /// Object distance used for stereoscopy and depth-of-field effects. This parameter does not influence the projection matrix unless a StereoCamera is being used.
        /// </summary>
        [JsonProperty("focus")]
        public float Focus { get; set; }

        /// <summary>
        /// Camera frustum vertical field of view, from bottom to top of view, in degrees.
        /// </summary>
        [JsonProperty("fov")]
        public float Fov { get; set; }

        /// <summary>
        /// Camera frustum near plane.
        /// The valid range is greater than 0 and less than the current value of the far plane.
        /// Note that, unlike for the OrthographicCamera, 0 is not a valid value for a PerspectiveCamera's near plane. 
        /// </summary>
        [JsonProperty("near")]
        public float Near { get; set; }

        ///// <summary>
        ///// Frustum window specification or null. This is set using the .setViewOffset method and cleared using .clearViewOffset. 
        ///// </summary>
        //[JsonProperty("view")]
        //public object View { get; set; }

        /// <summary>
        /// Gets or sets the zoom factor of the camera.
        /// </summary>
        [JsonProperty("zoom")]
        public float Zoom { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PerspectiveCamera()
        {
            Type = GetType().Name;
        }
    }
}
