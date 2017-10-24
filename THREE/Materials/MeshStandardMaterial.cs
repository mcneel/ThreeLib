using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisLib
{
    /// <summary>
    /// 
    /// </summary>
    public class MeshStandardMaterial : Material
    {

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
        /// Material transparency switch.
        /// </summary>
        [JsonProperty("transparent")]
        public bool Transparent { get; set; }

        /// <summary>
        /// Material diffuse map.
        /// </summary>
        [JsonIgnore]
        public Texture Map { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("map")]
        public Guid? MapUuid
        {
            get
            {
                if (Map != null)
                    return Map.Uuid;
                else return null;
            }
        }

        /// <summary>
        /// Material bump map.
        /// </summary>
        [JsonIgnore]
        public Texture BumpMap { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bumpMap")]
        public Guid? BumpMapUuid
        {
            get
            {
                if (BumpMap != null)
                    return BumpMap.Uuid;
                else return null;
            }
        }

        /// <summary>
        /// Material alpha map.
        /// </summary>
        [JsonIgnore]
        public Texture AlphaMap { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("alphaMap")]
        public Guid? AlphaMapUuid
        {
            get
            {
                if (AlphaMap != null)
                    return AlphaMap.Uuid;
                else return null;
            }
        }

        /// <summary>
        /// Material environment map.
        /// </summary>
        [JsonIgnore]
        public Texture EnvironmentMap { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("envMap")]
        public Guid? EnvironmentMapUuid
        {
            get
            {
                if (EnvironmentMap != null)
                    return EnvironmentMap.Uuid;
                else return null;
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MeshStandardMaterial()
        {
            Type = "MeshStandardMaterial";
        }

        /// <summary>
        /// Creates a MeshStandardMaterial with some default settings.
        /// </summary>
        /// <returns>An MeshStandardMaterial with default values.</returns>
        public static MeshStandardMaterial Default()
        {
            return new MeshStandardMaterial()
            {
                Color = 16777215,
                Roughness = 1.00,
                Metalness = 0.25,
                Transparent = false,
                Opacity = 1,
                Emissive = 0
            };
        }
        

        /// <summary>
        /// Returns material textures as a list in the following order:
        /// Map, BumpMap, AlphaMap, EnvironmentMap
        /// </summary>
        /// <returns></returns>
        public List<Texture> GetTextures()
        {
            return new List<Texture>
            {
                { Map },
                { BumpMap },
                { AlphaMap },
                { EnvironmentMap }
            };
        }


        /// <summary>
        /// Test to see if this material is equal to another.
        /// </summary>
        /// <param name="other">The material to test against.</param>
        /// <returns>True if the object is equal to this one. False, otherwise.</returns>
        public bool Equals(MeshStandardMaterial other)
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

}
