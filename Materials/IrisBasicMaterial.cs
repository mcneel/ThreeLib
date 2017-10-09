using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace IrisLib
{
    public class IrisBasicMaterial : IrisMaterial, IEquatable<IrisBasicMaterial>
    {
        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("color", DefaultValueHandling = DefaultValueHandling.Include)]
        public int Color { get; private set; }

        public IrisBasicMaterial()
        {
            Type = "MeshBasicMaterial";
        }

        public IrisBasicMaterial(string name, int color) : this()
        {
            Name = name;
            Color = color;
        }

        public bool Equals(IrisBasicMaterial other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return Type.Equals(other.Type) &&
                       Color.Equals(other.Color);
            }
        }
    }

    public class IrisBasicMaterialCollection : Collection<IrisBasicMaterial>
    {
        public Guid AddIfNew(IrisBasicMaterial item)
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
