using Newtonsoft.Json;

namespace THREE
{
    /// <summary>
    /// Abstract base class for cameras. This class should always be inherited when you build a new camera. 
    /// Analogous to: https://threejs.org/docs/index.html#api/cameras/Camera
    /// Original Source: https://github.com/mrdoob/three.js/blob/master/src/cameras/Camera.js
    /// </summary>
    public abstract class Camera : Object3D
    {
        [JsonProperty("matrixWorldInverse")]
        public Matrix4 MatrixWorldInverse { get; set; }

        [JsonProperty("projectionMatrix")]
        public Matrix4 ProjectionMatrix { get; set; }

        public Camera()
        {
            Type = GetType().Name;
        }
    }
}
