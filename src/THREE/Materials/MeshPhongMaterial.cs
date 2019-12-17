using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using THREE.Textures;

namespace THREE.Materials
{
    /// <summary>
    /// 
    /// </summary>
    public class MeshPhongMaterial : Material, IEquatable<MeshPhongMaterial>
    {
        /// <summary>
        /// Material diffuse color.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
        public int Color { get; set; }

        /// <summary>
        /// Material emissive color.
        /// </summary>
        public int Emissive { get; set; }

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

        [JsonIgnore]
        internal Dictionary<string, Texture> Textures { get; set; }

        public MeshPhongMaterial() 
        {
            Textures = new Dictionary<string, Texture>();
        }

        public static MeshPhongMaterial Default() 
        {
            return new MeshPhongMaterial()
            {
                Color = 16777215,
                Transparent = false,
                Opacity = 1,
                Emissive = 0,
                Side = MaterialSide.Front
            };
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
