using System;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;

namespace IrisLib
{
    public class IrisTexture : IEquatable<IrisTexture>
    {
        [JsonProperty("uuid")]
        public Guid Uuid { get; private set; }

        [JsonProperty("image")]
        public Guid Image { get; private set; }

        [JsonIgnore]
        public string ImageUrl { get; private set; }

        [JsonProperty("mapping")]
        public int Mapping { get; private set; }

        [JsonProperty("wrap")]
        public int[] Wrap { get; private set; }

        [JsonProperty("repeat")]
        public double[] Repeat { get; private set; }

        public IrisTexture()
        {
            Uuid = Guid.NewGuid();
        }

        public IrisTexture(Guid image, string imageUrl, int[] wrap, double[] repeat) : this()
        {
            Image = image;
            ImageUrl = imageUrl;
            Wrap = wrap;
            Repeat = repeat;
        }

        public IrisTexture(Guid image, string imageUrl, int[] wrap, double[] repeat, int mapping)
            : this()
        {
            Image = image;
            ImageUrl = imageUrl;
            Mapping = mapping;
            Wrap = wrap;
            Repeat = repeat;
        }

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

    public class IrisTextureCollection : Collection<IrisTexture>
    {
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
