using System.Collections.Generic;
using Newtonsoft.Json;

namespace IrisLib
{
    /// <summary>
    /// For creating directional lights. Analogous to:
    /// https://threejs.org/docs/index.html#api/lights/DirectionalLight
    /// </summary>
    public class IrisObjectDirectionalLight : IrisObjectLight
    {
        /// <summary>
        /// Object name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Light color.
        /// </summary>
        [JsonProperty("color")]
        public int Color { get; set; }

        /// <summary>
        /// Light intensity.
        /// </summary>
        [JsonProperty("intensity")]
        public double Intensity { get; set; }

        /// <summary>
        /// Object shadow casting flag.
        /// </summary>
        [JsonProperty("castShadow")]
        public bool CastShadow { get; set; }

        /// <summary>
        /// Object orientation.
        /// </summary>
        [JsonProperty("matrix")]
        public IList<double> Matrix { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public IrisObjectDirectionalLight()
        {
            Type = "DirectionalLight";
        }
        /*
        /// <summary>
        /// Extended constructor.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="diffuseColor"></param>
        /// <param name="intensity"></param>
        /// <param name="shadowIntensity"></param>
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

        /// <summary>
        /// Extended constructor.
        /// </summary>
        /// <param name="location"></param>
        public IrisObjectDirectionalLight(double[] location) : this()
        {
            double[] matrix = { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, location[0], location[1], location[2], 1 };

            Color = IrisMethods.ColorToRGB(System.Drawing.Color.White);
            Intensity = 0.4;
            Matrix = matrix;
        }
        */

    }

}
