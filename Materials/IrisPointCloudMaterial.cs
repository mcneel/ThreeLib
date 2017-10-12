using System;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Linq;

namespace IrisLib
{
    /// <summary>
    /// For creating point cloud materials. Analogous to:
    /// https://threejs.org/docs/index.html#api/materials/PointsMaterial
    /// </summary>
    public class IrisPointCloudMaterial : IrisMaterial, IEquatable<IrisPointCloudMaterial>
    {
        /// <summary>
        /// Object name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Material color.
        /// </summary>
        [JsonProperty("color")]
        public int Color { get; set; }

        /// <summary>
        /// Point size.
        /// </summary>
        [JsonProperty("size")]
        public double Size { get; set; }

        /// <summary>
        /// Size attenuation flag.
        /// </summary>
        [JsonProperty("sizeAttenuation", DefaultValueHandling = DefaultValueHandling.Include)]
        public bool SizeAttenuation { get; set; }

        /// <summary>
        /// Vertex colors flag.
        /// </summary>
        [JsonProperty("vertexColors")]
        public int VertexColors { get; set; }

        /// <summary>
        /// Material diffuse color map.
        /// </summary>
        [JsonProperty("map")]
        public Guid Map { get; set; }

        /// <summary>
        /// Material fog flag.
        /// </summary>
        [JsonProperty("fog")]
        public bool Fog { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public IrisPointCloudMaterial()
        {
            Type = "PointsMaterial";
            Color = 16777215;
            Size = 5;
            SizeAttenuation = false;
            VertexColors = 2;
        }

        /// <summary>
        /// Extended constructor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="color"></param>
        /// <param name="size"></param>
        /// <param name="sizeAttenuation"></param>
        /// <param name="vertexColors"></param>
        /// <param name="map"></param>
        /// <param name="fog"></param>
        public IrisPointCloudMaterial(string name, int color, double size, bool sizeAttenuation, int vertexColors, Guid map, bool fog)
            : this()
        {
            Name = name;
            Color = color;
            Size = size;
            SizeAttenuation = sizeAttenuation;
            VertexColors = vertexColors;
            Map = map;
            Fog = fog;
        }

        /// <summary>
        /// Extended constructor.
        /// </summary>
        /// <param name="texture"></param>
        public IrisPointCloudMaterial(Guid texture) : this()
        {
            Color = 16777215;
            Size = 5;
            SizeAttenuation = false;
            VertexColors = 2;
            Map = texture;
        }

        /// <summary>
        /// Check if another object is equal.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(IrisPointCloudMaterial other)
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
    /// For collecting PointCloudMaterials.
    /// </summary>
    public class IrisPointCloudMaterialCollection : Collection<IrisPointCloudMaterial>
    {
        /// <summary>
        /// Add object to the collection if it is unique.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Guid AddIfNew(IrisPointCloudMaterial item)
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
