using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace THREE
{
    public class Image: IEquatable<Image>
    {

        /// <summary>
        /// Object Id.
        /// </summary>
        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        /// <summary>
        /// Image url. This can be the path to the image resource (.jpg, .png, etc), or a base64 encoded asset.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Image path.
        /// </summary>
        [JsonIgnore]
        public string OriginalPath { get; set; }

        /// <summary>
        /// Image exists flag.
        /// </summary>
        [JsonIgnore]
        public bool Exists { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Image()
        {
            Uuid = Guid.NewGuid();
        }

        /// <summary>
        /// Encode image to base64.
        /// TODO: consider removing this to the example application.
        /// </summary>
        /// <param name="imgFile"></param>
        /// <returns></returns>
        public static string GetDataURL(string imgFile)
        {
            return "data:image/"
                        + Path.GetExtension(imgFile).Replace(".", "")
                        + ";base64,"
                        + Convert.ToBase64String(File.ReadAllBytes(imgFile));
        }

        public bool Equals(Image other)
        {
            if (other == null) return false;
            else return string.Equals(Url, other.Url);
        }

        public override int GetHashCode()
        {
            return Url.GetHashCode();
        }

        public static bool operator ==(Image a, Image b)
        {
            bool ba = ReferenceEquals(null, a);
            bool bb = ReferenceEquals(null, b);
            if (ba & bb) return true; //they are both null
            else if (!ba & !bb) return a.Equals(b); //they are both not null
            else return false;
        }

        public static bool operator !=(Image a, Image b)
        {
            return !(a == b);
        }

    }

    public class ImageCollection: Collection<Image>
    {
        /// <summary>
        /// Add an Image to this collection if it does not already exist.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Guid AddIfNew(Image item)
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
