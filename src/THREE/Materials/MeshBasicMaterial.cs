using Newtonsoft.Json;
using System;
using THREE.Textures;

namespace THREE.Materials
{
    public class MeshBasicMaterial : Material, IEquatable<MeshBasicMaterial>
    {

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
        /// 
        /// </summary>
        [JsonIgnore]
        public Texture SpecularMap { get; set; }

        /// <summary>
        /// Specular map Uuid.
        /// </summary>
        [JsonProperty("lightMap")]
        public Guid? SpecularMapUuid
        {
            get
            {
                if (SpecularMap != null)
                    return SpecularMap.Uuid;
                else return null;
            }
        }

        public bool Equals(MeshBasicMaterial other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(Material other)
        {
            if (other.GetType() == typeof(MeshBasicMaterial)) return Equals((MeshBasicMaterial)other) && base.Equals(other);
            else return false;
        }
    }
}
