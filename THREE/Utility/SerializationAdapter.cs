using Newtonsoft.Json;
using System.Collections.Generic;

namespace IrisLib
{
    public abstract class SerializationAdaptor
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("metadata", Order = 0)]
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
        internal GeometryCollection Geometries { get; set; }

        [JsonProperty("images", Order = 2)]
        internal ImageCollection Images { get; set; }

        [JsonProperty("textures", Order = 3)]
        internal TextureCollection Textures { get; set; }

        [JsonProperty("materials", Order = 4)]
        internal MaterialCollection Materials { get; set; }

        internal ObjectSerializationAdaptor()
        {
            Metadata.Type = "Object";
            Geometries = new GeometryCollection();
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
