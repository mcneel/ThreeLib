using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace IrisLib
{
    public class IrisImage : IEquatable<IrisImage>
    {
        [JsonProperty("uuid")]
        public Guid Uuid { get; private set; }

        [JsonProperty("url")]
        public string Url { get; private set; }

        [JsonIgnore]
        public string OriginalPath { get; private set; }

        [JsonIgnore]
        public bool Exists { get; set; }

        public IrisImage()
        {
            Uuid = Guid.NewGuid();
        }

        public IrisImage(string path) : this()
        {
            OriginalPath = path;
            //Url = "/img/" + Path.GetFileName(path);
            Url = GetDataURL(path);
        }

        public static string GetDataURL(string imgFile)
        {
            return "data:image/"
                        + Path.GetExtension(imgFile).Replace(".", "")
                        + ";base64,"
                        + Convert.ToBase64String(File.ReadAllBytes(imgFile));
        }

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

    public class IrisImageCollection : Collection<IrisImage>
    {
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

        public IrisImage FindById(Guid id)
        {
            return this.FirstOrDefault(b => b.Uuid == id);
        }
    }

}
