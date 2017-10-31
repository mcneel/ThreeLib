using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ThreeLib
{
    /// <summary>
    /// Analogous to: https://github.com/mrdoob/three.js/blob/dev/src/materials/MeshStandardMaterial.js
    /// TODO: Add roughness and metalness maps.
    /// </summary>
    public class MeshStandardMaterial : Material, IEquatable<MeshStandardMaterial>
    {
        #region Properties

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
        /// Material ao map.
        /// </summary>
        [JsonIgnore]
        public Texture AoMap { get; set; }

        /// <summary>
        /// ao Uuid.
        /// </summary>
        [JsonProperty("aoMap")]
        public Guid? AoMapUuid
        {
            get
            {
                if (AoMap != null)
                    return AoMap.Uuid;
                else return null;
            }
        }

        /// <summary>
        /// Material alpha map.
        /// </summary>
        [JsonIgnore]
        public Texture AlphaMap { get; set; }

        /// <summary>
        /// AlphaMap Uuid.
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
        /// Material bump map.
        /// </summary>
        [JsonIgnore]
        public Texture BumpMap { get; set; }

        /// <summary>
        /// BumpMap Uuid.
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
        /// The displacement map affects the position of the mesh's vertices. Unlike other maps which only affect the light and shade of the material the displaced vertices can cast shadows, block other objects, and otherwise act as real geometry. The displacement texture is an image where the value of each pixel (white being the highest) is mapped against, and repositions, the vertices of the mesh.
        /// </summary>
        [JsonIgnore]
        public Texture DisplacementMap { get; set; }

        /// <summary>
        /// Displacement map Uuid.
        /// </summary>
        [JsonProperty("displacementMap")]
        public Guid? DisplacementMapUuid
        {
            get
            {
                if (DisplacementMap != null)
                    return DisplacementMap.Uuid;
                else return null;
            }
        }

        /// <summary>
        /// Material environment map.
        /// </summary>
        [JsonIgnore]
        public Texture EnvironmentMap { get; set; }

        /// <summary>
        /// Environment map Uuid.
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
        /// Set emisssive (glow) map. The emissive map color is modulated by the emissive color and the emissive intensity. If you have an emissive map, be sure to set the emissive color to something other than black.
        /// </summary>
        [JsonIgnore]
        public Texture EmissiveMap { get; set; }

        /// <summary>
        /// Emissive map Uuid.
        /// </summary>
        [JsonProperty("emissiveMap")]
        public Guid? EmissiveMapUuid
        {
            get
            {
                if (EmissiveMap != null)
                    return EmissiveMap.Uuid;
                else return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public Texture LightMap { get; set; }

        /// <summary>
        /// Light map Uuid.
        /// </summary>
        [JsonProperty("lightMap")]
        public Guid? LightMapUuid
        {
            get
            {
                if (LightMap != null)
                    return LightMap.Uuid;
                else return null;
            }
        }

        /// <summary>
        /// Material diffuse map.
        /// </summary>
        [JsonIgnore]
        public Texture Map { get; set; }

        /// <summary>
        /// The Uuid of the diffuse map.
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
        /// Material metalness map.
        /// </summary>
        [JsonIgnore]
        public Texture MetalnessMap { get; set; }

        /// <summary>
        /// The Uuid of the metalness map.
        /// </summary>
        [JsonProperty("map")]
        public Guid? MetalnessMapUuid
        {
            get
            {
                if (MetalnessMap != null)
                    return MetalnessMap.Uuid;
                else return null;
            }
        }

        /// <summary>
        /// Material normal map.
        /// </summary>
        [JsonIgnore]
        public Texture NormalMap { get; set; }

        /// <summary>
        /// The Uuid of the normal map.
        /// </summary>
        [JsonProperty("normalMap")]
        public Guid? NormalMapUuid
        {
            get
            {
                if (NormalMap != null)
                    return NormalMap.Uuid;
                else return null;
            }
        }

        /// <summary>
        /// Material roughness map.
        /// </summary>
        [JsonIgnore]
        public Texture RoughnessMap { get; set; }

        /// <summary>
        /// The Uuid of the roughness map.
        /// </summary>
        [JsonProperty("normalMap")]
        public Guid? RoughnessMapUuid
        {
            get
            {
                if (RoughnessMap != null)
                    return RoughnessMap.Uuid;
                else return null;
            }
        }

        #endregion

        #region Constructors

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

        #endregion

        #region Methods

        /// <summary>
        /// Returns material textures as a dictionary.
        /// </summary>
        /// <returns>Dictionary with the texture type as the key. For example, "AlphaMap" key will have a Texture that contains an Alpha Map image.</returns>
        public Dictionary<string, Texture> GetTextures()
        {
            return new Dictionary<string, Texture>
            {
                { "AlphaMap", AlphaMap },
                { "AoMap", AoMap },
                { "BumpMap", BumpMap },
                { "DisplacementMap", DisplacementMap },
                { "EmissiveMap", EmissiveMap },
                { "EnvironmentMap", EnvironmentMap },
                { "LightMap", LightMap },
                { "Map", Map },
                { "MetalnessMap", MetalnessMap },
                { "NormalMap", NormalMap },
                { "RoughnessMap", RoughnessMap }
            };
        }


        /// <summary>
        /// Test to see if this material is equal to another.
        /// </summary>
        /// <param name="other">The material to test against.</param>
        /// <returns>True if the object is equal to this one. False, otherwise.</returns>
        public bool Equals(MeshStandardMaterial other)
        {
            if (other == null) return false;
            return Roughness.Equals(other.Roughness) &&
                   Metalness.Equals(other.Metalness) &&
                   Ambient.Equals(other.Ambient) &&
                   Color.Equals(other.Color) &&
                   Emissive.Equals(other.Emissive) &&
                   Map == other.Map &&
                   BumpMap == other.BumpMap &&
                   AlphaMap == other.AlphaMap &&
                   EnvironmentMap == other.EnvironmentMap;
        }

        public override bool Equals(Material other)
        {
            if (other.GetType() == typeof(MeshStandardMaterial)) return Equals((MeshStandardMaterial)other) && base.Equals(other);
            else return false;
        }

        #endregion

    }
}