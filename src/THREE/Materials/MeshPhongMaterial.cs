using Newtonsoft.Json;
using System;

namespace THREE
{
    public class MeshPhongMaterial : Material, IEquatable<MeshPhongMaterial>
    {
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

        public bool Equals(MeshPhongMaterial other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(Material other)
        {
            if (other.GetType() == typeof(MeshPhongMaterial)) return Equals((MeshPhongMaterial)other) && base.Equals(other);
            else return false;
        }
    }
}
