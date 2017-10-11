using System.Collections.Generic;
using Newtonsoft.Json;

namespace IrisLib
{

    /// <summary>
    /// For creating perspective cameras. Analogous to: 
    /// https://threejs.org/docs/index.html#api/cameras/PerspectiveCamera
    /// </summary>
    public class IrisObjectPerspectiveCamera : IrisElement
    {
        /// <summary>
        /// Object name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Camera field of view.
        /// </summary>
        [JsonProperty("fov")]
        public double Fov { get; set; }

        /// <summary>
        /// Camera aspect ratio.
        /// </summary>
        [JsonProperty("aspect")]
        public double Aspect { get; set; }

        /// <summary>
        /// Camera near distance.
        /// </summary>
        [JsonProperty("near")]
        public double Near { get; set; }

        /// <summary>
        /// Camera far distance.
        /// </summary>
        [JsonProperty("far")]
        public double Far { get; set; }

        /// <summary>
        /// Object user data.
        /// </summary>
        [JsonProperty("userData")]
        public Dictionary<string, Dictionary<string, object>> UserData { get; set; }

        /// <summary>
        /// Object orientation matrix.
        /// </summary>
        [JsonProperty("matrix")]
        public IList<double> Matrix { get; set; }

        /// <summary>
        /// Base constructor.
        /// </summary>
        public IrisObjectPerspectiveCamera()
        {
            Type = "PerspectiveCamera";
        }

        /// <summary>
        /// Extended constructor.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="target"></param>
        /// <param name="aspect"></param>
        /// <param name="fov"></param>
        /// <param name="name"></param>
        public IrisObjectPerspectiveCamera(double[] location, double[] target, double aspect, double fov, string name) : this()
        {
            double[] matrix = { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, location[0], location[1], location[2], 1 };

            var userData = new Dictionary<string, object>
            {
                {"tX", target[0]},
                {"tY", target[1]},
                {"tZ", target[2]}
            };

            Name = name;

            Fov = fov; //Rhino.RhinoMath.ToDegrees(halfVertical * 2);
            Aspect = aspect; //viewport.FrustumAspect;
            Near = 1; //set this correctly
            Far = 100000; //set this correctly
            UserData = new Dictionary<string, Dictionary<string, object>> { { "Target", userData } };
            Matrix = matrix;
        }

    }

}
