using System.Collections.Generic;
using Newtonsoft.Json;

namespace IrisLib
{
    /// <summary>
    /// For creatig point lights. Analogous to PointLight:
    /// https://threejs.org/docs/index.html#api/lights/PointLight
    /// </summary>
    public class IrisObjectPointLight : IrisObjectLight
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
        /// Light distance.
        /// </summary>
        [JsonProperty("distance")]
        public double Distance { get; set; }

        /// <summary>
        /// Object orientation.
        /// </summary>
        [JsonProperty("matrix")]
        public IList<double> Matrix { get; set; }

        /// <summary>
        /// Base constructor.
        /// </summary>
        public IrisObjectPointLight()
        {
            Type = "PointLight";
        }
        /*
        /// <summary>
        /// Extended constructor.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="intensity"></param>
        /// <param name="diffuse"></param>
        public IrisObjectPointLight(double[] position, double intensity, Color diffuse)
        {
            double[] matrix = { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, position[0], position[1], position[2], 1 };

            Color = IrisMethods.ColorToRGB(diffuse);
            Intensity = intensity;
            Distance = 100; //set this correctly
            Matrix = matrix;
        }

    */

    }

}
