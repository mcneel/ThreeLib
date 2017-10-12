using System;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;

namespace IrisLib
{
    /// <summary>
    /// For creating lambert materials. Analogous to:
    /// https://threejs.org/docs/index.html#api/materials/MeshLambertMaterial
    /// </summary>
    public class IrisLambertMaterial : IrisMaterial, IEquatable<IrisLambertMaterial>
    {
        /// <summary>
        /// Object name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Material diffuse color.
        /// </summary>
        [JsonProperty("color", DefaultValueHandling = DefaultValueHandling.Include)]
        public int Color { get; set; }

        /// <summary>
        /// Material ambient color.
        /// </summary>
        [JsonProperty("ambient")]
        public int Ambient { get; set; }

        /// <summary>
        /// Material emissive color.
        /// </summary>
        [JsonProperty("emissive")]
        public int Emissive { get; set; }

        /// <summary>
        /// Material opacity.
        /// </summary>
        [JsonProperty("opacity")]
        public double Opacity { get; set; }

        /// <summary>
        /// Material transparency flag.
        /// </summary>
        [JsonProperty("transparent")]
        public bool Transparent { get; set; }

        /// <summary>
        /// Material vertex color flag.
        /// </summary>
        [JsonProperty("vertexColors")]
        public int VertexColors { get; set; }

        /// <summary>
        /// Material side.
        /// </summary>
        [JsonProperty("side")]
        public int Side { get; set; }

        /// <summary>
        /// Material diffuse map.
        /// </summary>
        [JsonProperty("map")]
        public Guid Map { get; set; }

        /// <summary>
        /// Material bump map.
        /// </summary>
        [JsonProperty("bumpMap")]
        public Guid BumpMap { get; set; }

        /// <summary>
        /// Material alpha map.
        /// </summary>
        [JsonProperty("alphaMap")]
        public Guid AlphaMap { get; set; }

        /// <summary>
        /// Material environment map.
        /// </summary>
        [JsonProperty("envMap")]
        public Guid EnvironmentMap { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public IrisLambertMaterial()
        {
            Type = "MeshLambertMaterial";
        }

        /// <summary>
        /// Creates a default IrisLambertMaterial.
        /// </summary>
        /// <returns>An IrisLambertMaterial with default values.</returns>
        public static IrisLambertMaterial Default()
        {
            return new IrisLambertMaterial()
            {
                Color = 16777215,
                Transparent = false,
                Opacity = 1.00,
                Emissive = 0
            };
        }
        
        /// <summary>
        /// Check if object equals another.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(IrisLambertMaterial other)
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
                       Side.Equals(other.Side) &&
                       Transparent.Equals(other.Transparent) &&
                       VertexColors.Equals(other.VertexColors);
            }
        }
    }

    /// <summary>
    /// For collecting materials.
    /// </summary>
    public class IrisLambertMaterialCollection : Collection<IrisLambertMaterial>
    {
        /// <summary>
        /// Add a material to the collection if it is unique.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Guid AddIfNew(IrisLambertMaterial item)
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