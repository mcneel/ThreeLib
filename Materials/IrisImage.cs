using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace IrisLib
{
    /// <summary>
    /// For embedding images into the scene.
    /// </summary>
    public class IrisImage : IEquatable<IrisImage>
    {
        /// <summary>
        /// Object Id.
        /// </summary>
        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        /// <summary>
        /// Image url.
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
        public IrisImage()
        {
            Uuid = Guid.NewGuid();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="path"></param>
        public IrisImage(string path) : this()
        {
            OriginalPath = path;
            //Url = "/img/" + Path.GetFileName(path);
            Url = GetDataURL(path);
        }

        /// <summary>
        /// Encode image to base64.
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

        /// <summary>
        /// Check if object is equal to another.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(IrisImage other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return Url.Equals(other.Url);
            }
        }

    }

    /// <summary>
    /// For collecting images.
    /// </summary>
    public class IrisImageCollection : Collection<IrisImage>
    {
        /// <summary>
        /// Add object to the collection if it is unique.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Guid AddIfNew(IrisImage item)
        {
            var q = from a in this
                    where a.Equals(item)
                    select a.Uuid;

            var enumerable = q as Guid[] ?? q.ToArray();
            if (!enumerable.Any())
            {
                Add(item);

                item.Exists = false;
                return item.Uuid;
            }
            else
            {
                item.Exists = true;
                return enumerable.Single();
            }
        }

        /// <summary>
        /// Find object by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IrisImage FindById(Guid id)
        {
            return this.FirstOrDefault(b => b.Uuid == id);
        }
    }

}
