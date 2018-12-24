using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace THREE.Core
{
    /// <summary>
    /// Create a set of Shapes representing a font loaded in JSON format.
    /// Analagous to: https://threejs.org/docs/index.html#api/en/extras/core/Font
    /// </summary>
    public class Font : Element, IEquatable<Font>
    {
        /// <summary>
        /// String of text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// (optional) Scale for the Shapes. Default is 100.
        /// </summary>
        public float Size { get; set; }

        /// <summary>
        /// JSON data representing the font.
        /// </summary>
        [JsonIgnore]
        public FontData FontData { get; set; }

        /// <summary>
        /// font data Uuid.
        /// </summary>
        [JsonProperty("data")]
        public Guid? Data
        {
            get
            {
                if (FontData != null)
                    return FontData.Uuid;
                else return null;
            }
            set
            {
                if(FontData != null)
                    FontData.Uuid = value.Value;
            }
        }

        /// <summary>
        /// Used to check whether this or derived classes are fonts. Default is true.
        /// You should not change this, as it used internally by the renderer for optimisation.
        /// </summary>
        public bool IsFont { get; set; }

        public Font()
        {
            FontData = new FontData();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual bool Equals(Font other)
        {
            if (other == null) return false;
            return FontData.Equals(other.FontData) && Size.Equals(other.Size);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal class FontDataCollection : Collection<FontData>
    {

        /// <summary>
        /// Add a material to this collection if it does not already exist.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Guid AddIfNew(FontData item)
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

    public class FontData : Element, IEquatable<FontData>
    {

        public object Data { get; set; }

        public virtual bool Equals(FontData other)
        {
            if (other == null) return false;

            var name = ((JObject)Data).Property("familyName").Value.ToString();
            var nameOther = ((JObject)other.Data).Property("familyName").Value.ToString();

            return name == nameOther;
        }

        
    }
}
