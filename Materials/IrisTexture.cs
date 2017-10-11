using System;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;

namespace IrisLib
{
    /// <summary>
    /// For creating textures. Analogous to:
    /// https://threejs.org/docs/index.html#api/textures/Texture
    /// </summary>
    public class IrisTexture : IEquatable<IrisTexture>
    {
        /// <summary>
        /// Object Id.
        /// </summary>
        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        /// <summary>
        /// Image associated with this texture.
        /// </summary>
        [JsonProperty("image")]
        public Guid Image { get; set; }

        /// <summary>
        /// URL of the image.
        /// </summary>
        [JsonIgnore]
        public string ImageUrl { get; set; }

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
        public IrisTexture()
        {
            Uuid = Guid.NewGuid();
        }

        /// <summary>
        /// Extended constructor.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="imageUrl"></param>
        /// <param name="wrap"></param>
        /// <param name="repeat"></param>
        public IrisTexture(Guid image, string imageUrl, int[] wrap, double[] repeat) : this()
        {
            Image = image;
            ImageUrl = imageUrl;
            Wrap = wrap;
            Repeat = repeat;
        }

        /// <summary>
        /// Extended constructor.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="imageUrl"></param>
        /// <param name="wrap"></param>
        /// <param name="repeat"></param>
        /// <param name="mapping"></param>
        public IrisTexture(Guid image, string imageUrl, int[] wrap, double[] repeat, int mapping)
            : this()
        {
            Image = image;
            ImageUrl = imageUrl;
            Mapping = mapping;
            Wrap = wrap;
            Repeat = repeat;
        }

        /// <summary>
        /// Check if another object is equals.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(IrisTexture other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {

                return ImageUrl.Equals(other.ImageUrl) &&
                        Repeat[0].Equals(other.Repeat[0]) &&
                        Repeat[1].Equals(other.Repeat[1]) &&
                        Wrap[0].Equals(other.Wrap[0]) &&
                        Wrap[1].Equals(other.Wrap[1]);
            }
        }
    }

    /// <summary>
    /// For collecting textures.
    /// </summary>
    public class IrisTextureCollection : Collection<IrisTexture>
    {
        /// <summary>
        /// Add a new object to this collection if it is unique.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Guid AddIfNew(IrisTexture item)
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
