using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace IrisLib
{

    public class Texture : IEquatable<Texture>
    {
        /// <summary>
        /// Object Id.
        /// </summary>
        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        /// <summary>
        /// Image associated with this texture.
        /// </summary>
        [JsonIgnore]
        public Image Image { get; set; }

        /// <summary>
        /// URL of the image.
        /// </summary>
        [JsonProperty("image")]
        public Guid? ImageUuid
        {
            get
            {
                if (Image != null)
                    return Image.Uuid;
                else return null;
            }
        }

        /// <summary>
        /// Texture mapping.
        /// </summary>
        [JsonProperty("mapping")]
        public int Mapping { get; set; }

        /// <summary>
        /// Texture wrapping.
        /// </summary>
        [JsonProperty("wrap")]
        public int[] Wrap { get; set; }

        /// <summary>
        /// Texture repetition.
        /// </summary>
        [JsonProperty("repeat")]
        public double[] Repeat { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Texture()
        {
            Uuid = Guid.NewGuid();
        }

        public bool Equals(Texture other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {

                return  Mapping.Equals(other.Mapping) &&
                        Repeat.Equals(other.Repeat) &&
                        Wrap.Equals(other.Wrap) &&
                        Image.Equals(other.Image);
            }
        }
    }

    public class TextureCollection : Collection<Texture>
    {
        /// <summary>
        /// Add a Texture to this collection if it does not already exist.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Guid AddIfNew(Texture item)
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
