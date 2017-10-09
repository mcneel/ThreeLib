using System;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Linq;

namespace IrisLib
{

    /// <summary>
    /// Class for storing fint information for text objects.
    /// </summary>
    public class IrisFont : IrisElement, IEquatable<IrisFont>
    {
        /// <summary>
        /// Name of the font.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The glyphs to include with this font.
        /// </summary>
		[JsonProperty("glyphs")]
		public object Glyphs { get; set;}

        /// <summary>
        /// Base constructor for the font.
        /// </summary>
        public IrisFont()
        {
            Type = "Font";
        }

        /// <summary>
        /// Constructor for the font.
        /// </summary>
        /// <param name="glyphs"></param>
        /// <param name="name"></param>
        public IrisFont( object glyphs, string name ) : this()
        {
            Name = name;
            Glyphs = glyphs;
        }

        /// <summary>
        /// Check if this font equals another.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(IrisFont other)
        {
            if (other == null)  return false;

            return Name.Equals(other.Name);
        }

    }

    /// <summary>
    /// Simple collection to store fonts.
    /// </summary>
    public class IrisFontCollection : Collection<IrisFont>
    {
        /// <summary>
        /// Add a font if it does not already exist.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Guid AddIfNew(IrisFont item)
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
