using System.Collections.Generic;
using Newtonsoft.Json;

namespace IrisLib
{

    public class IrisObjectCPlane : IrisElement
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("vector")]
        public double[] Vector { get; set; }

        [JsonProperty("position")]
        public double[] Position { get; set; }

        [JsonProperty("userData")]
        public List<Dictionary<string, object>> UserData { get; set; }

        [JsonProperty("matrix")]
        public IList<double> Matrix { get; set; }

        public IrisObjectCPlane()
        {
            Type = "ConstructionPlane";
        }

        public IrisObjectCPlane(string name, double[] vector, double[] position) : this()
        {
            Name = name;
            Vector = vector;
            Position = position;
            Matrix = new double[] { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, position[0], position[2], position[1], 1 };
        }
        public void SetName(string name)
        {
            Name = name;
        }

    }

}
