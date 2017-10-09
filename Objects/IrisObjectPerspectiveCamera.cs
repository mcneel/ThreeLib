using System.Collections.Generic;
using Newtonsoft.Json;

namespace IrisLib
{

    public class IrisObjectPerspectiveCamera : IrisElement
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("fov")]
        public double Fov { get; set; }

        [JsonProperty("aspect")]
        public double Aspect { get; set; }

        [JsonProperty("near")]
        public double Near { get; set; }

        [JsonProperty("far")]
        public double Far { get; set; }

        [JsonProperty("userData")]
        public Dictionary<string, Dictionary<string, object>> UserData { get; set; }

        [JsonProperty("matrix")]
        public IList<double> Matrix { get; set; }

        public IrisObjectPerspectiveCamera()
        {
            Type = "PerspectiveCamera";
        }

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
