using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using Newtonsoft.Json;

namespace IrisLib
{
    /// <summary>
    /// Display properties for curves. Analogous to:
    /// https://threejs.org/docs/index.html#api/materials/LineBasicMaterial
    /// </summary>
    public class IrisLineMaterial : IrisMaterial, IEquatable<IrisLineMaterial>
    {
        /// <summary>
        /// The material name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The material color.
        /// </summary>
        [JsonProperty("color", DefaultValueHandling = DefaultValueHandling.Include)]
        public int Color { get; set; }

        /// <summary>
        /// The curve linewidth. Note: This is not yet supported in the Iris WebApp.
        /// </summary>
        [JsonProperty("linewidth")]
        public double LineWidth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("linecap")]
        public string LineCap { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("linejoin")]
        public string LineJoin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("vertexColors")]
        public int VertexColors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("fog")]
        public bool Fog { get; set; }

        /// <summary>
        /// Constructor for IrisLineMaterial. This is analogous to Threejs LineBasicMaterial.
        /// </summary>
        public IrisLineMaterial()
        {
            Type = "LineBasicMaterial";
        }

        /// <summary>
        /// Create a new IrisLineMaterial with a speficied color and linewidth.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="linewidth">Not supported yet.</param>
        public IrisLineMaterial(Color color, double linewidth) : this()
        {
            Color = IrisMethods.ColorToRGB(color);
            LineWidth = linewidth;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="color"></param>
        /// <param name="linewidth"></param>
        /// <param name="linecap"></param>
        /// <param name="linejoin"></param>
        /// <param name="vertexColors"></param>
        /// <param name="fog"></param>
        public IrisLineMaterial(string name, int color, double linewidth, string linecap, string linejoin, int vertexColors, bool fog) : this()
        {
            Name = name;
            Color = color;
            LineWidth = linewidth;
            LineCap = linecap;
            LineJoin = linejoin;
            VertexColors = vertexColors;
            Fog = fog;
        }

        /// <summary>
        /// Check whether this equals an object of the same type.
        /// </summary>
        /// <param name="other">The other object to check against.</param>
        /// <returns></returns>
        public bool Equals(IrisLineMaterial other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return Type.Equals(other.Type) &&
                       Color.Equals(other.Color);
            }
        }
    }

    /// <summary>
    /// A collection of IrisLineMaterials. Exists to ensure there are no duplicate materials.
    /// </summary>
    public class IrisLineMaterialCollection : Collection<IrisLineMaterial>
    {
        /// <summary>
        /// Adds a new IrisLineMaterial to the collection if in fact it does not already contain a material with the same properties.
        /// </summary>
        /// <param name="item">Material to add or check if it exists.</param>
        /// <returns>The Guid of the material if added or retrieved from the collection.</returns>
        public Guid AddIfNew(IrisLineMaterial item)
        {
            var q = from a in this
                    where a.Equals(item)
                    select a.Uuid;

            var enumerable = q as Guid[] ?? q.ToArray();
            if (!enumerable.Any())
            {
                Add(item);

                return item.Uuid;
            }
            else
            {
                return enumerable.Single();
            }
        }
    }

}
