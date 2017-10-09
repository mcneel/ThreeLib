using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IrisLib
{
    public class IrisObjectSpotLight : IrisObjectLight
    {

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("color")]
        public int Color { get; private set; }

        [JsonProperty("intensity")]
        public double Intensity { get; private set; }

        [JsonProperty("distance")]
        public double Distance { get; private set; }

        [JsonProperty("angle")]
        public double Angle { get; private set; }

        [JsonProperty("exponent")]
        public double Exponent { get; private set; }

        [JsonProperty("userData")]
        public List<Dictionary<string, object>> UserData { get; private set; }

        [JsonProperty("matrix")]
        public IList<double> Matrix { get; private set; }

        public IrisObjectSpotLight()
        {
            Type = "SpotLight";
        }

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
