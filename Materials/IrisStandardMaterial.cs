using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.ObjectModel;

namespace IrisLib
{
    /// <summary>
    /// For creating Three.js MeshStandardMaterials.
    /// </summary>
    public class IrisStandardMaterial : IrisMaterial
    {
        /// <summary>
        /// Material name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Material diffuse color.
        /// </summary>
        [JsonProperty("color", DefaultValueHandling = DefaultValueHandling.Include)]
        public int Color { get; set; }

        /// <summary>
        /// Material roughness.
        /// </summary>
        [JsonProperty("roughness")]
        public double Roughness { get; set; }

        /// <summary>
        /// Material metalness.
        /// </summary>
        [JsonProperty("metalness")]
        public double Metalness { get; set; }

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
        /// Material transparency switch.
        /// </summary>
        [JsonProperty("transparent")]
        public bool Transparent { get; set; }

        /// <summary>
        /// Material vertex colors switch.
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
        /// Base constructor.
        /// </summary>
        public IrisStandardMaterial()
        {
            Type = "MeshStandardMaterial";

        }
        
        /// <summary>
        /// Creates an IrisStandardMaterial with some default settings.
        /// </summary>
        /// <returns>An IrisStandardMaterial with default values.</returns>
        public static IrisStandardMaterial Default()
        {
            return new IrisStandardMaterial()
            {
                Color = 16777215,
                Roughness = 1.00,
                Metalness = 0.25,
                Transparent = false,
                Opacity = 1.00,
                Emissive = 0
            };
        }

        /// <summary>
        /// Test to see if this material is equal to another.
        /// </summary>
        /// <param name="other">The material to test against.</param>
        /// <returns>True if the object is equal to this one. False, otherwise.</returns>
        public bool Equals(IrisStandardMaterial other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return Type.Equals(other.Type) &&
                       Roughness.Equals(other.Roughness) &&
                       Metalness.Equals(other.Metalness) &&
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
    public class IrisStandardMaterialCollection : Collection<IrisStandardMaterial>
    {
        /// <summary>
        /// Add a new object to the collection if it is unique.
        /// </summary>
        /// <param name="item">The item to add if unique.</param>
        /// <returns>The Uuid of the item in the collection.</returns>
        public Guid AddIfNew(IrisStandardMaterial item)
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
