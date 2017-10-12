using System;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;

namespace IrisLib
{
    /// <summary>
    /// Create a Phong material analogous to a MeshPhongMaterial
    /// https://threejs.org/docs/index.html#api/materials/MeshPhongMaterial
    /// </summary>
    public class IrisPhongMaterial : IrisMaterial, IEquatable<IrisPhongMaterial>
    {
        /// <summary>
        /// Material name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Material diffuse color.
        /// </summary>
        [JsonProperty("color", DefaultValueHandling = DefaultValueHandling.Include)]
        public int Color { get; private set; }

        /// <summary>
        /// Material ambient color.
        /// </summary>
        [JsonProperty("ambient")]
        public int Ambient { get; private set; }

        /// <summary>
        /// Material emissive color.
        /// </summary>
        [JsonProperty("emissive")]
        public int Emissive { get; private set; }

        /// <summary>
        /// Material specular color.
        /// </summary>
        [JsonProperty("specular")]
        public int Specular { get; private set; }

        /// <summary>
        /// Material shininess.
        /// </summary>
        [JsonProperty("shininess")]
        public double Shininess { get; private set; }

        /// <summary>
        /// Material opacity.
        /// </summary>
        [JsonProperty("opacity")]
        public double Opacity { get; private set; }

        /// <summary>
        /// Material transparency flag.
        /// </summary>
        [JsonProperty("transparent")]
        public bool Transparent { get; private set; }

        /// <summary>
        /// Material vertex colors flag.
        /// </summary>
        [JsonProperty("vertexColors", DefaultValueHandling = DefaultValueHandling.Include)]
        public int VertexColors { get; private set; }

        /// <summary>
        /// Material side.
        /// </summary>
        [JsonProperty("side")]
        public int Side { get; private set; }

        /// <summary>
        /// Material diffuse texture.
        /// </summary>
        [JsonProperty("map")]
        public Guid Map { get; private set; }

        /// <summary>
        /// Material bump texture.
        /// </summary>
        [JsonProperty("bumpMap")]
        public Guid BumpMap { get; private set; }

        /// <summary>
        /// Material alpha texture.
        /// </summary>
        [JsonProperty("alphaMap")]
        public Guid AlphaMap { get; private set; }

        /// <summary>
        /// Material environment map.
        /// </summary>
        [JsonProperty("envMap")]
        public Guid EnvironmentMap { get; private set; }

        /// <summary>
        /// Base constructor.
        /// </summary>
        public IrisPhongMaterial()
        {
            Type = "MeshPhongMaterial";
        }

        /// <summary>
        /// Creates an IrisPhongMaterial with default values.
        /// </summary>
        /// <returns>An IrisPhongMaterial with default values.</returns>
        public static IrisPhongMaterial Default()
        {
            return new IrisPhongMaterial()
            {
                Color = 16777215,
                Transparent = false,
                Opacity = 1.00,
                Emissive = 0
            };
        }
        
        /// <summary>
        /// Check whether this material equals another.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(IrisPhongMaterial other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return Type.Equals(other.Type) &&
                       AlphaMap.Equals(other.AlphaMap) &&
                       Ambient.Equals(other.Ambient) &&
                       BumpMap.Equals(other.BumpMap) &&
                       Color.Equals(other.Color) &&
                       Emissive.Equals(other.Emissive) &&
                       EnvironmentMap.Equals(other.EnvironmentMap) &&
                       Map.Equals(other.Map) &&
                       Opacity.Equals(other.Opacity) &&
                       Shininess.Equals(other.Shininess) &&
                       Side.Equals(other.Side) &&
                       Specular.Equals(other.Specular) &&
                       Transparent.Equals(other.Transparent) &&
                       VertexColors.Equals(other.VertexColors);
            }
        }
    }

    /// <summary>
    /// Basic collection for storing materials.
    /// </summary>
    public class IrisPhongMaterialCollection : Collection<IrisPhongMaterial>
    {
        /// <summary>
        /// Add a material to the collection if it is unique.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Guid AddIfNew(IrisPhongMaterial item)
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
