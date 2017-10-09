using System;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Linq;

namespace IrisLib
{

    public class IrisFont : IrisElement, IEquatable<IrisFont>
    {
        [JsonProperty("name")]
        public string Name { get; set; }

		[JsonProperty("glyphs")]
		public object Glyphs { get; set;}

        public IrisFont()
        {
            Type = "Font";
        }

        public IrisFont( object glyphs, string name ) : this()
        {
            Name = name;
            Glyphs = glyphs;
        }

        public bool Equals(IrisFont other)
        {
            if (other == null)  return false;

            return Name.Equals(other.Name);
        }

    }

    public class IrisFontCollection : Collection<IrisFont>
    {

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
