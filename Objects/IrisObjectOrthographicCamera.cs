using System.Collections.Generic;
using Newtonsoft.Json;

namespace IrisLib
{
    /// <summary>
    /// For creating orthographic cameras. Analogous to:
    /// https://threejs.org/docs/index.html#api/cameras/OrthographicCamera
    /// </summary>
    public class IrisObjectOrthographicCamera : IrisElement
    {
        /// <summary>
        /// Object name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Camera left.
        /// </summary>
        [JsonProperty("left")]
        public double Left { get; set; }

        /// <summary>
        /// Camera right.
        /// </summary>
        [JsonProperty("right")]
        public double Right { get; set; }

        /// <summary>
        /// Camera top.
        /// </summary>
        [JsonProperty("top")]
        public double Top { get; set; }

        /// <summary>
        /// Camera bottom.
        /// </summary>
        [JsonProperty("bottom")]
        public double Bottom { get; set; }

        /// <summary>
        /// Camera near.
        /// </summary>
        [JsonProperty("near")]
        public double Near { get; set; }

        /// <summary>
        /// Camera far.
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
        /// Default constructor.
        /// </summary>
        public IrisObjectOrthographicCamera()
        {
            Type = "OrthographicCamera";
        }

        /// <summary>
        /// Extended constructor.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="target"></param>
        /// <param name="aspect"></param>
        /// <param name="name"></param>
        public IrisObjectOrthographicCamera(double[] location, double[] target, double aspect, string name) : this()
        {
            double[] matrix = { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, location[0], location[1], location[2], 1 };

            var userData = new Dictionary<string, object>
            {
                {"tX", target[0]},
                {"tY", target[1]},
                {"tZ", target[2]}
            };

            Name = name;

            Left = 0.5 * 600 * aspect / -2;
            Right = 0.5 * 600 * aspect / 2;
            Top = 600 / 2;
            Bottom = 600 / -2;

            Near = 1; //set this correctly
            Far = 100000; //set this correctly
            UserData = new Dictionary<string, Dictionary<string, object>> { { "Target", userData } };
            Matrix = matrix;
        }

    }

}
