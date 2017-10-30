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
            if (other == null) return false;
            else return Mapping.Equals(other.Mapping) &&
                        Repeat.SequenceEqual(other.Repeat) &&
                        Wrap.SequenceEqual(other.Wrap) &&
                        Image.Equals(other.Image);
        }

        public override int GetHashCode()
        {
            return Mapping.GetHashCode() ^ Repeat.GetHashCode() ^ Wrap.GetHashCode() ^ Image.GetHashCode();
        }

        public static bool operator ==(Texture a, Texture b)
        {
            bool ba, bb;
            ba = ReferenceEquals(null, a);
            bb = ReferenceEquals(null, b);
            if (ba & bb) return true; //they are both null
            else if (!ba & !bb) return a.Equals(b); //they are both not null
            else return false;
        }

        public static bool operator !=(Texture a, Texture b)
        {
            return !(a == b);
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
