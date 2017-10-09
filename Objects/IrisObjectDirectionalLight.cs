using System.Collections.Generic;
using Newtonsoft.Json;

namespace IrisLib
{
    public class IrisObjectDirectionalLight : IrisObjectLight
    {
        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("color")]
        public int Color { get; private set; }

        [JsonProperty("intensity")]
        public double Intensity { get; private set; }

        [JsonProperty("castShadow")]
        public bool CastShadow { get; private set; }

        [JsonProperty("matrix")]
        public IList<double> Matrix { get; private set; }

        public IrisObjectDirectionalLight()
        {
            Type = "DirectionalLight";
        }

        public IrisObjectDirectionalLight(double[] location, System.Drawing.Color diffuseColor, double intensity, double shadowIntensity):this()
        {
            double[] matrix = { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, location[0], location[1], location[2], 1 };

            Color = IrisMethods.ColorToRGB(diffuseColor);
            Intensity = intensity;

            if (shadowIntensity > 0)
            {
                CastShadow = true;
            }
            else
            {
                CastShadow = false;
            }

            Matrix = matrix;
        }

        public IrisObjectDirectionalLight(double[] location) : this()
        {
            double[] matrix = { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, location[0], location[1], location[2], 1 };

            Color = IrisMethods.ColorToRGB(System.Drawing.Color.White);
            Intensity = 0.4;
            Matrix = matrix;
        }

    }

}
