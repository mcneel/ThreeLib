using Newtonsoft.Json;
using THREE.Core;
using THREE.Materials;
using THREE.Textures;

namespace THREE.Utility
{
    public abstract class SerializationAdaptor
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(Order = 0)]
        public Metadata Metadata { get; set; }

        internal SerializationAdaptor()
        {
            Metadata = new Metadata
            {
                Version = 4.5,
                Generator = "ThreeLib"
            };
        }
    }

    public abstract class ObjectSerializationAdaptor: SerializationAdaptor
    {
        [JsonProperty("geometries", Order = 1)]
        internal ElementCollection Elements { get; set; }

        [JsonIgnore]
        internal BufferGeometryCollection BufferGeometries { get; set; }

        [JsonIgnore]
        internal GeometryCollection Geometries { get; set; }

        [JsonProperty(Order = 2)]
        internal ImageCollection Images { get; set; }

        [JsonProperty(Order = 3)]
        internal TextureCollection Textures { get; set; }

        [JsonProperty(Order = 4)]
        internal MaterialCollection Materials { get; set; }

        internal ObjectSerializationAdaptor()
        {
            Metadata.Type = "Object";
            Elements = new ElementCollection();
            Geometries = new GeometryCollection();
            BufferGeometries = new BufferGeometryCollection();
            Materials = new MaterialCollection();
            Images = new ImageCollection();
            Textures = new TextureCollection();
        }

        public bool ShouldSerializeImages()
        {
            return Images.Count > 0;
        }

        public bool ShouldSerializeTextures()
        {
            return Textures.Count > 0;
        }

    }
}
