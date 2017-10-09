using System.Collections.Generic;
using Newtonsoft.Json;
using System.Drawing;

namespace IrisLib
{

    public class IrisObjectPointLight : IrisObjectLight
    {

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("color")]
        public int Color { get; private set; }

        [JsonProperty("intensity")]
        public double Intensity { get; private set; }

        [JsonProperty("distance")]
        public double Distance { get; private set; }

        [JsonProperty("matrix")]
        public IList<double> Matrix { get; private set; }

        public IrisObjectPointLight()
        {
            Type = "PointLight";
        }

        public IrisObjectPointLight(double[] position, double intensity, Color diffuse)
        {
            double[] matrix = { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, position[0], position[1], position[2], 1 };

            Color = IrisMethods.ColorToRGB(diffuse);
            Intensity = intensity;
            Distance = 100; //set this correctly
            Matrix = matrix;
        }

    }

}
