using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IrisLib
{
    /// <summary>
    /// For creating Spot Lights.
    /// </summary>
    public class IrisObjectSpotLight : IrisObjectLight
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
        /// Spotlight distance.
        /// </summary>
        [JsonProperty("distance")]
        public double Distance { get; set; }

        /// <summary>
        /// Spotlight angle.
        /// </summary>
        [JsonProperty("angle")]
        public double Angle { get; set; }

        /// <summary>
        /// Spotlight exponent.
        /// </summary>
        [JsonProperty("exponent")]
        public double Exponent { get; set; }

        /// <summary>
        /// Object user data.
        /// </summary>
        [JsonProperty("userData")]
        public List<Dictionary<string, object>> UserData { get; set; }

        /// <summary>
        /// Object matrix.
        /// </summary>
        [JsonProperty("matrix")]
        public IList<double> Matrix { get; set; }

        /// <summary>
        /// Base constructor.
        /// </summary>
        public IrisObjectSpotLight()
        {
            Type = "SpotLight";
        }

        /// <summary>
        /// Extended constructor for spotlights.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="target"></param>
        /// <param name="diffuseColor"></param>
        /// <param name="intensity"></param>
        /// <param name="degree"></param>
        /// <param name="interiorRadius"></param>
        /// <param name="exteriorRadius"></param>
        /// <param name="exponent"></param>
        public IrisObjectSpotLight(double[] location, 
                                   double[] target, 
                                   System.Drawing.Color diffuseColor, 
                                   double intensity, 
                                   double degree, 
                                   double interiorRadius, 
                                   double exteriorRadius, 
                                   double exponent) : this()
        {
            double[] matrix = { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, location[0], location[1], location[2], 1 };
            
            double distance = exteriorRadius / (Math.Tan(degree));

            Color = IrisMethods.ColorToRGB(diffuseColor);
            Intensity = intensity;
            Distance = distance; //set this correctly
            Angle = degree;
            Exponent = exponent;

            var userData = new Dictionary<string, object>
            {
                {"tX", target[0]},
                {"tY", target[1]},
                {"tZ", target[2]}
            };

            var userDataList = new List<Dictionary<string, object>> { userData };

            UserData = userDataList;
            Matrix = matrix;
        }
        

    }

}
