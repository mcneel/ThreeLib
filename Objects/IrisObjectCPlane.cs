using System.Collections.Generic;
using Newtonsoft.Json;

namespace IrisLib
{
    /// <summary>
    /// For creating clipping planes.
    /// </summary>
    public class IrisObjectCPlane : IrisElement
    {
        /// <summary>
        /// Object name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Plane direction.
        /// </summary>
        [JsonProperty("vector")]
        public double[] Vector { get; set; }

        /// <summary>
        /// Plane position.
        /// </summary>
        [JsonProperty("position")]
        public double[] Position { get; set; }

        /// <summary>
        /// Object user data.
        /// </summary>
        [JsonProperty("userData")]
        public List<Dictionary<string, object>> UserData { get; set; }

        /// <summary>
        /// Object orientation matrix.
        /// </summary>
        [JsonProperty("matrix")]
        public IList<double> Matrix { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public IrisObjectCPlane()
        {
            Type = "ConstructionPlane";
        }

        /// <summary>
        /// Extended constructor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="vector"></param>
        /// <param name="position"></param>
        public IrisObjectCPlane(string name, double[] vector, double[] position) : this()
        {
            Name = name;
            Vector = vector;
            Position = position;
            Matrix = new double[] { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, position[0], position[2], position[1], 1 };
        }

        /// <summary>
        /// Set the name of the plane.
        /// </summary>
        /// <param name="name"></param>
        public void SetName(string name)
        {
            Name = name;
        }

    }

}
