using System.Collections.Generic;
using Newtonsoft.Json;

namespace IrisLib
{

    public class IrisObjectOrthographicCamera : IrisElement
    {
        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("left")]
        public double Left { get; private set; }

        [JsonProperty("right")]
        public double Right { get; private set; }

        [JsonProperty("top")]
        public double Top { get; private set; }

        [JsonProperty("bottom")]
        public double Bottom { get; private set; }

        [JsonProperty("near")]
        public double Near { get; private set; }

        [JsonProperty("far")]
        public double Far { get; private set; }

        [JsonProperty("userData")]
        public Dictionary<string, Dictionary<string, object>> UserData { get; private set; }

        [JsonProperty("matrix")]
        public IList<double> Matrix { get; private set; }

        public IrisObjectOrthographicCamera()
        {
            Type = "OrthographicCamera";
        }

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
